using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 册宝真可爱.Utils
{
    class EnumHepler
    {
        /// <summary>
        /// 将枚举转成字段，键为枚举值， 值为枚举的注解
        /// </summary>
        /// <typeparam name="T">枚举的数据类型</typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> EnumToDictionary<T>()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            if (!typeof(T).IsEnum)
            {
                return dict;
            }
            string desc = string.Empty;
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var attrs = item.GetType().GetField(item.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    DescriptionAttribute descAttr = attrs[0] as DescriptionAttribute;
                    desc = descAttr.Description;
                }
                dict.Add(Convert.ToInt32(item), desc);
            }
            return dict;
        }
    }
}
