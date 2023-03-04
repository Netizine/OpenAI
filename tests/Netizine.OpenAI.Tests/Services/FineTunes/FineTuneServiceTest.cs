namespace OpenAI.Tests.Services.FineTunes
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;

    public class FineTuneServiceTest : BaseOpenAITest
    {
        private const string FineTuneId = "ft-AF1WoRqd3aJAHsqc9NY7iL8F";

        private readonly FineTuneService service;
        private readonly FineTuneListOptions listOptions;
        private readonly FineTuneCreateOptions createOptions;

        public FineTuneServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            service = new FineTuneService(OpenAIClient);

            listOptions = new FineTuneListOptions();

            createOptions = new FineTuneCreateOptions
            {
                TrainingFile = "file-XGinujblHPwGLSztz8cPS8XY",
            };
        }

        [Fact]
        public void Get()
        {
            var fineTune = service.Get(FineTuneId);
            AssertRequest(HttpMethod.Get, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var fineTune = await service.GetAsync(FineTuneId);
            AssertRequest(HttpMethod.Get, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public void List()
        {
            var fineTunes = service.List(listOptions);
            AssertRequest(HttpMethod.Get, "/v1/fine-tunes");
            Assert.NotNull(fineTunes);
            Assert.Equal("list", fineTunes.Object);
            Assert.Equal(3, fineTunes.Data.Count);
            Assert.Equal("fine-tune", fineTunes.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var fineTunes = await service.ListAsync(listOptions);
            AssertRequest(HttpMethod.Get, "/v1/fine-tunes");
            Assert.NotNull(fineTunes);
            Assert.Equal("list", fineTunes.Object);
            Assert.Equal(3, fineTunes.Data.Count);
            Assert.Equal("fine-tune", fineTunes.Data[0].Object);
        }

        [Fact]
        public void Create()
        {
            var fineTune = service.Create(createOptions);
            AssertRequest(HttpMethod.Post, "/v1/fine-tunes");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var fineTune = await service.CreateAsync(createOptions);
            AssertRequest(HttpMethod.Post, "/v1/fine-tunes");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public void Cancel()
        {
            var fineTune = service.Cancel(FineTuneId);
            AssertRequest(HttpMethod.Post, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F/cancel");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public async Task CancelAsync()
        {
            var fineTune = await service.CancelAsync(FineTuneId);
            AssertRequest(HttpMethod.Post, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F/cancel");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }
    }
}