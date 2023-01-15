namespace OpenAI.Tests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http.Headers;
    using OpenAI;
    using Xunit;

    public class OpenAIResponseTest : BaseOpenAITest
    {
        public OpenAIResponseTest(OpenAIMockFixture openAIMockFixture)
            : base(openAIMockFixture)
        {
        }

        /* Most of OpenAIResponse's methods are helpers for accessing headers. Unfortunately,
         * HttpResponseHeaders is a sealed class with no public constructor, which makes it
         * ~impossible to write unit tests for OpenAIResponse. This is why we rely on real
         * requests and fetch OpenAIResponse instances attached to resources.
         */

        [Fact]
        public void Date()
        {
            var response = new EngineService(this.OpenAIClient).Get("text-davinci-003").OpenAIResponse;

            Assert.NotNull(response.Date);
        }

        // James
        //[Fact]
        //public void OrganizationIdKey_Present()
        //{
        //    var requestOptions = new RequestOptions { OrganizationId = "organization_key" };
        //    var response = new EngineService(this.OpenAIClient).Get("text-davinci-003", null, requestOptions).OpenAIResponse;

        //    Assert.Equal("organization_key", response.OrganizationId);
        //}

        // James
        // [Fact]
        // public void OrganizationIdKey_Absent()
        // {
        //     var response = new AccountService(this.OpenAIClient).GetSelf().OpenAIResponse;
        //
        //     Assert.Null(response.OrganizationId);
        // }

        // James
        // [Fact]
        // public void RequestId()
        // {
        //     var response = new AccountService(this.OpenAIClient).GetSelf().OpenAIResponse;
        //
        //     Assert.NotNull(response.RequestId);
        // }
    }
}
