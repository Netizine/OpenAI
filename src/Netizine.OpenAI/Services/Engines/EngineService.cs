// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// Class EngineService.
    /// Implements the <see cref="OpenAI.Service{OpenAI.Engine}" />
    /// Implements the <see cref="OpenAI.IListable{OpenAI.Engine, OpenAI.EngineListOptions}" />
    /// Implements the <see cref="OpenAI.IRetrievable{OpenAI.Engine, OpenAI.EngineGetOptions}" />.
    /// </summary>
    /// <seealso cref="OpenAI.Service{OpenAI.Engine}" />
    /// <seealso cref="OpenAI.IListable{OpenAI.Engine, OpenAI.EngineListOptions}" />
    /// <seealso cref="OpenAI.IRetrievable{OpenAI.Engine, OpenAI.EngineGetOptions}" />
    [Obsolete("This class is deprecated. Please use the OpenAI.ModelService class instead.")]
    public class EngineService : Service<Engine>,
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
        IListable<Engine, EngineListOptions>,
        IRetrievable<Engine, EngineGetOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public EngineService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public EngineService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => "/v1/engines";

        /// <summary>
        /// Gets the specified engine by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Engine.</returns>
        public virtual Engine Get(string id)
        {
            return Get(id, null, null);
        }

        /// <summary>
        /// Gets the specified engine by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="engineGetOptions">The engine get options.</param>
        /// <returns>Engine.</returns>
        public virtual Engine Get(string id, EngineGetOptions engineGetOptions)
        {
            return Get(id, engineGetOptions, null);
        }

        /// <summary>
        /// Gets the specified engine by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Engine.</returns>
        public virtual Engine Get(string id, RequestOptions requestOptions)
        {
            return Get(id, null, requestOptions);
        }

        /// <summary>
        /// Gets the specified engine by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="engineGetOptions">The engine get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Engine.</returns>
        public virtual Engine Get(string id, EngineGetOptions engineGetOptions, RequestOptions requestOptions)
        {
            return GetEntity(id, engineGetOptions, requestOptions);
        }

        /// <summary>
        /// Gets the specified engine by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Engine&gt;.</returns>
        public virtual Task<Engine> GetAsync(string id)
        {
            return GetAsync(id, null, null, default);
        }

        /// <summary>
        /// Gets the specified engine by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Engine&gt;.</returns>
        public virtual Task<Engine> GetAsync(string id, CancellationToken cancellationToken)
        {
            return GetAsync(id, null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the specified engine by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="engineGetOptions">The engine get options.</param>
        /// <returns>Task&lt;Engine&gt;.</returns>
        public virtual Task<Engine> GetAsync(string id, EngineGetOptions engineGetOptions)
        {
            return GetAsync(id, engineGetOptions, null, default);
        }

        /// <summary>
        /// Gets the specified engine by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="engineGetOptions">The engine get options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Engine&gt;.</returns>
        public virtual Task<Engine> GetAsync(string id, EngineGetOptions engineGetOptions, CancellationToken cancellationToken)
        {
            return GetAsync(id, engineGetOptions, null, cancellationToken);
        }

        /// <summary>
        /// Gets the specified engine by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Engine&gt;.</returns>
        public virtual Task<Engine> GetAsync(string id, RequestOptions requestOptions)
        {
            return GetAsync(id, null, requestOptions, default);
        }

        /// <summary>
        /// Gets the specified engine by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Engine&gt;.</returns>
        public virtual Task<Engine> GetAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return GetAsync(id, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Gets the specified engine by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="engineGetOptions">The engine get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Engine&gt;.</returns>
        public virtual Task<Engine> GetAsync(string id, EngineGetOptions engineGetOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return GetEntityAsync(id, engineGetOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists the specified engines by options.
        /// </summary>
        /// <returns>OpenAIList&lt;Engine&gt;.</returns>
        public virtual OpenAIList<Engine> List()
        {
            return List(null, null);
        }

        /// <summary>
        /// Lists the specified engines by options.
        /// </summary>
        /// <param name="engineListOptions">The engine list options.</param>
        /// <returns>OpenAIList&lt;Engine&gt;.</returns>
        public virtual OpenAIList<Engine> List(EngineListOptions engineListOptions)
        {
            return List(engineListOptions, null);
        }

        /// <summary>
        /// Lists the specified engines by options.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;Engine&gt;.</returns>
        public virtual OpenAIList<Engine> List(RequestOptions requestOptions)
        {
            return List(null, requestOptions);
        }

        /// <summary>
        /// Lists the specified engines by options.
        /// </summary>
        /// <param name="engineListOptions">The engine list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;Engine&gt;.</returns>
        public virtual OpenAIList<Engine> List(EngineListOptions engineListOptions, RequestOptions requestOptions)
        {
            return ListEntities(engineListOptions, requestOptions);
        }

        /// <summary>
        /// Lists the specified engines by the provided options asynchronously.
        /// </summary>
        /// <returns>Task&lt;OpenAIList&lt;Engine&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Engine>> ListAsync()
        {
            return ListAsync(null, null, default);
        }

        /// <summary>
        /// Lists the specified engines by the provided options asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Engine&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Engine>> ListAsync(CancellationToken cancellationToken)
        {
            return ListAsync(null, null, cancellationToken);
        }

        /// <summary>
        /// Lists the specified engines by the provided options asynchronously.
        /// </summary>
        /// <param name="engineListOptions">The engine list options.</param>
        /// <returns>Task&lt;OpenAIList&lt;Engine&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Engine>> ListAsync(EngineListOptions engineListOptions)
        {
            return ListAsync(engineListOptions, null, default);
        }

        /// <summary>
        /// Lists the specified engines by the provided options asynchronously.
        /// </summary>
        /// <param name="engineListOptions">The engine list options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Engine&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Engine>> ListAsync(EngineListOptions engineListOptions, CancellationToken cancellationToken)
        {
            return ListAsync(engineListOptions, null, cancellationToken);
        }

        /// <summary>
        /// Lists the specified engines by the provided options asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;OpenAIList&lt;Engine&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Engine>> ListAsync(RequestOptions requestOptions)
        {
            return ListAsync(null, requestOptions, default);
        }

        /// <summary>
        /// Lists the specified engines by the provided options asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Engine&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Engine>> ListAsync(RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return ListAsync(null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists the specified engines by the provided options asynchronously.
        /// </summary>
        /// <param name="engineListOptions">The engine list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;OpenAIList&lt;Engine&gt;&gt;.</returns>
        public Task<OpenAIList<Engine>> ListAsync(EngineListOptions engineListOptions, RequestOptions requestOptions)
        {
            return ListAsync(engineListOptions, requestOptions, default);
        }

        /// <summary>
        /// Lists the specified engines by the provided options asynchronously.
        /// </summary>
        /// <param name="engineListOptions">The engine list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Engine&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Engine>> ListAsync(EngineListOptions engineListOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return ListEntitiesAsync(engineListOptions, requestOptions, cancellationToken);
        }
    }
}
