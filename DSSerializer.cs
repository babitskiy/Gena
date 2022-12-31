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

    // СТАРАЯ РЕАЛИЗАЦИЯ СЕРИАЛИЗАЦИИ - она добавляла бесполезную строку в верх xml - файла
    /*internal class DSSerializer
    {
        public static void StartDSSerializer(string pathToFile, StatesConfiguration lc)
        {
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
    }*/
}