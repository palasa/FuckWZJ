using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class DateTimeUtil
    {
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
    }
}
