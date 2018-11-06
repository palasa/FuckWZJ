using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 册宝真可爱.Enums
{
    enum GroupType
    {
        [DescriptionAttribute("全部")]
        ALL = 0 ,

        [DescriptionAttribute("SNH48")]
        SNH48 = 1,

        [DescriptionAttribute("BEJ48")]
        BEJ48 = 2,

        [DescriptionAttribute("GNZ48")]
        GNZ48 = 3,

        [DescriptionAttribute("SHY48")]
        SHY48 = 4,

        [DescriptionAttribute("CKG48")]
        CKG48 = 5
    }
}
