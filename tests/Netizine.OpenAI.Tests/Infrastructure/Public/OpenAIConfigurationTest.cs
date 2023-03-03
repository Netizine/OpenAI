namespace OpenAI.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using OpenAI;
    using Xunit;

    public class OpenAIConfigurationTest : BaseOpenAITest
    {
        [Fact]
        public void OpenAIClient_Getter_CreatesNewOpenAIClientIfNullAndApiKeyIsSet()
        {
            var origApiKey = OpenAIConfiguration.ApiKey;
            var origOrganizationId = OpenAIConfiguration.OrganizationId;

            try
            {
                OpenAIConfiguration.ApiKey = "sk_key_openaiconfiguration";
                OpenAIConfiguration.OrganizationId = "ca_openaiconfiguration";
                OpenAIConfiguration.OpenAIClient = null;

                var client = OpenAIConfiguration.OpenAIClient;
                Assert.NotNull(client);
                Assert.Equal(OpenAIConfiguration.ApiKey, client.ApiKey);
                Assert.Equal(OpenAIConfiguration.OrganizationId, client.OrganizationId);
            }
            finally
            {
                OpenAIConfiguration.ApiKey = origApiKey;
                OpenAIConfiguration.OrganizationId = origOrganizationId;
            }
        }

        [Fact]
        public void OpenAIClient_Getter_CreatesNewOpenAIClientIfNullAndApiKeyIsNull()
        {
            var origApiKey = OpenAIConfiguration.ApiKey;

            try
            {
                OpenAIConfiguration.ApiKey = null;
                OpenAIConfiguration.OpenAIClient = null;

                var client = OpenAIConfiguration.OpenAIClient;
                Assert.NotNull(client);
                Assert.Null(client.ApiKey);
            }
            finally
            {
                OpenAIConfiguration.ApiKey = origApiKey;
            }
        }

        [Fact]
        public void OpenAIClient_Getter_ThrowsIfClientIsNullAndApiKeyIsEmpty()
        {
            var origApiKey = OpenAIConfiguration.ApiKey;

            try
            {
                OpenAIConfiguration.ApiKey = string.Empty;
                OpenAIConfiguration.OpenAIClient = null;

                var exception = Assert.Throws<OpenAIException>(() =>
                    OpenAIConfiguration.OpenAIClient);
                Assert.Contains("Your API key is invalid, as it is an empty string.", exception.Message);
            }
            finally
            {
                OpenAIConfiguration.ApiKey = origApiKey;
            }
        }

        [Fact]
        public void OpenAIClient_Getter_ThrowsIfClientIsNullAndApiKeyContainsWhitespace()
        {
            var origApiKey = OpenAIConfiguration.ApiKey;

            try
            {
                OpenAIConfiguration.ApiKey = "sk_openaiconfiguration\n";
                OpenAIConfiguration.OpenAIClient = null;

                var exception = Assert.Throws<OpenAIException>(() =>
                    OpenAIConfiguration.OpenAIClient);
                Assert.Contains("Your API key is invalid, as it contains whitespace.", exception.Message);
            }
            finally
            {
                OpenAIConfiguration.ApiKey = origApiKey;
            }
        }
    }
}
