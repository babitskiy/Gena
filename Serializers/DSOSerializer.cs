using Gena.Templates.DSO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Gena.Serializers
{
    internal class DSOSerializer
    {
        public static void StartDSOSerializer(string pathToFile, List<DocumentStateDSO> lc, bool inSingleLine)
        {
            //данные настройки Json сериализатора нужны чтобы русские слова выводились корректно, а не в юникоде
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            // serialize JSON directly to a file
            // проверяем надо ли делать в одну строку жц
            string jsonString = inSingleLine
                //с помощью регуляра убираем лишние пробелы
                ? Regex.Replace(JsonSerializer.Serialize(lc, options).ToString().Replace("\n", "").Replace("\r", ""), @"\s+", " ")
                : JsonSerializer.Serialize(lc, options).ToString();

            File.WriteAllText(pathToFile, jsonString);
        }
    }
}
