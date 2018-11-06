using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 册宝真可爱.Entitys
{
    /// <summary>
    /// 团体
    /// BEJ48 , SNH48 , GNZ48 , ...
    /// </summary>
    public class Group
    {
        public int? GroupId { get; set; }

        public string GroupName { get; set; }

        public Color GroupColor { get; set; }

        public List<Team> Teams { get; set; }

        public Group()
        {

        }

        public Group(int? groupId , string groupName , Color groupColor , List<Team> teams )
        {
            this.GroupId = groupId;
            this.GroupName = groupName;
            this.GroupColor = groupColor;
            this.Teams = teams;
        }
    }
}
