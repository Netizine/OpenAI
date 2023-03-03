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
            this.service = new FineTuneService(this.OpenAIClient);

            this.listOptions = new FineTuneListOptions();

            this.createOptions = new FineTuneCreateOptions
            {
                TrainingFile = "file-XGinujblHPwGLSztz8cPS8XY",
            };
        }

        [Fact]
        public void Get()
        {
            var fineTune = this.service.Get(FineTuneId);
            this.AssertRequest(HttpMethod.Get, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var fineTune = await this.service.GetAsync(FineTuneId);
            this.AssertRequest(HttpMethod.Get, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public void List()
        {
            var fineTunes = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/fine-tunes");
            Assert.NotNull(fineTunes);
            Assert.Equal("list", fineTunes.Object);
            Assert.Equal(3, fineTunes.Data.Count);
            Assert.Equal("fine-tune", fineTunes.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var fineTunes = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/fine-tunes");
            Assert.NotNull(fineTunes);
            Assert.Equal("list", fineTunes.Object);
            Assert.Equal(3, fineTunes.Data.Count);
            Assert.Equal("fine-tune", fineTunes.Data[0].Object);
        }

        [Fact]
        public void Create()
        {
            var fineTune = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/fine-tunes");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var fineTune = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/fine-tunes");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public void Cancel()
        {
            var fineTune = this.service.Cancel(FineTuneId);
            this.AssertRequest(HttpMethod.Post, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F/cancel");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }

        [Fact]
        public async Task CancelAsync()
        {
            var fineTune = await this.service.CancelAsync(FineTuneId);
            this.AssertRequest(HttpMethod.Post, "/v1/fine-tunes/ft-AF1WoRqd3aJAHsqc9NY7iL8F/cancel");
            Assert.NotNull(fineTune);
            Assert.Equal("fine-tune", fineTune.Object);
        }
    }
}