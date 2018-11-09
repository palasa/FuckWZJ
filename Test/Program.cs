using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var pageContent = "11月8日预备生公演时间为19：30，《NEXT IDOL PROJECT》剧场公演 本场公演将进行网络直播。";
            //var regexp = new Regex(11 + "月" + 8 + "日" + ".{5,20}为\\d{2}[:：]\\d{2}");

            //Match match = regexp.Match(pageContent);
            //var detailString = match.ToString();
            //Console.WriteLine( detailString );

            //var str = "11月10日B队公演时间为19:00，《B A FIGHTER》剧场公演  本场公演将进行网络直播。 ";
            //Console.WriteLine( str.Contains("E") );

            //var str = "11月4日NIII队公演时间为19:00，《Fiona.N》剧场公演，SNH48 GROUP第五届年度金曲大赏BEST50 速报，本场公演将进行网络直播 ";

            //var regStr = 11 + "月" + 4 + "日"
            //    + "([A-Z]{1,4}|预备生|).{1,20}为\\d{2}[:：]\\d{2}.{10,60}网络直播";
            //var regexp = new Regex(regStr);

            //var result = regexp.Matches(str);
            //foreach (var item in result)
            //{
            //    Console.WriteLine( item.ToString() );
            //}

            //var timeInt = 1541514123000;

            //// https://shop.48.cn/pai/GetTime
            //// "\/Date(1541514476000)\/"

            //Console.WriteLine( DateTimeUtil.TimeSpanToDateTime(1541514123000/1000) );
            var now = DateTime.Now;

            var allLives = new List<Live> {
                new Live { StartTime = now, TicketNumber = 123 } ,
                new Live { StartTime = now.AddHours(1), TicketNumber = 456 } ,
            };

            Console.WriteLine(SerializeUtils.Serialize(allLives));

        }
    }
}
