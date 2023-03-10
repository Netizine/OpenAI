// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Abstract base class for all services.</summary>
    /// <typeparam name="TEntityReturned">
    /// The type of <see cref="IOpenAIEntity"/> that this service returns.
    /// </typeparam>
    public abstract class Service<TEntityReturned>
        where TEntityReturned : IOpenAIEntity
    {
        private IOpenAIClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class.
        /// </summary>
        protected Service()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class with a
        /// custom <see cref="IOpenAIClient"/>.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        protected Service(IOpenAIClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        public abstract string BasePath { get; }

        /// <summary>
        /// Gets the base URL.
        /// </summary>
        public virtual string BaseUrl => Client.ApiBase;

        /// <summary>
        /// Gets or sets the client used by this service to send requests. If no client was set when the
        /// service instance was created, then the default client in
        /// <see cref="OpenAIConfiguration.OpenAIClient"/> is used instead.
        /// </summary>
        /// <remarks>
        /// Setting the client at runtime may not be thread-safe.
        /// If you wish to use a custom client, it is recommended that you pass it to the service's constructor and not change it during the service's lifetime.
        /// </remarks>
        public IOpenAIClient Client
        {
            get => client ?? OpenAIConfiguration.OpenAIClient;
            set => client = value;
        }

        /// <summary>
        /// Creates the entity.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected TEntityReturned CreateEntity(BaseOptions options, RequestOptions requestOptions)
        {
            return Request(
                HttpMethod.Post,
                ClassUrl(),
                options,
                requestOptions);
        }

        /// <summary>
        /// Creates the entity asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected Task<TEntityReturned> CreateEntityAsync(
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken)
        {
            return RequestAsync(
                HttpMethod.Post,
                ClassUrl(),
                options,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected TEntityReturned DeleteEntity(
            string id,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            return Request(
                HttpMethod.Delete,
                InstanceUrl(id),
                options,
                requestOptions);
        }

        /// <summary>
        /// Deletes the entity asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected Task<TEntityReturned> DeleteEntityAsync(
            string id,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken)
        {
            return RequestAsync(
                HttpMethod.Delete,
                InstanceUrl(id),
                options,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected TEntityReturned GetEntity(
            string id,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            return Request(
                HttpMethod.Get,
                InstanceUrl(id),
                options,
                requestOptions);
        }

        /// <summary>
        /// Gets the entity asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected Task<TEntityReturned> GetEntityAsync(
            string id,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken)
        {
            return RequestAsync(
                HttpMethod.Get,
                InstanceUrl(id),
                options,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Lists the entities.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected OpenAIList<TEntityReturned> ListEntities(
            ListOptions options,
            RequestOptions requestOptions)
        {
            return Request<OpenAIList<TEntityReturned>>(
                HttpMethod.Get,
                ClassUrl(),
                options,
                requestOptions);
        }

        /// <summary>
        /// Lists the entities asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected Task<OpenAIList<TEntityReturned>> ListEntitiesAsync(
            ListOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken)
        {
            return RequestAsync<OpenAIList<TEntityReturned>>(
                HttpMethod.Get,
                ClassUrl(),
                options,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Requests the specified method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="path">The path.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected TEntityReturned Request(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            return Request<TEntityReturned>(
                method,
                path,
                options,
                requestOptions);
        }

        /// <summary>
        /// Requests the specified method asynchronously.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected Task<TEntityReturned> RequestAsync(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            return RequestAsync<TEntityReturned>(
                method,
                path,
                options,
                requestOptions,
                default);
        }

        /// <summary>
        /// Requests the specified method asynchronously.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected Task<TEntityReturned> RequestAsync(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken)
        {
            return RequestAsync<TEntityReturned>(
                method,
                path,
                options,
                requestOptions,
                cancellationToken);
        }

        /// <summary>
        /// Requests the specified method.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="path">The path.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected T Request<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
            where T : IOpenAIEntity
        {
            return RequestAsync<T>(method, path, options, requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Requests the HTTP call asynchronously.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="path">The path.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected async Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
            where T : IOpenAIEntity
        {
            requestOptions = SetupRequestOptions(requestOptions);
            return await Client.RequestAsync<T>(
                method,
                path,
                options,
                requestOptions,
                default).ConfigureAwait(false);
        }

        /// <summary>
        /// Requests the HTTP call asynchronously.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="path">The path.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The type of <see cref="IOpenAIEntity"/> that this service returns.</returns>
        protected async Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken)
            where T : IOpenAIEntity
        {
            requestOptions = SetupRequestOptions(requestOptions);
            return await Client.RequestAsync<T>(
                method,
                path,
                options,
                requestOptions,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Sets up the request options.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Request options.</returns>
        protected RequestOptions SetupRequestOptions(RequestOptions requestOptions)
        {
            if (requestOptions == null)
            {
                requestOptions = new RequestOptions();
                if (!string.IsNullOrEmpty(OpenAIConfiguration.OrganizationId))
                {
                    requestOptions.OrganizationId = OpenAIConfiguration.OrganizationId;
                }
            }

            requestOptions.BaseUrl ??= BaseUrl;

            return requestOptions;
        }

        /// <summary>
        /// The class URL.
        /// </summary>
        /// <returns>The class url.</returns>
        protected virtual string ClassUrl()
        {
            return BasePath;
        }

        /// <summary>
        /// The encoded URL Instance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The encoded URL instance.</returns>
        /// <exception cref="System.ArgumentException">The resource ID cannot be null or whitespace. - id.</exception>
        protected virtual string InstanceUrl(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException(
                    "The resource ID cannot be null or whitespace.",
                    nameof(id));
            }

            return $"{ClassUrl()}/{WebUtility.UrlEncode(id)}";
        }
    }
}
