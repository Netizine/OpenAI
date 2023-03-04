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

            public Task<T> RequestAsync<T>(HttpMethod method, string path,
                BaseOptions options, RequestOptions requestOptions)
                where T : IOpenAIEntity
            {
                LastOptions = options;
                return Task.FromResult(default(T));
            }

            public Task<T> RequestAsync<T>(HttpMethod method, string path,
                BaseOptions options, RequestOptions requestOptions,
                CancellationToken cancellationToken)
                where T : IOpenAIEntity
            {
                LastOptions = options;
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

            public virtual TestEntity Get(string id)
            {
                return Get(id, null, null);
            }

            public virtual TestEntity Get(string id, BaseOptions options)
            {
                return Get(id, options, null);
            }

            public virtual TestEntity Get(string id, RequestOptions requestOptions)
            {
                return Get(id, null, requestOptions);
            }

            public virtual TestEntity Get(string id, BaseOptions options, RequestOptions requestOptions)
            {
                return GetEntity(id, options, requestOptions);
            }

            public virtual Task<TestEntity> GetAsync(string id)
            {
                return GetAsync(id, null, null, default);
            }

            public virtual Task<TestEntity> GetAsync(string id, CancellationToken cancellationToken)
            {
                return GetAsync(id, null, null, cancellationToken);
            }

            public virtual Task<TestEntity> GetAsync(string id, BaseOptions options)
            {
                return GetAsync(id, options, null, default);
            }

            public virtual Task<TestEntity> GetAsync(string id, BaseOptions options, CancellationToken cancellationToken)
            {
                return GetAsync(id, options, null, cancellationToken);
            }

            public virtual Task<TestEntity> GetAsync(string id, RequestOptions requestOptions)
            {
                return GetAsync(id, null, requestOptions, default);
            }

            public virtual Task<TestEntity> GetAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
            {
                return GetAsync(id, null, requestOptions, cancellationToken);
            }

            public virtual Task<TestEntity> GetAsync(string id, BaseOptions options, RequestOptions requestOptions)
            {
                return GetAsync(id, null, requestOptions, default);
            }

            public virtual Task<TestEntity> GetAsync(string id, BaseOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
            {
                return GetEntityAsync(id, options, requestOptions, cancellationToken);
            }

            public virtual OpenAIList<TestEntity> List()
            {
                return List(null, null);
            }

            public virtual OpenAIList<TestEntity> List(ListOptions options)
            {
                return List(options, null);
            }

            public virtual OpenAIList<TestEntity> List(RequestOptions requestOptions)
            {
                return List(null, requestOptions);
            }

            public virtual OpenAIList<TestEntity> List(ListOptions options, RequestOptions requestOptions)
            {
                return ListEntities(options, requestOptions);
            }

            public Task<OpenAIList<TestEntity>> ListAsync()
            {
                return ListAsync(null, null, default);
            }

            public Task<OpenAIList<TestEntity>> ListAsync(CancellationToken cancellationToken)
            {
                return ListAsync(null, null, cancellationToken);
            }

            public Task<OpenAIList<TestEntity>> ListAsync(ListOptions listOptions)
            {
                return ListAsync(listOptions, null, default);
            }

            public Task<OpenAIList<TestEntity>> ListAsync(ListOptions listOptions, CancellationToken cancellationToken)
            {
                return ListAsync(listOptions, null, cancellationToken);
            }

            public Task<OpenAIList<TestEntity>> ListAsync(RequestOptions requestOptions)
            {
                return ListAsync(null, requestOptions, default);
            }

            public Task<OpenAIList<TestEntity>> ListAsync(RequestOptions requestOptions, CancellationToken cancellationToken)
            {
                return ListAsync(null, requestOptions, cancellationToken);
            }

            public Task<OpenAIList<TestEntity>> ListAsync(ListOptions listOptions, RequestOptions requestOptions)
            {
                return ListAsync(listOptions, requestOptions, default);
            }

            public virtual Task<OpenAIList<TestEntity>> ListAsync(ListOptions listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
            {
                return ListEntitiesAsync(listOptions, requestOptions, cancellationToken);
            }
        }
    }
}
