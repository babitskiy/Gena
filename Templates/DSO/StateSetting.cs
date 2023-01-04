using System.Text.Json.Serialization;

namespace Gena.Templates.DSO
{
    internal class StateSetting
    {
        [JsonPropertyName("userInField")]
        public List<UserInField> UserInField { get; set; }

        [JsonPropertyName("userInGroup")]
        public List<UserInGroup> UserInGroup { get; set; }

        [JsonPropertyName("fieldSettingsByState")]
        public List<FieldSettingsByState> FieldSettingsByState { get; set; }
    }
}
