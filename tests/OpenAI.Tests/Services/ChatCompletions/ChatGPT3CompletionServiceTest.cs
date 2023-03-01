using OpenAI.Entities.Chat.Completions;

namespace OpenAI.Tests.Services.ChatCompletions {

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using OpenAI;
    using Xunit;

    public class ChatGPT3CompletionServiceTest : BaseOpenAITest
    {
        private readonly ChatGPT3CompletionService service;
        private readonly ChatGPT3CompletionCreateOptions createOptions;

        public ChatGPT3CompletionServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            this.service = new ChatGPT3CompletionService(this.OpenAIClient);

            var chatMessage = new ChatCompletionMessage
            {
                Role = ChatRoles.User,
                Content = "Can you explain the meaning of life"
            };
            var chatMessageList = new List<ChatCompletionMessage>
            {
                chatMessage
            };

            this.createOptions = new ChatGPT3CompletionCreateOptions {
                Model = "gpt-3.5-turbo",
                Messages = chatMessageList,
            };
        }

        [Fact]
        public void Create()
        {
            var completion = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/chat/completions");
            Assert.NotNull(completion);
            Assert.Equal("chat.completion", completion.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var completion = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/chat/completions");
            Assert.NotNull(completion);
            Assert.Equal("chat.completion", completion.Object);
        }
    }
}
