using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PVSLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace PVSUI
{
    public partial class PVSMainForm : Form
    {
        public PVSMainForm()
        {
            InitializeComponent();
        }

        private void PVSMainForm_Load(object sender, EventArgs e)
        {
        }

        private void butSerScheduleRequestCL_Click(object sender, EventArgs e)
        {
            SetBackColorHighlight(sender, "Schedule");
            var jsonObject = PVSLibrary.Common.SampleScheduleRequestCL();
            string strObj = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            AdjustTextOutput(strObj, true);
        }

        private void butSerScheduleResponseLC_Click(object sender, EventArgs e)
        {
            SetBackColorHighlight(sender, "Schedule");
            var jsonObject = PVSLibrary.Common.SampleScheduleResponseLC();
            string strObj = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            AdjustTextOutput(strObj, true);
        }

        private void butDesScheduleRequestCL_Click(object sender, EventArgs e)
        {
            SetBackColorHighlight(sender, "Schedule");

            var jsonObject = PVSLibrary.Common.SampleScheduleRequestCL();
            string strObj = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            AdjustTextOutput(strObj, true);

            var jsonDef = new { Name = "" };
            var jsonObj = JsonConvert.DeserializeAnonymousType(strObj, jsonDef);
            string jsonName = jsonObj.Name;
            if (jsonName == "ScheduleRequestCL")
            {
                AdjustTextOutput("Name = " + jsonName.ToString(), false);
                var jRequestCL = JsonConvert.DeserializeObject<ScheduleRequestModel>(strObj);
                int timCount = 0;
                foreach (var tim in jRequestCL.TimeStamps)
                {
                    AdjustTextOutput("Timestamps: [" + timCount.ToString() +
                        "] Source = " + tim.Source.ToString() +
                        ", TimeStamp = " + tim.Timestamp.ToString(), false);
                    timCount++;
                }
                int batCount = 0;
                foreach (var bat in jRequestCL.Batteries)
                {
                    AdjustTextOutput("Batteries: [" + batCount.ToString() +
                        "] ID = " + bat.BatteryID.ToString() +
                        ", SOCMwh = " + bat.SOCMwH.ToString() +
                        ", SOCPer = " + bat.SOCPer.ToString() +
                        ", SOHPer = " + bat.SOHPer.ToString(), false);
                    batCount++;
                }
            }
            else
            {
                AdjustTextOutput("Invalid JSON", false);
            }
        }

        private void butDesScheduleResponseLC_Click(object sender, EventArgs e)
        {
            SetBackColorHighlight(sender, "Schedule");

            var jsonObject = PVSLibrary.Common.SampleScheduleResponseLC();
            string strObj = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            AdjustTextOutput(strObj, true);

            var jsonDef = new { Name = "" };
            var jsonObj = JsonConvert.DeserializeAnonymousType(strObj, jsonDef);
            string jsonName = jsonObj.Name;
            if (jsonName == "ScheduleResponseLC")
            {
                AdjustTextOutput("Name = " + jsonName.ToString(), false);
                var jResponseLC = JsonConvert.DeserializeObject<ScheduleResponseModel>(strObj);
                int timCount = 0;
                foreach (var tim in jResponseLC.TimeStamps)
                {
                    AdjustTextOutput("TimeStamps: [" + timCount.ToString() +
                        "] Source = " + tim.Source.ToString() +
                        ", TimeStamp = " + tim.Timestamp.ToString(), false);
                    timCount++;
                }
                int cmdCount = 0;
                foreach (var cmd in jResponseLC.CommandEvents)
                {
                    AdjustTextOutput("CommandEvents: [" + cmdCount.ToString() +
                        "] EventID = " + cmd.EventID.ToString() +
                        ", Enable = " + cmd.Enable.ToString() +
                        ", PVSFn = " + cmd.PVSFn.ToString() +
                        ", StartHour = " + cmd.StartHour.ToString() +
                        ", StartMin = " + cmd.StartMin.ToString() +
                        ", PpoiMW = " + cmd.PpoiMW.ToString() +
                        ", AVRMode = " + cmd.AVRMode.ToString() +
                        ", QpoiMvar = " + cmd.QpoiMvar.ToString() +
                        ", PFTrgt = " + cmd.PFTrgt.ToString() +
                        ", VTrgtkV = " + cmd.VTrgtkV.ToString() +
                        ", RmpRateMWmin = " + cmd.RmpRateMWmin.ToString() +
                        ", PpvsMW = " + cmd.PpvsMW.ToString() +
                        ", PcMW = " + cmd.PcMW.ToString() +
                        ", ChgPr = " + cmd.ChgPr.ToString() +
                        ", PdMW = " + cmd.PdMW.ToString() +
                        ", SOCMaxPct = " + cmd.SOCMaxPct.ToString() +
                        ", SOCMinPct = " + cmd.SOCMinPct.ToString() +
                        ", GCen = " + cmd.GCen.ToString(), false);
                    cmdCount++;
                }
            }
            else
            {
                AdjustTextOutput("Invalid JSON", false);
            }
        }

        private async void butPostScheduleRequestCL_Click(object sender, EventArgs e)
        {
            string conURL = Constants.PVSWebApiUrl + "ScheduleRequestCL";
            string strDebug = string.Empty;

            HmacClientHandler hmacClientHandler = new HmacClientHandler();
            HttpClient client = HttpClientFactory.Create(hmacClientHandler);
            ScheduleRequestModel jsonObject = PVSLibrary.Common.SampleScheduleRequestCL();
            HttpResponseMessage response = await client.PostAsJsonAsync(conURL, jsonObject);
            if (response.IsSuccessStatusCode)
            {
                string encContent = await response.Content.ReadAsStringAsync();
                encContent = encContent.Trim('"');
                string strContent = Decrypt(encContent, Constants.PVSEncryptKey, true);
                strDebug = "Success. Response.Content: " + strContent;
                AdjustTextOutput(strDebug, false);

                var jsonDef = new { Name = "" };
                var jsonObj = JsonConvert.DeserializeAnonymousType(strContent, jsonDef);
                string jsonName = jsonObj.Name;
                if (jsonName == "ScheduleResponseLC")
                {
                    AdjustTextOutput("Name = " + jsonName.ToString(), false);
                    var jResponseLC = JsonConvert.DeserializeObject<ScheduleResponseModel>(strContent);
                    int timCount = 0;
                    foreach (var tim in jResponseLC.TimeStamps)
                    {
                        AdjustTextOutput("TimeStamps: [" + timCount.ToString() +
                            "] Source = " + tim.Source.ToString() +
                            ", TimeStamp = " + tim.Timestamp.ToString(), false);
                        timCount++;
                    }
                    int cmdCount = 0;
                    foreach (var cmd in jResponseLC.CommandEvents)
                    {
                        AdjustTextOutput("CommandEvents: [" + cmdCount.ToString() +
                            "] EventID = " + cmd.EventID.ToString() +
                            ", Enable = " + cmd.Enable.ToString() +
                            ", PVSFn = " + cmd.PVSFn.ToString() +
                            ", StartHour = " + cmd.StartHour.ToString() +
                            ", StartMin = " + cmd.StartMin.ToString() +
                            ", PpoiMW = " + cmd.PpoiMW.ToString() +
                            ", AVRMode = " + cmd.AVRMode.ToString() +
                            ", QpoiMvar = " + cmd.QpoiMvar.ToString() +
                            ", PFTrgt = " + cmd.PFTrgt.ToString() +
                            ", VTrgtkV = " + cmd.VTrgtkV.ToString() +
                            ", RmpRateMWmin = " + cmd.RmpRateMWmin.ToString() +
                            ", PpvsMW = " + cmd.PpvsMW.ToString() +
                            ", PcMW = " + cmd.PcMW.ToString() +
                            ", ChgPr = " + cmd.ChgPr.ToString() +
                            ", PdMW = " + cmd.PdMW.ToString() +
                            ", SOCMaxPct = " + cmd.SOCMaxPct.ToString() +
                            ", SOCMinPct = " + cmd.SOCMinPct.ToString() +
                            ", GCen = " + cmd.GCen.ToString(), false);
                        cmdCount++;
                    }
                }
                else
                {
                    AdjustTextOutput("Invalid JSON", false);
                }

            }
            else
            {
                strDebug = "Failed to call the API. HTTP Status: " + response.StatusCode + ", Reason: " + response.ReasonPhrase;
                AdjustTextOutput(strDebug, false);
            }
        }

        private void AdjustTextOutput(string strText, bool bolClear)
        {
            try
            {
                if (bolClear == true)
                {
                    txtOutputText.Text = string.Empty;
                }
                txtOutputText.Text = txtOutputText.Text + strText + Environment.NewLine;
                txtOutputText.SelectionStart = txtOutputText.TextLength;
                txtOutputText.ScrollToCaret();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }

        private void SetBackColorHighlight(object button, string namemask)
        {
            foreach (var btn in GetAllControls(this, typeof(Button)))
            {
                if (btn.Name.ToLower().Contains(namemask.ToLower()))
                {
                    (btn as Button).BackColor = Color.White;
                    (btn as Button).ForeColor = Color.FromArgb(51, 153, 255);
                }
            }
            Button clickedButton = (Button)button;
            clickedButton.BackColor = Color.FromArgb(51, 153, 255);
            clickedButton.ForeColor = Color.White;
        }

        private IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public class HmacClientHandler : DelegatingHandler
        {
            protected async override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                HttpResponseMessage response = null;
                string reqContentBase64String = string.Empty;
                string reqUri = System.Web.HttpUtility.UrlEncode(request.RequestUri.AbsoluteUri.ToLower());
                string reqHttpMethod = request.Method.Method;

                // calculate unix time
                DateTime reqEpochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan reqTimeSpan = DateTime.UtcNow - reqEpochStart;
                string reqTimeStamp = Convert.ToUInt64(reqTimeSpan.TotalSeconds).ToString();

                string reqNonce = Guid.NewGuid().ToString(Constants.PVSNonce);

                if (request.Content != null)
                {
                    byte[] reqContent = await request.Content.ReadAsByteArrayAsync();
                    MD5 md5 = MD5.Create();
                    byte[] reqContentHash = md5.ComputeHash(reqContent);
                    reqContentBase64String = Convert.ToBase64String(reqContentHash);
                }

                //Creating the raw signature string
                string signatureRawData = String.Format("{0}{1}{2}{3}{4}{5}", Constants.PVSAppKey, reqHttpMethod, reqUri, reqTimeStamp, reqNonce, reqContentBase64String);
                var secretKeyByteArray = Convert.FromBase64String(Constants.PVSHMACKey);
                byte[] signature = Encoding.UTF8.GetBytes(signatureRawData);
                using (HMACSHA256 hmac = new HMACSHA256(secretKeyByteArray))
                {
                    byte[] signatureBytes = hmac.ComputeHash(signature);
                    string reqSignatureBase64String = Convert.ToBase64String(signatureBytes);
                    string reqHeadAuthParam = string.Format("{0}:{1}:{2}:{3}", Constants.PVSAppKey, reqSignatureBase64String, reqNonce, reqTimeStamp);
                    request.Headers.Authorization = new AuthenticationHeaderValue(Constants.PVSScheme, reqHeadAuthParam);
                }
                response = await base.SendAsync(request, cancellationToken);
                return response;
            }
        }

        public string GetObjectNameFromJsonString(string strJson)
        {
            var jsonDef = new { Name = "" };
            var jsonObj = JsonConvert.DeserializeAnonymousType(strJson, jsonDef);
            string jsonName = jsonObj.Name;
            return jsonName;
        }

        public void ProcessResponse(string strObj)
        {
            AdjustTextOutput(strObj, false);
        }

        private void butKeyAdd_Click(object sender, EventArgs e)
        {
            AdjustTextOutput("App Key = " + Constants.PVSAppKey + " (" + Constants.PVSAppKey.Length.ToString() + ")", true);
            AdjustTextOutput("Secret Key = " + Constants.PVSHMACKey + " (" + Constants.PVSHMACKey.Length.ToString() + ")", false);
            Guid g = new Guid();
            string AppKey = string.Empty;
            string SecretKey = string.Empty;
            string EncryptKey = string.Empty;
            int i = 0;
            for (i=0; i<=5; i++)
            {
                g = Guid.NewGuid();
                AppKey = RemoveNonAlphaNumeric(g.ToString());
                using (var cryptoProvider = new RNGCryptoServiceProvider())
                {
                    byte[] secretKeyByteArray = new byte[32]; //256 bit
                    cryptoProvider.GetBytes(secretKeyByteArray);
                    var APIKey = Convert.ToBase64String(secretKeyByteArray);
                    SecretKey = APIKey.ToString();

                    byte[] encrypKeyByteArray = new byte[32]; //256 bit
                    cryptoProvider.GetBytes(encrypKeyByteArray);
                    var ENCKey = Convert.ToBase64String(encrypKeyByteArray);
                    EncryptKey = ENCKey.ToString();

                }
                AdjustTextOutput("App Key = " + AppKey + " (" + AppKey.Length.ToString() + ")", false);
                AdjustTextOutput("Secret Key = " + SecretKey + " (" + SecretKey.Length.ToString() + ")", false);
                AdjustTextOutput("Encryption Key = " + EncryptKey + " (" + EncryptKey.Length.ToString() + ")", false);
            }

        }

        static string RemoveNonAlphaNumeric(string strIn)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strIn.Length; i++)
            {
                if ((strIn[i] >= '0' && strIn[i] <= '9')
                    || (strIn[i] >= 'A' && strIn[i] <= 'z'))
                {
                    sb.Append(strIn[i]);
                }
            }

            return sb.ToString();
        }

        public static string Decrypt(string toDecrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            toDecrypt = toDecrypt.Replace(' ', '+');
            byte[] toDecryptArray = Convert.FromBase64String(toDecrypt);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }
    }

    static class Constants
    {
        public const string PVSWebApiUrl = "http://localhost:16188/api/";
        public const string PVSAppKey = "4d53bce03ec34c0a911182d4c228ee6c";
        public const string PVSHMACKey = "A93reRTUJHsCuQSHR+L3GxqOJyDmQpCgps102ciuabc=";
        public const string PVSEncryptKey = "k6KUvMXYy2I6J5y5hTTgsqG8E2VDL64JhFtPjBB//sU=";
        public const string PVSScheme = "pvss";
        public const string PVSNonce = "N";
    }
}
