using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 册宝真可爱.Entitys;

namespace 册宝真可爱.Utils
{
    struct GroupUtil
    {
        public static Group SNH48 { get { return new Group(1, "SNH48", TeamColor.SNH48, TeamUtil.SNH48Teams); } }
        public static Group BEJ48 { get { return new Group(2, "BEJ48", TeamColor.BEJ48, TeamUtil.BEJ48Teams); } }
        public static Group GNZ48 { get { return new Group(3, "GNZ48", TeamColor.GNZ48, TeamUtil.GNZ48Teams); } }
        public static Group SHY48 { get { return new Group(4, "SHY48", TeamColor.SHY48, TeamUtil.SHY48Teams); } }
        public static Group CKG48 { get { return new Group(5, "CKG48", TeamColor.CKG48, TeamUtil.CKG48Teams); } }

        public static Group UnKnownGroup { get { return new Group(-1, "UnKnownGroup", TeamColor.Unknown, null ); } }

        /// <summary>
        /// 通过城市获取组合
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public static Group GetGroupByCityName( string cityName )
        {
            switch ( cityName)
            {
                case "上海": return SNH48;
                case "北京": return BEJ48;
                case "广州": return GNZ48;
                case "沈阳": return SHY48;
                case "重庆": return CKG48;
                default: return UnKnownGroup;
            }
        }

        public static Color GetGroupColorByGroupId( int groupId )
        {
            switch ( groupId )
            {
                case 1: return TeamColor.SNH48;
                case 2: return TeamColor.BEJ48;
                case 3: return TeamColor.GNZ48;
                case 4: return TeamColor.SHY48;
                case 5: return TeamColor.CKG48;
                default:return TeamColor.Unknown;
            }
        }

        public List<Group> AllGroups
        {
            get
            {
                return new List<Group> { SNH48, BEJ48, GNZ48, SHY48, CKG48 };
            }
        }

    }
}
