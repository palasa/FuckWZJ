using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using 册宝真可爱.Entitys;
using 册宝真可爱.Enums;

namespace 册宝真可爱.Utils
{
    static class LiveUtil
    {
        private static CookieContainer cc = new CookieContainer();
        private static ConnectionUtil util = new ConnectionUtil();
        public static List<Live> allLives;

        public static Live GetLive(string city , string month, string day , string team, string ticketNumber)
        {
            Live live = new Live();
            setLiveLocation(live, city);
            setLiveTeam(live, team);
            setLiveGroup(live, team);
            live.StartTime = new DateTime(
                DateTime.Now.Year, 
                Convert.ToInt32(month),
                Convert.ToInt32(day)
            );
            live.TicketNumber = Convert.ToInt32 ( ticketNumber.Trim() );

            if( live.Group.GroupName == GroupUtil.UnKnownGroup.GroupName )
            {
                live.Group = GroupUtil.GetGroupByCityName(live.Location.City.ToString());
            }
            

            return live;
        }

        private static void setLiveGroup(Live live, string team)
        {
            if ( team.IndexOf("S队") > -1 || team.IndexOf("N队") > -1
                || team.IndexOf("H队") > -1 || team.IndexOf("X队") > -1
                || team.IndexOf("XII队") > -1 || team.IndexOf("FT队") > -1
            )
            {
                live.Group = GroupUtil.SNH48;
            }
            else if(team.IndexOf("G队") > -1 || team.IndexOf("NIII队") > -1 || team.IndexOf("Z队") > -1 )
            {
                live.Group = GroupUtil.GNZ48;
            }
            else if (team.IndexOf("B队") > -1 || team.IndexOf("E队") > -1 || team.IndexOf("J队") > -1)
            {
                live.Group = GroupUtil.BEJ48;
            }
            else if (team.IndexOf("SIII队") > -1 || team.IndexOf("HIII队") > -1 )
            {
                live.Group = GroupUtil.SHY48;
            }
            else if (team.IndexOf("C") > -1 || team.IndexOf("K") > -1)
            {
                live.Group = GroupUtil.CKG48;
            }
            else
            {
                live.Group = GroupUtil.UnKnownGroup;
            }
        }
        

        public static void SetDetails ( IEnumerable<Live> lives )
        {
            foreach (var live in lives)
            {
                live.LiveDetail = GetLiveDetailByLiveId(live.TicketNumber);
            }
        }

        public static Live GetLiveById(int liveId )
        {
            return allLives.Find(live => live.TicketNumber == liveId);
        }

        private static bool[] getRemainTicketsTypeFromPageDetail( string detailPage)
        {
            return null;
        }

        public static LiveDetail GetLiveDetailByLiveId(int liveId)
        {
            

            Live live = GetLiveById(liveId);
            LiveDetail detail = new LiveDetail();
            string detailPage = util.GET("https://shop.48.cn/tickets/item/" + liveId , cc );
            detailPage = detailPage.Replace("\\", "");

            

            /* 无VIP
             * 
             * <span class="is_4">
                                <em id="seattype2" data-xmgb="0" data-price="168" data-seattype="2" data-oldprice="168" data-integral="-1">VIP座票  <i></i></em>
                                <em class="ticketsbuy seattypebg3 clickem" id="seattype3" data-xmgb="3" data-price="80" data-seattype="3" data-oldprice="80" data-integral="-1">普通座票<i></i></em>
                                <em class="ticketsbuy seattypebg4" id="seattype4" data-xmgb="1" data-price="80" data-seattype="4" data-oldprice="80" data-integral="-1">普通站票<i></i></em>

                </span>
             * 
             * 无站
             * <span class="is_4">
                                <em class="ticketsbuy seattypebg2 " id="seattype2" data-xmgb="1" data-price="168" data-seattype="2" data-oldprice="168" data-integral="-1">VIP座票<i></i></em>
                                <em class="ticketsbuy seattypebg3 " id="seattype3" data-xmgb="1" data-price="80" data-seattype="3" data-oldprice="80" data-integral="-1">普通座票<i></i></em>
                                <em id="seattype4" data-xmgb="1" data-price="80" data-seattype="4" data-oldprice="80" data-integral="-1">普通站票  <i></i></em>

                </span>
             */
            // 读取剩余票务
            var start = detailPage.IndexOf("<span class=\"is_4\">");
            var end = detailPage.LastIndexOf("</em>");
            var ticketContent = detailPage.Substring(start, end - start+10);
            var reg0 = new Regex("<em.{100,200}</em>");
            var matchString0 = string.Empty;
            var remainTicketArray = new bool[3];
            foreach (var item in reg0.Matches(ticketContent) )
            {
                var emString = item.ToString();
                // VIP
                if (emString.IndexOf("seattype2") > -1)
                {
                    // 没卖光
                    remainTicketArray[0] = emString.IndexOf("class") > -1;
                }
                // 站
                else if (emString.IndexOf("seattype4") > -1)
                {
                    remainTicketArray[1] = emString.IndexOf("class") > -1;
                }
                // 普
                else if (emString.IndexOf("seattype3") > -1)
                {
                    remainTicketArray[2] = emString.IndexOf("class") > -1;
                }
            }
            detail.RemainingTickets = remainTicketArray;
            


            int start1 = detailPage.IndexOf("<div class=\"lb_1\">");
            int end1 = detailPage.IndexOf("<!--支付弹层-开始-->");
            var pageContent = detailPage.Substring(start1, end1 - start1);

            

            var regex = new Regex(@"<(.|\n)+?>");
            pageContent = regex.Replace(pageContent, "");
            pageContent = pageContent.Replace(@"&nbsp;", "").Replace("\n" , "").Replace("\r" , "");

            

            string timeString = string.Empty;    
            string detailString = string.Empty;

            if ( live.Group.GroupName == "SHY48")
            {
                // SHY48星梦剧院将在2018年11月10日举办SHY48 TEAM SIII《Idol.S》剧场公演，机会难得哦，望广大粉丝们多多捧场哦！ 
                // 公演时间为14: 00，本场公演将网络直播。
                //  SHY48星梦剧院将在2018年11月9日举办SHY48 预备生《拾光寄》剧场公演，机会难得哦，望广大粉丝们多多捧场哦
                // 公演时间为19: 00，本场公演将网络直播。

                int start2 = pageContent.IndexOf("公演时间为");
                timeString = pageContent.Substring(start2+5, 5);
                detail.LiveType = LiveType.普通场;

                int start3 = pageContent.IndexOf("SHY48星梦剧院将在");
                int end3 = pageContent.IndexOf("本场公演将网络直播");
                detailString = pageContent.Substring(start3, end3 - start3 + 11);

                detailString = detailString.Replace("捧场哦！", "捧场哦!\n\r");


                if (detailString.IndexOf("预备")>-1)
                {
                    live.Team = TeamUtil.Reserve;
                }
            }
            else
            {
                // 获取开始时间，      
                // 11月7日H队公演时间为19:30，限定实名认证检票，本场公演将进行网络直播
                // 11月10日X队公演时间为14:00，祁静生日主题公演随机抽选场，限定实名认证检票，本场公演将进行网络直播
                // 11月11日X队公演时间为14:00，限定实名认证检票，本场公演将进行网络直播
                // 11月11日N队公演时间为19:00，限定实名认证检票，本场公演将进行网络直播

                // 11月10日E队公演时间为14:00，《UNIVERSE》剧场公演张笑盈生日公演限定实名认证检票本场公演将进行网络直播。
                // 11月8日预备生公演时间为19:30，《NEXT IDOL PROJECT》剧场公演 本场公演将进行网络直播。 

                // 11月11日NIII队公演时间为19:00，《Fiona.N》剧场公演，本场公演将进行网络直播  
                // 11月10日G队公演时间为19:00，《双面偶像》剧场公演，本场公演将进行网络直播 
                // 11月3日Z队公演时间为14:00，《三角函数》龙亦瑞生日公演，限定实名认证检票，本场公演将进行网络直播
                // 11月4日NIII队公演时间为19:00，《Fiona.N》剧场公演，SNH48 GROUP第五届年度金曲大赏BEST50 速报，本场公演将进行网络直播 

                // 11月10日公演时间为14:00，Team C《梦想的旗帜》剧场公演，曾佳生日公演，本场公演将网络直播 。
                // 11月10日公演时间为19:00，Team K《美丽世界》剧场公演，本场公演将网络直播。 


                // todo: 同日两场公演时出问题
                var regStr = live.StartTime.Month + "月" + live.StartTime.Day + "日"
                + "([A-Z]{1,4}|预备生|).{1,20}为\\d{2}[:：]\\d{2}.{1,53}网络直播";
                var regexp = new Regex(regStr);

                MatchCollection matches = regexp.Matches(pageContent);
                string tString = string.Empty;

                // 每天只有一场公演
                if (matches.Count == 1)
                {
                    tString = matches[0].ToString()  ;
                }
                // 每天有多场公演
                else
                {
                    for (int i=0;i<matches.Count; i++)
                    {
                        var matchString = matches[i].ToString();

                        // 重庆 Team C , 其他 S队 / NIII队
                        if (matchString.Contains(live.Team.TeamName+"队")|| matchString.Contains("Team "+ live.Team.TeamName))
                        {
                            tString = matchString;
                        }
                        // tString += matchString + "|" + live.Team + "\n";
                    }
                }



                int start2 = tString.IndexOf("公演时间为");
                timeString = tString.Substring(start2 + 5, 5);

                if (tString.IndexOf("抽选") > -1)
                {
                    detail.LiveType = LiveType.抽选场;
                }
                else if (tString.IndexOf("实名") > -1)
                {
                    detail.LiveType = LiveType.实名场;
                }
                else
                {
                    detail.LiveType = LiveType.普通场;
                }


                detailString = tString;

            }

            int hour = Convert.ToInt32(timeString.Substring(0, 2));
            int minute = Convert.ToInt16(timeString.Substring(3, 2));
            DateTime startTime = new DateTime(
                live.StartTime.Year ,
                live.StartTime.Month ,
                live.StartTime.Day ,
                hour ,
                minute ,
                0    
            );

            detail.StartTime = startTime;

            // detail.Detail = detailString;
            detail.Detail = detailString ;
          

            // detail.Detail = detailString;
            return detail;
        }

        private static void setLiveLocation( Live live, string city)
        {
            switch (city)
            {
                case "上海":
                    live.Location = TheaterUtil.JXL;
                    break;
                case "广州":
                    live.Location = TheaterUtil.ZT;
                    break;
                case "北京":
                    live.Location = TheaterUtil.UT;
                    break;
                case "沈阳":
                    live.Location = TheaterUtil.YLC;
                    break;
                case "重庆":
                    live.Location = TheaterUtil.GR;
                    break;
                default:
                    Location unknownLocation = new Location();
                    unknownLocation.Province = Enums.Province.其他;
                    unknownLocation.City = Enums.City.其他;
                    unknownLocation.Address = "未知";
                    live.Location = unknownLocation;
                    break;
            }
        }

        private static void setLiveTeam( Live live , string team )
        {
            // snh
            if (team.IndexOf("S队") > -1)
            {
                live.Team = TeamUtil.S;
            }
            else if (team.IndexOf("N队") > -1)
            {
                live.Team = TeamUtil.N;
            }
            else if (team.IndexOf("H队") > -1)
            {
                live.Team = TeamUtil.H;
            }
            else if (team.IndexOf("X队") > -1)
            {
                live.Team = TeamUtil.X;
            }
            else if (team.IndexOf("XII队") > -1)
            {
                live.Team = TeamUtil.XII;
            }
            else if (team.IndexOf("FT队") > -1)
            {
                live.Team = TeamUtil.FT;
            }

            // bej
            else if (team.IndexOf("B队") > -1)
            {
                live.Team = TeamUtil.B;
            }
            else if (team.IndexOf("E队") > -1)
            {
                live.Team = TeamUtil.E;
            }
            else if (team.IndexOf("J队") > -1)
            {
                live.Team = TeamUtil.J;
            }

            // gnz
            else if (team.IndexOf("G队") > -1)
            {
                live.Team = TeamUtil.G;
            }
            else if (team.IndexOf("NIII队") > -1)
            {
                live.Team = TeamUtil.NIII;
            }
            else if (team.IndexOf("Z队") > -1)
            {
                live.Team = TeamUtil.Z;
            }

            // shy
            else if (team.IndexOf("SIII队") > -1)
            {
                live.Team = TeamUtil.SIII;
            }
            else if (team.IndexOf("HIII队") > -1)
            {
                live.Team = TeamUtil.HIII;
            }

            // ckg
            else if (team.IndexOf("C队") > -1)
            {
                live.Team = TeamUtil.C;
            }
            else if (team.IndexOf("K队") > -1)
            {
                live.Team = TeamUtil.K;
            }

            else if (team.IndexOf("预备") > -1)
            {
                live.Team = TeamUtil.Reserve;
            }
            else if (team.IndexOf("联合") > -1)
            {
                live.Team = TeamUtil.Union;
            }

            // 其他
            else
            {
                live.Team = TeamUtil.UnKnownTeam;
            }
        }
    }
}
