using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OpenAI.Tests.Services.Moderations
{
    public class ModerationServiceTest : BaseOpenAITest
    {
        private readonly ModerationService service;
        private readonly ModerationGetOptions getOptions;

        public ModerationServiceTest(
            OpenAIMockFixture openAIMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(openAIMockFixture, mockHttpClientFixture)
        {
            service = new ModerationService(OpenAIClient);

            getOptions = new ModerationGetOptions
            {
                Input = "I want to kill them."
            };
        }

        [Fact]
        public void Get()
        {
            var moderation = service.Get(getOptions);
            AssertRequest(HttpMethod.Post, "/v1/moderations");
            Assert.NotNull(moderation);
            Assert.NotNull(moderation.Results);
            Assert.Single(moderation.Results);
            Assert.NotNull(moderation.Results[0].Categories);
            Assert.NotNull(moderation.Results[0].CategoryScores);
        }

        [Fact]
        public async Task GetAsync()
        {
            var moderation = await service.GetAsync(getOptions);
            AssertRequest(HttpMethod.Post, "/v1/moderations");
            Assert.NotNull(moderation);
            Assert.NotNull(moderation.Results);
            Assert.Single(moderation.Results);
            Assert.NotNull(moderation.Results[0].Categories);
            Assert.NotNull(moderation.Results[0].CategoryScores);
        }
    }
}
