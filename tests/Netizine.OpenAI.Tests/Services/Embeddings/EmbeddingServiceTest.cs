namespace OpenAI.Tests.Services.Embeddings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using OpenAI;
    using Xunit;

    public class EmbeddingServiceTest : BaseOpenAITest
    {
        private readonly EmbeddingService service;
        private readonly EmbeddingCreateOptions createOptions;

        public EmbeddingServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            this.service = new EmbeddingService(this.OpenAIClient);

            this.createOptions = new EmbeddingCreateOptions
            {
                Model = "text-embedding-ada-002",
                Input = "The food was delicious and the waiter...",
            };
        }

        [Fact]
        public void Create()
        {
            var embedding = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/embeddings");
            Assert.NotNull(embedding);
            Assert.NotNull(embedding.Model);
            Assert.NotNull(embedding.Data);
            Assert.Equal("list", embedding.Object);
            Assert.Equal("embedding", embedding.Data[0].Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var embedding = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/embeddings");
            Assert.NotNull(embedding);
            Assert.NotNull(embedding.Model);
            Assert.NotNull(embedding.Data);
            Assert.Equal("embedding", embedding.Data[0].Object);
        }
    }
}