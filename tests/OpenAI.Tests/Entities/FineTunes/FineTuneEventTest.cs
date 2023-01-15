using Newtonsoft.Json;
using Xunit;

namespace OpenAI.Tests.Entities.FineTunes
{
    public class FineTuneEventTest : BaseOpenAITest
    {
        public FineTuneEventTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F/events");
            var fineTuneEvents = JsonConvert.DeserializeObject<FineTuneEvents>(json);
            Assert.NotNull(fineTuneEvents);
            Assert.IsType<FineTuneEvents>(fineTuneEvents);
            Assert.Equal("list", fineTuneEvents.Object);
            Assert.Equal("fine-tune-event", fineTuneEvents.Data[0].Object);
        }
    }
}