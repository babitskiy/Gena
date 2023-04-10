using System.Text.Json.Serialization;

namespace Gena.Templates.DSO
{
    internal class UserInGroup
    {
        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }

        [JsonPropertyName("groupName")]
        public string GroupName { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("fieldSettings")]
        public List<FieldSettingForUserInGroup> FieldSettings { get; set; }
    }
}
