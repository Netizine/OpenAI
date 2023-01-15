namespace OpenAI.Tests
{
    using Xunit;

    [CollectionDefinition("openai-mock tests")]
    public class OpenAIMockTestCollection :
        ICollectionFixture<MockHttpClientFixture>,
        ICollectionFixture<OpenAIMockFixture>
    {
        // This class has no code, and is never created. Its purpose is simply to be the place to
        // apply [CollectionDefinition] and all the ICollectionFixture<> interfaces.
    }
}
