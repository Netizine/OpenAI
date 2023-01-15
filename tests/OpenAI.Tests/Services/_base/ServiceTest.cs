namespace OpenAI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using OpenAI;
    using Xunit;

    public class ServiceTest : BaseOpenAITest
    {
        public ServiceTest(MockHttpClientFixture mockHttpClientFixture)
            : base(mockHttpClientFixture)
        {
        }

        [Fact]
        public void Get_ThrowsIfIdIsNull()
        {
            var client = new TestClient();
            var service = new TestService(client);

            Assert.Throws<ArgumentException>(() => service.Get(null));
        }

        [Fact]
        public void Get_ThrowsIfIdIsEmpty()
        {
            var client = new TestClient();
            var service = new TestService(client);

            Assert.Throws<ArgumentException>(() => service.Get(string.Empty));
        }

        [Fact]
        public void Get_ThrowsIfIdIsWhitespace()
        {
            var client = new TestClient();
            var service = new TestService(client);

            Assert.Throws<ArgumentException>(() => service.Get(" "));
        }

        private class TestClient : IOpenAIClient
        {
            public string ApiBase { get; }

            public string ApiKey { get; }

            public string OrganizationId { get; }

            public BaseOptions LastOptions { get; protected set; }

            public Task<T> RequestAsync<T>(
                HttpMethod method,
                string path,
                BaseOptions options,
                RequestOptions requestOptions,
                CancellationToken cancellationToken = default)
                where T : IOpenAIEntity
            {
                this.LastOptions = options;
                return Task.FromResult(default(T));
            }
        }

        private class TestEntity : OpenAIEntity, IHasId
        {
            [JsonProperty("id")]
            public string Id { get; set; }
        }

        private class TestService : Service<TestEntity>,
            IListable<TestEntity, ListOptions>,
            IRetrievable<TestEntity, BaseOptions>
        {
            public TestService(IOpenAIClient client)
                : base(client)
            {
            }

            public override string BasePath => "/v1/test_entities";

            public virtual TestEntity Get(string id, BaseOptions options = null, RequestOptions requestOptions = null)
            {
                return this.GetEntity(id, options, requestOptions);
            }

            public virtual Task<TestEntity> GetAsync(string id, BaseOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
            {
                return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
            }

            public virtual OpenAIList<TestEntity> List(ListOptions options = null, RequestOptions requestOptions = null)
            {
                return this.ListEntities(options, requestOptions);
            }

            public virtual Task<OpenAIList<TestEntity>> ListAsync(ListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
            {
                return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
            }
        }
    }
}
