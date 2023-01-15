namespace OpenAI.Tests.Services.Edits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using OpenAI;
    using Xunit;

    public class EditServiceTest : BaseOpenAITest
    {
        private readonly EditService service;
        private readonly EditCreateOptions createOptions;

        public EditServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            this.service = new EditService(this.OpenAIClient);

            this.createOptions = new EditCreateOptions
            {
                Model = "text-davinci-edit-001",
                Input = "What day of the wek is it?",
                Instruction = "Fix the spelling mistakes",
            };
        }

        [Fact]
        public void Create()
        {
            var edit = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/edits");
            Assert.NotNull(edit);
            Assert.Equal("edit", edit.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var edit = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/edits");
            Assert.NotNull(edit);
            Assert.Equal("edit", edit.Object);
        }
    }
}
