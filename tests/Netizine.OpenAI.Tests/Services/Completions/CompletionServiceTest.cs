namespace OpenAI.Tests.Services.Completions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using OpenAI;
    using Xunit;

    public class CompletionServiceTest : BaseOpenAITest
    {
        private readonly CompletionService service;
        private readonly CompletionCreateOptions createOptions;

        public CompletionServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            service = new CompletionService(OpenAIClient);

            createOptions = new CompletionCreateOptions
            {
                Model = "text-davinci-003",
                Prompt = "Say this is a test",
                MaxTokens = 7,
                Temperature = 0,
            };
        }

        [Fact]
        public void Create()
        {
            var completion = service.Create(createOptions);
            AssertRequest(HttpMethod.Post, "/v1/completions");
            Assert.NotNull(completion);
            Assert.Equal("text_completion", completion.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var completion = await service.CreateAsync(createOptions);
            AssertRequest(HttpMethod.Post, "/v1/completions");
            Assert.NotNull(completion);
            Assert.Equal("text_completion", completion.Object);
        }
    }
}
