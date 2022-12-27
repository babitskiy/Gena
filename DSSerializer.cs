using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Gena
{
    internal class DSSerializer
    {
        public static void StartDSSerializer(string pathToFile, StatesConfiguration lc)
        {
            var lcNew = SerializeToString(lc);
            using FileStream fstream = new FileStream(pathToFile, FileMode.OpenOrCreate);

            // преобразуем строку в байты
            var buffer = Encoding.Default.GetBytes(lcNew);
            // запись массива байтов в файл
            fstream.Write(buffer);
        }

        private static string SerializeToString<T>(T value)
        {
            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value);
                return stream.ToString();
            }
        }
    }
}