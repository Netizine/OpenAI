namespace OpenAI.Tests.Entities.Files
{
    using Newtonsoft.Json;
    using OpenAI;
    using Xunit;

    public class FileTest : BaseOpenAITest
    {
        public FileTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = "{\r\n  \"object\": \"file\",\r\n  \"id\": \"file-GpNxfyq0WSPw0UT0Vxr4a1Bn\",\r\n  \"purpose\": \"fine-tune\",\r\n  \"filename\": \"gpt3_test.jsonl\",\r\n  \"bytes\": 4755004,\r\n  \"created_at\": 1671275483,\r\n  \"status\": \"processed\",\r\n  \"status_details\": null\r\n}";
            var file = JsonConvert.DeserializeObject<File>(json);
            Assert.NotNull(file);
            Assert.IsType<File>(file);
            Assert.NotNull(file.Id);
            Assert.Equal("file", file.Object);
        }
    }
}