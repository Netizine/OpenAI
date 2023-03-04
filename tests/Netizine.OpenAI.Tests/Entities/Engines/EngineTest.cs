#pragma warning disable CS0618
namespace OpenAI.Tests.Entities.Engines
{
    using Newtonsoft.Json;
    using OpenAI;
    using System.Security.Principal;
    using Xunit;

    public class EngineTest : BaseOpenAITest
    {
        public EngineTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = GetFixture("/v1/engines/text-davinci-003");
            var engine = JsonConvert.DeserializeObject<Engine>(json);
            Assert.NotNull(engine);
            Assert.IsType<Engine>(engine);
            Assert.NotNull(engine.Id);
            Assert.Equal("engine", engine.Object);
        }
    }
}
