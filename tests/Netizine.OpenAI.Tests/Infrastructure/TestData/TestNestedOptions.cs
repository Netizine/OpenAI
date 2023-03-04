namespace OpenAI.Tests.Infrastructure.TestData
{
    using Newtonsoft.Json;
    using OpenAI;

    public class TestNestedOptions : INestedOptions
    {
        [JsonProperty("a_long")]
        public long? ALong { get; set; }

        [JsonProperty("a_string")]
        public string AString { get; set; }
    }
}
