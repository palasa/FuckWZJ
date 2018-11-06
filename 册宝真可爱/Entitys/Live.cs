using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 册宝真可爱.Entitys;

namespace 册宝真可爱.Entitys
{
    /// <summary>
    /// 公演
    /// </summary>
    class Live
    {
        /// <summary>
        /// 演出地点
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// 所属组合
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// 所属队伍
        /// </summary>
        public Team Team { get; set; }

        /// <summary>
        /// 公演开始时间
        /// 年 / 月 / 日 / 时 / 分 
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 票号
        /// https://shop.48.cn/tickets/item/2618 中的 2618
        /// </summary>
        public int TicketNumber { get; set; }


        public LiveDetail LiveDetail { get; set; }

        public string TicketUrl
        {
            get
            {
                return "https://shop.48.cn/tickets/item/" + this.TicketNumber;
            }
        }

        public Live()
        {

        }

        public Live(Location location, Group group, Team team, DateTime startTime ,int ticketNumber )
        {
            this.Location = location;
            this.Group = group;
            this.Team = team;
            this.StartTime = startTime;
            this.TicketNumber = ticketNumber;
        }

        public override string ToString()
        {
            return string.Format("{0}组合 Team {1} 将于 {2} 在 {3} 处进行演出 , 门票网址：{4}",
                Group.GroupName , Team.TeamName , StartTime , Location , TicketUrl );
        }

        //public void SetGroupByTeam()
        //{
        //    if ( this.Team !=null && this.Team.TeamId != null)
        //    {
        //        switch( this.Team )
        //    }
        //}
    }
}
