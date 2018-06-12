using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using System.IO;
using Newtonsoft.Json;

namespace PVSWebApi.Filters
{
    public class HMACAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        // constants
        private static Dictionary<string, string> colSecretKeys = new Dictionary<string, string>();
        private static Dictionary<string, string> colEncryptKeys = new Dictionary<string, string>();
        private readonly UInt64 conMaxAgeInSeconds = 300;  //5 mins
        private readonly string conAuthenticationScheme = "pvss";

        public HMACAuthenticationAttribute()
        {
            if (colSecretKeys.Count == 0)
            {
                colSecretKeys.Add("4d53bce03ec34c0a911182d4c228ee6c", "A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=");
            }
            if (colEncryptKeys.Count == 0)
            {
                colEncryptKeys.Add("4d53bce03ec34c0a911182d4c228ee6c", "k6KUvMXYy2I6J5y5hTTgsqG8E2VDL64JhFtPjBB//sU=");
            }

        }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var inReq = context.Request;

            if (inReq.Headers.Authorization != null && conAuthenticationScheme.Equals(inReq.Headers.Authorization.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                var inReqHeadAuthParam = inReq.Headers.Authorization.Parameter;

                var inReqHeadAuthParamArray = ParseHeadAuthParams(inReqHeadAuthParam);

                if (inReqHeadAuthParamArray != null)
                {
                    var inReqAppKey = inReqHeadAuthParamArray[0];
                    var inReqSignatureBase64String = inReqHeadAuthParamArray[1];
                    var inReqNonce = inReqHeadAuthParamArray[2];
                    var inReqTimeStamp = inReqHeadAuthParamArray[3];

                    var inReqValid = ValidateHeadAuthParams(inReq, inReqAppKey, inReqSignatureBase64String, inReqNonce, inReqTimeStamp);

                    if (inReqValid.Result)
                    {
                        var currentPrincipal = new GenericPrincipal(new GenericIdentity(inReqAppKey), null);
                        context.Principal = currentPrincipal;
                    }
                    else
                    {
                        context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
                    }
                }
                else
                {
                    context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
                }
            }
            else
            {
                context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
            }
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new ResultWithChallenge(context.Result);
            return Task.FromResult(0);
        }

        public bool AllowMultiple
        {
            get { return false; }
        }

        static string[] ParseHeadAuthParams(string inReqHeadAuthParam)
        {
            var paramArray = inReqHeadAuthParam.Split(':');
            if (paramArray.Length == 4)
                return paramArray;
            else
                return null;
        }

        private async Task<bool> ValidateHeadAuthParams(HttpRequestMessage inReq, string inReqAppKey, string inReqSignatureBase64String, string inReqNonce, string inReqTimeStamp)
        {
            string inContentBase64String = string.Empty;
            string inUri = HttpUtility.UrlEncode(inReq.RequestUri.AbsoluteUri.ToLower());
            string inHttpMethod = inReq.Method.Method;

            if (!colSecretKeys.ContainsKey(inReqAppKey))
            {
                return false;
            }

            var secretKey = colSecretKeys[inReqAppKey];

            if (isReplayRequest(inReqNonce, inReqTimeStamp))
            {
                return false;
            }

            byte[] inHash = await CalculateHash(inReq.Content);
            if (inHash != null)
            {
                inContentBase64String = Convert.ToBase64String(inHash);
            }

            string signatureRawData = String.Format("{0}{1}{2}{3}{4}{5}", inReqAppKey, inHttpMethod, inUri, inReqTimeStamp, inReqNonce, inContentBase64String);

            var secretKeyByteArray = Convert.FromBase64String(secretKey);

            byte[] signature = Encoding.UTF8.GetBytes(signatureRawData);

            using (HMACSHA256 hmac = new HMACSHA256(secretKeyByteArray))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);

                string thisSignatureBase64String = Convert.ToBase64String(signatureBytes);

                return (inReqSignatureBase64String.Equals(thisSignatureBase64String, StringComparison.Ordinal));
            }

        }

        private bool isReplayRequest(string inNonce, string inTimeStamp)
        {
            if (System.Runtime.Caching.MemoryCache.Default.Contains(inNonce))
            {
                return true;
            }

            DateTime thisEpochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan thisTimeSpan = DateTime.UtcNow - thisEpochStart;
            var thisTotalSeconds = Convert.ToUInt64(thisTimeSpan.TotalSeconds);
            var reqTotalSeconds = Convert.ToUInt64(inTimeStamp);

            if ((thisTotalSeconds - reqTotalSeconds) > conMaxAgeInSeconds)
            {
                return true;
            }

            System.Runtime.Caching.MemoryCache.Default.Add(inNonce, inTimeStamp, DateTimeOffset.UtcNow.AddSeconds(conMaxAgeInSeconds));

            return false;
        }

        private static async Task<byte[]> CalculateHash(HttpContent httpContent)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = null;
                var content = await httpContent.ReadAsByteArrayAsync();
                if (content.Length != 0)
                {
                    hash = md5.ComputeHash(content);
                }
                return hash;
            }
        }

        public class ResultWithChallenge : IHttpActionResult
        {
            private readonly string conAuthenticationScheme = "pvss";
            private readonly IHttpActionResult next;

            public ResultWithChallenge(IHttpActionResult next)
            {
                this.next = next;
            }

            public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response = await next.ExecuteAsync(cancellationToken);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(conAuthenticationScheme));
                }
                return response;
            }
        }

    }
}