#pragma warning disable CS0618
namespace OpenAI.Tests
{
    using Newtonsoft.Json;
    using OpenAI;
    using Xunit;

    public class OpenAIEntityTest : BaseOpenAITest
    {
        public OpenAIEntityTest(
            OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void FromJsonAuto()
        {
            var json = "{\n  \"id\": \"text-davinci-003\",\n  \"object\": \"engine\",\n  \"owner\": \"openai\",\n  \"ready\": true\n}";

            var o = OpenAIEntity.FromJson(json);

            Assert.NotNull(o);
            Assert.IsType<Engine>(o);
            Assert.Equal("text-davinci-003", ((Engine)o).Id);
        }

        [Fact]
        public void FromJsonAutoUnknownObject()
        {
            var json = "{\"id\": \"ch_123\", \"object\": \"foo\"}";

            var o = OpenAIEntity.FromJson(json);

            Assert.Null(o);
        }

        [Fact]
        public void FromJsonAutoNoObject()
        {
            var json = "{\"id\": \"ch_123\"}";

            var o = OpenAIEntity.FromJson(json);

            Assert.Null(o);
        }

        [Fact]
        public void FromJsonOnType()
        {
            var json = "{\"integer\": 234, \"string\": \"String!\"}";

            var o = TestEntity.FromJson(json);

            Assert.NotNull(o);
            Assert.Equal(234, o.Integer);
            Assert.Equal("String!", o.String);
        }

        [Fact]
        public void FromJsonGeneric()
        {
            var json = "{\"integer\": 234, \"string\": \"String!\"}";

            var o = OpenAIEntity.FromJson<TestEntity>(json);

            Assert.NotNull(o);
            Assert.Equal(234, o.Integer);
            Assert.Equal("String!", o.String);
        }

        [Fact]
        public void ToJson()
        {
            var o = new TestEntity
            {
                Integer = 234,
                String = "String!",
            };

            var json = o.ToJson().Replace("\r\n", "\n");

            var expectedJson = "{\n  \"integer\": 234,\n  \"string\": \"String!\"\n}";
            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void RawJObject()
        {
            var service = new EngineService(OpenAIClient);
            var engine = service.Get("text-davinci-003");

            Assert.NotNull(engine);

            // Access `id`, a string element
            Assert.Equal(engine.Id, engine.RawJObject["id"]);

            // Access `object`, a string element
            Assert.Equal(engine.Object, engine.RawJObject["object"]);
        }

        private class TestEntity : OpenAIEntity<TestEntity>
        {
            [JsonProperty("integer")]
            public int Integer { get; set; }

            [JsonProperty("string")]
            public string String { get; set; }
        }

        private class TestNestedEntity : OpenAIEntity<TestNestedEntity>, IHasId
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("bar")]
            public int Bar { get; set; }
        }
    }
}
