namespace OpenAI.Tests.Entities.Models
{
    using Newtonsoft.Json;
    using OpenAI;
    using System.Security.Principal;
    using Xunit;

    public class ModelTest : BaseOpenAITest
    {
        public ModelTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/models/davinci");
            var model = JsonConvert.DeserializeObject<Model>(json);
            Assert.NotNull(model);
            Assert.IsType<Model>(model);
            Assert.NotNull(model.Id);
            Assert.Equal("model", model.Object);
        }
    }
}
