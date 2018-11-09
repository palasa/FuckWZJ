using System;
using System.Drawing;
using 册宝真可爱.Utils;

namespace 册宝真可爱.Entitys
{

    /// <summary>
    /// 队伍
    /// G , NII , C , ...
    /// </summary>
    [Serializable]
    public class Team
    {
        public int? TeamId { get; set; }

        public string TeamName { get; set; }

        public Color TeamColor { get; set; }

        public string TeamColorHTMLString { get; set; }

        public Team()
        {

        }

        public Team( int? teamId, string teamName , Color teamColor )
        {
            this.TeamId = teamId;
            this.TeamName = teamName;
            this.TeamColor = teamColor;
            this.TeamColorHTMLString = ColorTranslator.ToHtml(this.TeamColor);
        }

        public override string ToString()
        {
            return string.Format("队伍编号:{0},队伍名称:{1},队伍颜色:{2}" ,
                this.TeamId , this.TeamName , this.TeamColor);
        }

    }
}