using System.Text.Json.Serialization;

namespace OpenAI.Mock.Models
{
    public class Categories
    {
        [JsonPropertyName("hate")]
        public bool Hate { get; set; }

        [JsonPropertyName("hatethreatening")]
        public bool HateThreatening { get; set; }

        [JsonPropertyName("selfharm")]
        public bool SelfHarm { get; set; }

        [JsonPropertyName("sexual")]
        public bool Sexual { get; set; }

        [JsonPropertyName("sexualminors")]
        public bool SexualMinors { get; set; }

        [JsonPropertyName("violence")]
        public bool Violence { get; set; }

        [JsonPropertyName("violencegraphic")]
        public bool ViolenceGraphic { get; set; }
    }
}
