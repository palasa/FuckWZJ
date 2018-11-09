using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using 册宝真可爱.Entitys;

namespace 册宝真可爱.Utils
{
    class SerializeUtils
    {

        public static void Serialize<T>( T data , string fileName = "live_data.xml")
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create ))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(fs, data);
            }            
        }

        public static T DeSerialize<T> ( string fileName = "live_data.xml")
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T) );
                return (T)xs.Deserialize(fs);
            }
        }
    }
}
