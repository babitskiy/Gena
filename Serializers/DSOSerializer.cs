using Gena.Templates.DSO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Gena.Serializers
{
    internal class DSOSerializer
    {
        public static void StartDSOSerializer(string pathToFile, List<DocumentStateDSO> lc)
        {
            //данные настройки Json сериализатора нужны чтобы русские слова выводились корректно, а не в юникоде
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            // serialize JSON directly to a file
            string jsonString = JsonSerializer.Serialize(lc, options);
            File.WriteAllText(pathToFile, jsonString);
        }
    }
}
