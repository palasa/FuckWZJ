using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    /// <summary>
    /// 公演
    /// </summary>
    [Serializable]
    public class Live
    {
       

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

    }
}
