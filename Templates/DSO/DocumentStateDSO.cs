using System.Text.Json.Serialization;

namespace Gena.Templates.DSO
{
    internal class DocumentStateDSO
    {

        [JsonPropertyName("docState")]
        public int DocState { get; set; }

        [JsonPropertyName("stateName")]
        public string StateName { get; set; }

        [JsonPropertyName("stateSettings")]
        public List<StateSetting> StateSettings { get; set; }
    }
}
