namespace OpenAI
{
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
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The specified entity.</returns>
        public virtual Engine Get(string id, EngineGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Engine&gt;.</returns>
        public virtual Task<Engine> GetAsync(string id, EngineGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;Engine&gt;.</returns>
        public virtual OpenAIList<Engine> List(EngineListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// Lists the specified options asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Engine&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Engine>> ListAsync(EngineListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }
    }
}
