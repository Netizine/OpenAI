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
            service = new FileContentService(OpenAIClient);
        }

        [Fact]
        public void Get()
        {
            var fileContent = service.Get(FileId);
            AssertRequest(HttpMethod.Get, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn/content");
            Assert.NotNull(fileContent);
            Assert.NotEmpty(fileContent.Content);
        }

        [Fact]
        public async Task GetAsync()
        {
            var fileContent = await service.GetAsync(FileId);
            AssertRequest(HttpMethod.Get, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn/content");
            Assert.NotNull(fileContent);
            Assert.NotEmpty(fileContent.Content);
        }
    }
}
