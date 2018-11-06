using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 册宝真可爱.Enums;

namespace 册宝真可爱.Entitys
{
    class LiveDetail
    {
        /// <summary>
        /// 开始的详细时间，具体到 时 / 分
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 场次类型 
        /// </summary>
        public LiveType LiveType { get; set; }

        /// <summary>
        /// 详细描述
        /// </summary>
        public String Detail { get; set; }


        /// <summary>
        /// 是否有余票
        /// [0] VIP
        /// [1] 站
        /// [2] 普
        /// </summary>
        public bool[] RemainingTickets { get; set; }
    }
}
