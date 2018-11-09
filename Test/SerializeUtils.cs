using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test
{
    class SerializeUtils
    {

        public static bool Serialize( Object data , string fileName="allLives.data" )
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    XmlSerializer bf = new XmlSerializer(typeof(List<Live>));
                    bf.Serialize(fs, data);
                }
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine( e.Message );
                return false;
            }
        }

        public static Object DeSerialize ( string fileName= "allLives.data")
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    XmlSerializer bf = new XmlSerializer( typeof (List<Live>) );
                    return bf.Deserialize(fs);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
