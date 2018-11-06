using 册宝真可爱.Entitys;
using 册宝真可爱.Enums;

namespace 册宝真可爱.Entitys
{

    /// <summary>
    /// 演出地点
    /// </summary>
    public class Location
    {
        public Province? Province { get; set; }

        public City? City { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0}省 {1}市 {2}" , Province.ToString() , City.ToString() , Address);
        }
    }
}