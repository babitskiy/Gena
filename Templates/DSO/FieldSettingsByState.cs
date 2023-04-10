using System.Text.Json.Serialization;

namespace Gena.Templates.DSO
{
    internal class FieldSettingsByState
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }

        [JsonPropertyName("readOnly")]
        public bool ReadOnly { get; set; }

        //конструктор класса
        public FieldSettingsByState(string internalName, int parameter)
        {
            Name = internalName;
            switch (parameter)
            {
                case 0:
                    Hidden = true;
                    break;
                case 1:
                    ReadOnly = true;
                    break;
                case 3:
                    Required = true;
                    break;
                default:
                    break;
            }
        }
    }
}
