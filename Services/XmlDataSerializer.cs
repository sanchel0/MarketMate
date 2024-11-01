using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services
{
    public class XmlDataSerializer
    {
        public static string[] Serialize<T>(List<T> data, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }

            string[] lines = File.ReadAllLines(filePath);

            return lines;
        }

        public static List<T> Deserialize<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            List<T> data = new List<T>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                data = (List<T>)serializer.Deserialize(reader);
            }
            return data;
        }
    }
}
