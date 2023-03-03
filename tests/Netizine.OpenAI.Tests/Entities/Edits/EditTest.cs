namespace OpenAI.Tests.Entities.Edits
{
    using Newtonsoft.Json;
    using Xunit;

    public class EditTest : BaseOpenAITest
    {
        public EditTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = "{\"object\":\"edit\",\"created\":1673268388,\"choices\":[{\"text\":\"What day of the week is it?\\n\",\"index\":0}],\"usage\":{\"prompt_tokens\":26,\"completion_tokens\":28,\"total_tokens\":54}}";
            var edit = JsonConvert.DeserializeObject<Edit>(json);
            Assert.NotNull(edit);
            Assert.IsType<Edit>(edit);
            Assert.Equal("edit", edit.Object);
        }
    }
}
