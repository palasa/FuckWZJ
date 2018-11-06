using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 册宝真可爱.Exceptions
{
    class CanNotOpenLoginPageException : Exception
    {
        public CanNotOpenLoginPageException() : base("无法打开登录页面")
        {
        }
    }
}
