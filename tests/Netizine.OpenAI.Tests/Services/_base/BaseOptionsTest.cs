namespace OpenAI.Tests
{
    using System.Linq;
    using Newtonsoft.Json;
    using OpenAI;
    using Xunit;

    public class BaseOptionsTest : BaseOpenAITest
    {
        [Fact]
        public void SerializeAndDeserializeExtraParams()
        {
            var options = new BaseOptions();
            options.AddExtraParam("foo", "String!");
            options.AddExtraParam("bar", 234L);

            var json = JsonConvert.SerializeObject(options);
            var deserialized = JsonConvert.DeserializeObject<BaseOptions>(json);

            Assert.True(options.ExtraParams.Count == deserialized.ExtraParams.Count);
            Assert.All(
                deserialized.ExtraParams,
                kvp => Assert.Equal(options.ExtraParams[kvp.Key], deserialized.ExtraParams[kvp.Key]));
        }
    }
}
