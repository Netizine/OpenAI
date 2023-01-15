namespace OpenAI.Tests
{
    using System;
    using Newtonsoft.Json;
    using OpenAI;
    using OpenAI.Tests.Infrastructure.TestData;
    using Xunit;

    public class SerializationTest : BaseOpenAITest
    {
        [Fact]
        public void RoundtripDatetime()
        {
            var date = DateTime.UtcNow;
            var roundedDate = date.AddTicks(-1 * (date.Ticks % TimeSpan.TicksPerSecond));
            var obj = new TestObjectDateTime
            {
                Date = roundedDate,
            };

            var reloaded = JsonConvert.DeserializeObject<TestObjectDateTime>(JsonConvert.SerializeObject(obj));
            Assert.Equal(reloaded.Date, obj.Date);
        }

        [Fact]
        public void HandleNull()
        {
            var obj = new TestObjectDateTime
            {
                Date = null,
            };

            var reloaded = JsonConvert.DeserializeObject<TestObjectDateTime>(JsonConvert.SerializeObject(obj));
            Assert.Null(reloaded.Date);
        }

        [Fact]
        public void Serialize()
        {
            var json = GetResourceAsString("api_fixtures.engines.json");
            var evt = JsonConvert.DeserializeObject<Engine>(json);
            var serialized = JsonConvert.SerializeObject(evt, Formatting.Indented);
            var reserialized = JsonConvert.SerializeObject(
                JsonConvert.DeserializeObject<Engine>(serialized),
                Formatting.Indented);
            Assert.Equal(serialized, reserialized);
        }
    }
}
