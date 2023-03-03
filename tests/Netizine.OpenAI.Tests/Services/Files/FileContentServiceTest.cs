namespace OpenAI.Tests.Services.Files
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class FileContentServiceTest : BaseOpenAITest
    {
        private const string FileId = "file-GpNxfyq0WSPw0UT0Vxr4a1Bn";

        private readonly FileContentService service;

        public FileContentServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            this.service = new FileContentService(this.OpenAIClient);
        }

        [Fact]
        public void Get()
        {
            var fileContent = this.service.Get(FileId);
            this.AssertRequest(HttpMethod.Get, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn/content");
            Assert.NotNull(fileContent);
            Assert.NotEmpty(fileContent.Content);
        }

        [Fact]
        public async Task GetAsync()
        {
            var fileContent = await this.service.GetAsync(FileId);
            this.AssertRequest(HttpMethod.Get, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn/content");
            Assert.NotNull(fileContent);
            Assert.NotEmpty(fileContent.Content);
        }
    }
}
