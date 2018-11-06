using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 册宝真可爱.Utils
{
    class DateTimeUtil
    {
        private static ConnectionUtil conn = new ConnectionUtil();
        private static CookieContainer cc = new CookieContainer();

        private static int _currentTimeStamp;

        /// <summary>
        /// 获取当前时间的时间戳
        /// </summary>
        public static int CurrentTimeStamp
        {
            get
            {
                DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                DateTimeUtil._currentTimeStamp = (int)(DateTime.Now - d).TotalSeconds;
                return DateTimeUtil._currentTimeStamp;
            }
        }

        public static long GetTimeSpan(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return (long)(time - startTime).TotalSeconds;
        }

        public static DateTime TimeSpanToDateTime(long span)
        {
            DateTime time = DateTime.MinValue;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            time = startTime.AddSeconds(span);
            return time;
        }

        public static DateTime GetServerTime()
        {
            var result = conn.GET("https://shop.48.cn/pai/GetTime", cc);
            var regex = new Regex("\\d{13}");
            var match = regex.Match(result);
            var timeString = match.ToString();
            timeString = timeString.Substring(0, 10);
            var timeInt = Convert.ToInt64(timeString);

            return TimeSpanToDateTime(timeInt);
        }
    }
}
