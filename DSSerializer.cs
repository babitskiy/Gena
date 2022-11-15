using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gena
{
    internal class DSSerializer
    {
        public static void StartDSSerializer(string pathToFile, StatesConfiguration lc)
        {
            //create .xml file and enter the lc there
            //var lcNew = lc.ToXmlString();
            //XmlSerializer lcForOut = new XmlSerializer(typeof(StatesConfiguration));
            //FileStream file = File.Create(pathToFile);
            //lcForOut.Serialize(file, lc);

            //XmlSerializer xml = new XmlSerializer(typeof(StatesConfiguration));
            //using (FileStream fs = new FileStream(pathToFile, FileMode.OpenOrCreate))
            //{
            //    xml.Serialize(fs, lc);
            //}

            var lcNew = lc.ToXmlString();
            using (FileStream fstream = new FileStream(pathToFile, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(lcNew);
                // запись массива байтов в файл
                fstream.Write(buffer);
            }
        }
    }
    public static class XmlTools
    {
        public static string ToXmlString<T>(this T input)
        {
            using (var writer = new StringWriter())
            {
                input.ToXml(writer);
                return writer.ToString();
            }
        }
        public static void ToXml<T>(this T objectToSerialize, Stream stream)
        {
            new XmlSerializer(typeof(T)).Serialize(stream, objectToSerialize);
        }

        public static void ToXml<T>(this T objectToSerialize, StringWriter writer)
        {
            new XmlSerializer(typeof(T)).Serialize(writer, objectToSerialize);
        }
    }
}