namespace OpenAI.Tests.Services.Models
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using OpenAI;
    using Xunit;

    public class ModelServiceTest : BaseOpenAITest
    {
        private const string ModelId = "davinci";

        private readonly ModelService service;
        private readonly ModelListOptions listOptions;

        public ModelServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            service = new ModelService(OpenAIClient);

            listOptions = new ModelListOptions();
        }

        [Fact]
        public void Get()
        {
            var model = service.Get(ModelId);
            AssertRequest(HttpMethod.Get, "/v1/models/davinci");
            Assert.NotNull(model);
            Assert.Equal("model", model.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var model = await service.GetAsync(ModelId);
            AssertRequest(HttpMethod.Get, "/v1/models/davinci");
            Assert.NotNull(model);
            Assert.Equal("model", model.Object);
        }

        [Fact]
        public void List()
        {
            var models = service.List(listOptions);
            AssertRequest(HttpMethod.Get, "/v1/models");
            Assert.NotNull(models);
            Assert.Equal("list", models.Object);
            Assert.Equal(66, models.Data.Count);
            Assert.Equal("model", models.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var engines = await service.ListAsync(listOptions);
            AssertRequest(HttpMethod.Get, "/v1/models");
            Assert.NotNull(engines);
            Assert.Equal("list", engines.Object);
            Assert.Equal(66, engines.Data.Count);
            Assert.Equal("model", engines.Data[0].Object);
        }

        [Fact]
        public void Delete()
        {
            var model = service.Delete("curie:ft-acmeco-2021-03-03-21-44-20");
            Assert.NotNull(model);
            Assert.Equal("model", model.Object);
            Assert.Equal(true, model.Deleted);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            var model = await service.DeleteAsync("curie:ft-acmeco-2021-03-03-21-44-20");
            Assert.NotNull(model);
            Assert.Equal("model", model.Object);
            Assert.Equal(true, model.Deleted);
        }
    }
}
