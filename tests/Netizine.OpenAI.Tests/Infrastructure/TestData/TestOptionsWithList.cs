namespace OpenAI.Tests.Infrastructure.TestData
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenAI;

    public class TestOptionsWithList : BaseOptions
    {
        public TestOptionsWithList()
        {
            SomeList = new List<TestNestedOptions>
            {
                new TestNestedOptions
                {
                    ALong = 1,
                    AString = "foo",
                },
                new TestNestedOptions
                {
                    ALong = 2,
                    AString = "bar",
                },
            };
        }

        [JsonProperty("some_list")]
        public List<TestNestedOptions> SomeList { get; set; }
    }
}
