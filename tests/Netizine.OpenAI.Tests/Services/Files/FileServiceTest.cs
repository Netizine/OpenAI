namespace OpenAI.Tests.Services.Files
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using OpenAI;
    using Xunit;

    public class FileServiceTest : BaseOpenAITest
    {
        private const string FileId = "file-GpNxfyq0WSPw0UT0Vxr4a1Bn";

        private readonly FileService service;
        private readonly FileListOptions listOptions;
        private readonly FileCreateOptions createOptions;

        public FileServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            this.service = new FileService(this.OpenAIClient);

            this.listOptions = new FileListOptions();

            this.createOptions = new FileCreateOptions
            {
                File = "gpt3_test.jsonl",
                FileSource = System.IO.File.ReadAllBytes("gpt3_test.jsonl"),
                Purpose = "fine-tune",
            };
        }

        [Fact]
        public void Get()
        {
            var file = this.service.Get(FileId);
            this.AssertRequest(HttpMethod.Get, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn");
            Assert.NotNull(file);
            Assert.Equal("file", file.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var file = await this.service.GetAsync(FileId);
            this.AssertRequest(HttpMethod.Get, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn");
            Assert.NotNull(file);
            Assert.Equal("file", file.Object);
        }

        [Fact]
        public void List()
        {
            var files = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/files");
            Assert.NotNull(files);
            Assert.Equal("list", files.Object);
            Assert.Equal(2, files.Data.Count);
            Assert.Equal("file", files.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var engines = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/files");
            Assert.NotNull(engines);
            Assert.Equal("list", engines.Object);
            Assert.Equal(2, engines.Data.Count);
            Assert.Equal("file", engines.Data[0].Object);
        }

        [Fact]
        public void Create()
        {
            var file = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/files");
            Assert.NotNull(file);
            Assert.Equal("file", file.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var file = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/files");
            Assert.NotNull(file);
            Assert.Equal("file", file.Object);
        }

        [Fact]
        public void Delete()
        {
            var deleted = this.service.Delete(FileId);
            this.AssertRequest(HttpMethod.Delete, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn");
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await this.service.DeleteAsync(FileId);
            this.AssertRequest(HttpMethod.Delete, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn");
            Assert.NotNull(deleted);
        }
    }
}