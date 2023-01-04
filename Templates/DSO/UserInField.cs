using System.Text.Json.Serialization;

namespace Gena.Templates.DSO
{
    internal class UserInField
    {
        [JsonPropertyName("field")]
        public string Field { get; set; }

        [JsonPropertyName("fieldName")]
        public string FieldName { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("fieldSettings")]
        public List<FieldSettingForUserInField> FieldSettings { get; set; }
    }
}
