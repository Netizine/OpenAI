namespace OpenAI.Tests
{
    using Newtonsoft.Json;
    using OpenAI.Infrastructure;
    using Xunit;

    public class JsonUtilsTest : BaseOpenAITest
    {
        [Fact]
        public void DeserializeObjectIgnoresDefaultSettings()
        {
            var origDefaultSettings = JsonConvert.DefaultSettings;

            try
            {
                JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Error,
                };

                var s = "{\"int\":234,\"string\":\"Hello!\",\"foo\":\"bar\"}";

                // Deserialization throws an exception because of the extra `foo` property that is
                // missing in the TestObject class.
                Assert.Throws<JsonSerializationException>(() =>
                    JsonConvert.DeserializeObject<TestObject>(s));

                // Deserialization succeeds because we're not using DefaultSettings, so
                // MissingMemberHandling is set to its default value Ignore instead of Error.
                var objOpenAI = JsonUtils.DeserializeObject<TestObject>(s);
                Assert.NotNull(objOpenAI);
                Assert.Equal(234, objOpenAI.Int);
                Assert.Equal("Hello!", objOpenAI.String);
            }
            finally
            {
                JsonConvert.DefaultSettings = origDefaultSettings;
            }
        }

        [Fact]
        public void SerializeObjectIgnoresDefaultSettings()
        {
            var origDefaultSettings = JsonConvert.DefaultSettings;

            try
            {
                JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    PreserveReferencesHandling = PreserveReferencesHandling.All,
                };

                var o = new TestObject { Int = 234, String = "Hello!" };

                // Serialized string is formatted with newlines and indentation because of
                // Formatting.Indented, and includes `$id` keys because of
                // PreserveReferencesHandling.All.
                var jsonDefault = JsonConvert.SerializeObject(o);
                jsonDefault = jsonDefault.Replace("\r\n", "\n");
                Assert.Equal(
                    "{\n  \"$id\": \"1\",\n  \"int\": 234,\n  \"string\": \"Hello!\"\n}",
                    jsonDefault);

                // Serialized string is not formatted and doesn't include `$id` keys because
                // we're not using DefaultSettings.
                var jsonOpenAI = JsonUtils.SerializeObject(o);
                jsonOpenAI = jsonOpenAI.Replace("\r\n", "\n");
                Assert.Equal("{\"int\":234,\"string\":\"Hello!\"}", jsonOpenAI);
            }
            finally
            {
                JsonConvert.DefaultSettings = origDefaultSettings;
            }
        }

        [JsonObject]
        private class TestObject
        {
            [JsonProperty("int")]
            public int Int { get; set; }

            [JsonProperty("string")]
            public string String { get; set; }
        }
    }
}
