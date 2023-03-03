using Newtonsoft.Json;
using Xunit;

namespace OpenAI.Tests.Entities.FineTunes
{
    public class FineTuneTest : BaseOpenAITest
    {
        public FineTuneTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F");
            var fineTune = JsonConvert.DeserializeObject<FineTune>(json);
            Assert.NotNull(fineTune);
            Assert.IsType<FineTune>(fineTune);
            Assert.NotNull(fineTune.Id);
            Assert.Equal("fine-tune", fineTune.Object);
        }
    }
}