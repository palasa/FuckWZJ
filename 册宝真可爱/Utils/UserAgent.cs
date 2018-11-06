using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 册宝真可爱.Utils
{
    class UserAgent
    {
        private static Random r = new Random();

        private static Dictionary<string, string> userAgents;

        public static Dictionary<string, string> UserAgents
        {
            get
            {
                UserAgent.userAgents = new Dictionary<string, string>();
                UserAgent.userAgents.Add("edge 25.10586.0.0", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2486.0 Safari/537.36 Edge/13.10586");
                UserAgent.userAgents.Add("chrome 44", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36");
                UserAgent.userAgents.Add("firefox 44.0.2", "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:44.0) Gecko/20100101 Firefox/44.0");
                UserAgent.userAgents.Add("opera beta 37.0", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.87 Safari/537.36 OPR/37.0.2178.31 (Edition beta)");
                return UserAgent.userAgents;
            }
        }

        public static string GetRandomUserAgent()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            foreach (KeyValuePair<string, string> current in UserAgent.UserAgents)
            {
                list.Add(current);
            }
            return list[UserAgent.r.Next(list.Count - 1)].Value;
        }
    }
}
