using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 册宝真可爱.Enums;

namespace 册宝真可爱.Entitys
{
    class Theater : Location
    {
        public TheaterType? TheaterType { get; set; }

        public Theater()
        {

        }

        public Theater(TheaterType? theaterType , Province? province, City? city, string address )
        {
            this.Province = province;
            this.City = City;
            this.Address = address;
            this.TheaterType = theaterType;
        }
    }
}
