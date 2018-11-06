using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 册宝真可爱.Entitys;
using 册宝真可爱.Enums;

namespace 册宝真可爱.Utils
{
    struct TheaterUtil
    {
        public static Theater JXL
        {
            get
            {
                Theater t = new Theater(TheaterType.嘉兴路, Province.上海, City.上海,
                    "虹口区嘉兴路267号（靠近哈尔滨路）");
                t.City = City.上海;
                return t;
            }
        }

        public static Theater UT
        {
            get
            {
                Theater t = new Theater(TheaterType.悠唐, Province.北京, City.北京,
                    "朝阳区三丰北里2号楼 悠唐广场4层420（近朝阳门）");
                t.City = City.北京;
                return t;
            }
        }

        public static Theater ZT
        {
            get
            {
                Theater t = new Theater(TheaterType.中泰, Province.广东, City.广州,
                    "天河区林和西路161号中泰国际广场3F");
                t.City = City.广州;
                return t;
            }
        }

        public static Theater YLC
        {
            get
            {
                Theater t = new Theater(TheaterType.豫珑城, Province.辽宁, City.沈阳,
                    "沈河区北中街路116号 SHY48星梦剧院");
                t.City = City.沈阳;
                return t;
            }
        }

        public static Theater GR
        {
            get
            {
                Theater t = new Theater(TheaterType.国瑞, Province.重庆, City.重庆,
                    "南岸区烟雨路国瑞中心1层CKG48星梦剧院");
                t.City = City.重庆;
                return t;
            }
        }
    }
}
