namespace OpenAI.Tests.Entities.Images
{
    using Newtonsoft.Json;
    using OpenAI;
    using System.Security.Principal;
    using Xunit;

    public class ImageTest : BaseOpenAITest
    {
        public ImageTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = "{\r\n  \"created\": 1589478378,\r\n  \"data\": [\r\n    {\r\n      \"url\": \"https://...\"\r\n    },\r\n    {\r\n      \"url\": \"https://...\"\r\n    }\r\n  ]\r\n}";
            var image = JsonConvert.DeserializeObject<Image>(json);
            Assert.NotNull(image);
            Assert.IsType<Image>(image);
            Assert.NotEmpty(image.Data);
            Assert.StartsWith("https", image.Data[0].Url);
        }
    }
}