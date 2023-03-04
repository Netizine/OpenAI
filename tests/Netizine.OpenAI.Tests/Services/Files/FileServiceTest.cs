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
            service = new FileService(OpenAIClient);

            listOptions = new FileListOptions();

            createOptions = new FileCreateOptions
            {
                File = "gpt3_test.jsonl",
                FileSource = System.IO.File.ReadAllBytes("gpt3_test.jsonl"),
                Purpose = "fine-tune",
            };
        }

        [Fact]
        public void Get()
        {
            var file = service.Get(FileId);
            AssertRequest(HttpMethod.Get, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn");
            Assert.NotNull(file);
            Assert.Equal("file", file.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var file = await service.GetAsync(FileId);
            AssertRequest(HttpMethod.Get, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn");
            Assert.NotNull(file);
            Assert.Equal("file", file.Object);
        }

        [Fact]
        public void List()
        {
            var files = service.List(listOptions);
            AssertRequest(HttpMethod.Get, "/v1/files");
            Assert.NotNull(files);
            Assert.Equal("list", files.Object);
            Assert.Equal(2, files.Data.Count);
            Assert.Equal("file", files.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var engines = await service.ListAsync(listOptions);
            AssertRequest(HttpMethod.Get, "/v1/files");
            Assert.NotNull(engines);
            Assert.Equal("list", engines.Object);
            Assert.Equal(2, engines.Data.Count);
            Assert.Equal("file", engines.Data[0].Object);
        }

        [Fact]
        public void Create()
        {
            var file = service.Create(createOptions);
            AssertRequest(HttpMethod.Post, "/v1/files");
            Assert.NotNull(file);
            Assert.Equal("file", file.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var file = await service.CreateAsync(createOptions);
            AssertRequest(HttpMethod.Post, "/v1/files");
            Assert.NotNull(file);
            Assert.Equal("file", file.Object);
        }

        [Fact]
        public void Delete()
        {
            var deleted = service.Delete(FileId);
            AssertRequest(HttpMethod.Delete, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn");
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var deleted = await service.DeleteAsync(FileId);
            AssertRequest(HttpMethod.Delete, "/v1/files/file-GpNxfyq0WSPw0UT0Vxr4a1Bn");
            Assert.NotNull(deleted);
        }
    }
}