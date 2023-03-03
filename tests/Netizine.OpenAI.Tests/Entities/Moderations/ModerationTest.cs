namespace OpenAI.Tests.Entities.Moderations
{
    using Newtonsoft.Json;
    using Xunit;

    public class ModerationTest : BaseOpenAITest
    {
        public ModerationTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = "{\r\n  \"id\": \"modr-6XtvDvY1WSQRW0IMMW2WvY0730k1X\",\r\n  \"model\": \"text-moderation-004\",\r\n  \"results\": [\r\n    {\r\n      \"categories\": {\r\n        \"hate\": false,\r\n        \"hate/threatening\": false,\r\n        \"self-harm\": false,\r\n        \"sexual\": false,\r\n        \"sexual/minors\": false,\r\n        \"violence\": true,\r\n        \"violence/graphic\": false\r\n      },\r\n      \"category_scores\": {\r\n        \"hate\": 0.18252533674240112,\r\n        \"hate/threatening\": 0.0032941880635917187,\r\n        \"self-harm\": 1.9077321944394043e-09,\r\n        \"sexual\": 9.69763732427964e-07,\r\n        \"sexual/minors\": 1.3826513267645169e-08,\r\n        \"violence\": 0.8871539235115051,\r\n        \"violence/graphic\": 3.196241493697016e-08\r\n      },\r\n      \"flagged\": true\r\n    }\r\n  ]\r\n}";
            var moderation = JsonConvert.DeserializeObject<Moderation>(json);
            Assert.NotNull(moderation);
            Assert.IsType<Moderation>(moderation);
            Assert.NotNull(moderation.Id);
            Assert.Single(moderation.Results);
        }
    }
}
