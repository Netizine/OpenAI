#pragma warning disable CS0618
namespace OpenAI.Tests.Services.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using OpenAI;
    using Xunit;

    public class EngineServiceTest : BaseOpenAITest
    {
        private const string EngineId = "text-davinci-003";

        private readonly EngineService service;
        private readonly EngineListOptions listOptions;

        public EngineServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            this.service = new EngineService(this.OpenAIClient);

            this.listOptions = new EngineListOptions();
        }

        [Fact]
        public void Get()
        {
            var engine = this.service.Get(EngineId);
            this.AssertRequest(HttpMethod.Get, "/v1/engines/text-davinci-003");
            Assert.NotNull(engine);
            Assert.Equal("engine", engine.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var engine = await this.service.GetAsync(EngineId);
            this.AssertRequest(HttpMethod.Get, "/v1/engines/text-davinci-003");
            Assert.NotNull(engine);
            Assert.Equal("engine", engine.Object);
        }

        [Fact]
        public void List()
        {
            var engines = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/engines");
            Assert.NotNull(engines);
            Assert.Equal("list", engines.Object);
            Assert.Equal(52, engines.Data.Count);
            Assert.Equal("engine", engines.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var engines = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/engines");
            Assert.NotNull(engines);
            Assert.Equal("list", engines.Object);
            Assert.Equal(52, engines.Data.Count);
            Assert.Equal("engine", engines.Data[0].Object);
        }
    }
}