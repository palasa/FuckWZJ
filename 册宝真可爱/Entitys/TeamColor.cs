using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 册宝真可爱.Entitys
{
    public struct TeamColor
    {
        #region Groups
        public static Color SNH48
        {
            get
            {
                return Color.FromArgb(144, 210, 245);
            }
        }

        public static Color BEJ48
        {
            get
            {
                return Color.FromArgb(255, 35, 112);
            }
        }

        public static Color GNZ48
        {
            get
            {
                return Color.FromArgb(170, 201, 19);
            }
        }

        public static Color SHY48
        {
            get
            {
                return Color.FromArgb(226, 0, 206);
            }
        }

        public static Color CKG48
        {
            get
            {
                return Color.FromArgb(157, 97, 37);
            }
        }
        #endregion


        #region SNH48
        public static Color SII
        {
            get
            {
                return Color.FromArgb(140, 200, 230);
            }
        }

        public static Color NII
        {
            get
            {
                return Color.FromArgb(175, 135, 180);
            }
        }

        public static Color HII
        {
            get
            {
                return Color.FromArgb(242, 152, 0);
            }
        }

        public static Color X
        {
            get
            {
                return Color.FromArgb(180, 210, 0);
            }
        }

        public static Color XII
        {
            get
            {
                return Color.FromArgb(0, 170, 150);
            }
        }

        public static Color FT
        {
            get
            {
                return Color.FromArgb(65, 173, 1);
            }
        }
        #endregion


        #region BEJ48
        public static Color B
        {
            get
            {
                return Color.FromArgb(228, 56, 106);
            }
        }

        public static Color E
        {
            get
            {
                return Color.FromArgb(11, 202, 195);
            }
        }

        public static Color J
        {
            get
            {
                return Color.FromArgb(45, 133, 196);
            }
        }
        #endregion


        #region GNZ48
        public static Color G
        {
            get
            {
                return Color.FromArgb(171, 203, 18);
            }
        }

        public static Color NIII
        {
            get
            {
                return Color.FromArgb(255, 215, 0);
            }
        }        

        public static Color Z
        {
            get
            {
                return Color.FromArgb(255, 135, 189);
            }
        }
        #endregion

        #region SHY48
        public static Color SIII
        {
            get
            {
                return Color.FromArgb(208, 67, 146);
            }
        }

        public static Color HIII
        {
            get
            {
                return Color.FromArgb(117, 48, 142);
            }
        }
        #endregion

        #region CKG48
        public static Color C
        {
            get
            {
                return Color.FromArgb(228, 146, 88);
            }
        }

        public static Color K
        {
            get
            {
                return Color.FromArgb(252, 94, 71);
            }
        }
        #endregion


        /// <summary>
        /// 预备生
        /// </summary>
        public static Color ReserveTeam
        {
            get
            {
                return Color.Gray;
            }
        }

        /// <summary>
        /// 特殊 , 联合 , ...
        /// </summary>
        public static Color Unknown
        {
            get
            {
                return Color.White;
            }
        }
    }
}
