namespace OpenAI.Tests.Entities.Completions
{
    using Newtonsoft.Json;
    using Xunit;

    public class CompletionTest : BaseOpenAITest
    {
        public CompletionTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = "{\r\n  \"id\": \"cmpl-uqkvlQyYK7bGYrRHQ0eXlWi7\",\r\n  \"object\": \"text_completion\",\r\n  \"created\": 1589478378,\r\n  \"model\": \"text-davinci-003\",\r\n  \"choices\": [\r\n    {\r\n      \"text\": \"\\n\\nThis is indeed a test\",\r\n      \"index\": 0,\r\n      \"logprobs\": null,\r\n      \"finish_reason\": \"length\"\r\n    }\r\n  ],\r\n  \"usage\": {\r\n    \"prompt_tokens\": 5,\r\n    \"completion_tokens\": 7,\r\n    \"total_tokens\": 12\r\n  }\r\n}";
            var completion = JsonConvert.DeserializeObject<Completion>(json);
            Assert.NotNull(completion);
            Assert.IsType<Completion>(completion);
            Assert.NotNull(completion.Id);
            Assert.Equal("text_completion", completion.Object);
        }
    }
}
