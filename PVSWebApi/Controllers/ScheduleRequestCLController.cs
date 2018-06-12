using PVSWebApi.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PVSLibrary;
using System.Security.Cryptography;
using System.Text;

namespace PVSWebApi.Controllers
{
    [HMACAuthentication]
    [RoutePrefix("api")]
    public class ScheduleRequestCLController : ApiController
    {
        // POST api/ScheduleRequestCL {object}
        [Route("ScheduleRequestCL")]
        public IHttpActionResult Post(ScheduleRequest ScheduleRequestCL)
        {
            string strObj = JsonConvert.SerializeObject(ScheduleRequestCL, Formatting.None);
            var jsonDef = new { Name = "" };
            var jsonObj = JsonConvert.DeserializeAnonymousType(strObj, jsonDef);
            string jsonName = jsonObj.Name;
            if (jsonName == "ScheduleRequestCL")
            {
                return Ok(EncryptResponse("SampleScheduleResponseLC"));
            }
            else
            {
                string strError = "Invalid Request Name";
                return InternalServerError(new Exception(strError));
            }
        }

        static string EncryptResponse(string strClass)
        {
            string encResp = string.Empty;
            switch (strClass)
            {
                case "SampleScheduleResponseLC":
                    ScheduleResponse resp = new ScheduleResponse();
                    resp = PVSLibrary.Common.SampleScheduleResponseLC();
                    string strObj = JsonConvert.SerializeObject(resp, Formatting.None);
                    encResp = Encrypt(strObj, "k6KUvMXYy2I6J5y5hTTgsqG8E2VDL64JhFtPjBB//sU=", true);
                    break;
            }
            return encResp;
        }


        public static string Encrypt(string toEncrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
