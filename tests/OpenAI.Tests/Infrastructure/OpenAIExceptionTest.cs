namespace OpenAI.Tests
{
    using System.Threading.Tasks;
    using OpenAI;
    using Xunit;

    public class OpenAIExceptionTest : BaseOpenAITest
    {
        public OpenAIExceptionTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        // James
        // [Fact]
        // public async Task SetsOpenAIResponse()
        // {
        //     // This test assumes that `POST /v1/payment_intents` has at least one required param,
        //     // and so will throw an exception if we provide zero params.
        //     var exception = await Assert.ThrowsAsync<OpenAIException>(async () =>
        //     {
        //         await new PaymentIntentService(this.OpenAIClient)
        //             .CreateAsync(new PaymentIntentCreateOptions());
        //     });
        //
        //     Assert.NotNull(exception);
        //     Assert.NotNull(exception.OpenAIError);
        //     Assert.NotNull(exception.OpenAIError.OpenAIResponse);
        // }
    }
}
