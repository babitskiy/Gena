using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gena
{
    internal class DSOSerializer
    {
        public static void StartDSOSerializer(string pathToFile, List<DocumentState> lc)
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
