namespace OpenAI.Tests
{
    using System;
    using OpenAI;
    using Xunit;

    public class OpenAITypeRegistryTest : BaseOpenAITest
    {
        [Fact]
        public void GetConcreteType()
        {
            Type type = null;

            // When provided with a concrete type, it is directly returned and the object string is
            // ignored.
            type = typeof(Engine);
            Assert.Equal(typeof(Engine), OpenAITypeRegistry.GetConcreteType(type, "bank_account"));

            // James
            //// When provided with an interface, the concrete type is deduced from the object string
            //type = typeof(IExternalAccount);
            //Assert.Equal(typeof(BankAccount), OpenAITypeRegistry.GetConcreteType(type, "bank_account"));

            //// When provided with an interface and no concrete type is known for the object string,
            //// it returns null
            //type = typeof(IExternalAccount);
            //Assert.Null(OpenAITypeRegistry.GetConcreteType(type, "unknown_object"));

            //// When provided with an interface and a concrete type is known for the object string
            //// but is incompatible with the interface, it returns null
            //type = typeof(IExternalAccount);
            //Assert.Null(OpenAITypeRegistry.GetConcreteType(type, "source"));
        }
    }
}
