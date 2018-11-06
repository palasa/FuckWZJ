using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 册宝真可爱.Utils
{
    public class ConnectionUtil
    {
        
        public string GET(string url, CookieContainer cc)
        {
            string result;
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = UserAgent.GetRandomUserAgent();
                httpWebRequest.CookieContainer = cc;
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string text = streamReader.ReadToEnd();
                responseStream.Close();
                result = text;
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }

        public Stream GetStream(string url, CookieContainer cc)
        {
            Stream result;
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = UserAgent.GetRandomUserAgent();
                httpWebRequest.CookieContainer = cc;
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                Stream responseStream = httpWebResponse.GetResponseStream();
                result = responseStream;
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public string POST(string url, CookieContainer cc, string postData, int timeout = 0)
        {
            string result;
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                httpWebRequest.Method = "POST";
                httpWebRequest.UserAgent = UserAgent.GetRandomUserAgent();
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                if (timeout != 0)
                {
                    httpWebRequest.Timeout = timeout;
                }
                httpWebRequest.CookieContainer = cc;
                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string text = streamReader.ReadToEnd();
                responseStream.Close();
                result = text;
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }

        public static string GetFullPageURL(string url)
        {
            string result;
            try
            {
                Regex regex = new Regex("(shop\\.48\\.cn/tickets/item/\\d{2,})|(^\\d{2,}$)");
                if (!regex.IsMatch(url))
                {
                    result = string.Empty;
                }
                else
                {
                    int num = url.LastIndexOf("/");
                    string text = url.Substring(num + 1);
                    if (text.Length < 3)
                    {
                        result = string.Empty;
                    }
                    else
                    {
                        string text2 = "http://shop.48.cn/tickets/item/" + text;
                        result = text2;
                    }
                }
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }
    }
}
