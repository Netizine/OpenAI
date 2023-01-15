namespace OpenAI
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// Manage fine-tuning jobs to tailor a model to your specific training data.
    /// Related guide: <see href="https://beta.openai.com/docs/guides/fine-tuning">Fine-tune models</see>.
    /// Implements the <see cref="OpenAI.Service{OpenAI.FineTune}" />.
    /// Implements the <see cref="OpenAI.IListable{OpenAI.FineTune, OpenAI.FineTuneListOptions}" />.
    /// Implements the <see cref="OpenAI.IRetrievable{OpenAI.FineTune, OpenAI.FineTuneGetOptions}" />.
    /// Implements the <see cref="OpenAI.ICreatable{OpenAI.FineTune, OpenAI.FineTuneCreateOptions}" />.
    /// </summary>
    /// <seealso cref="OpenAI.Service{OpenAI.FineTune}" />
    /// <seealso cref="OpenAI.IListable{OpenAI.FineTune, OpenAI.FineTuneListOptions}" />
    /// <seealso cref="OpenAI.IRetrievable{OpenAI.FineTune, OpenAI.FineTuneGetOptions}" />
    /// <seealso cref="OpenAI.ICreatable{OpenAI.FineTune, OpenAI.FineTuneCreateOptions}" />
    public class FineTuneService : Service<FineTune>,
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
        IListable<FineTune, FineTuneListOptions>,
        IRetrievable<FineTune, FineTuneGetOptions>,
        ICreatable<FineTune, FineTuneCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FineTuneService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public FineTuneService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FineTuneService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public FineTuneService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => "/v1/fine-tunes";

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The specified entity.</returns>
        public virtual FineTune Get(string id, FineTuneGetOptions options = null, RequestOptions requestOptions = null)
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
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> GetAsync(string id, FineTuneGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Gets a list of the specified entities.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;FineTune&gt;.</returns>
        public virtual OpenAIList<FineTune> List(FineTuneListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// Gets a list of the specified entities asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;FineTune&gt;&gt;.</returns>
        public virtual Task<OpenAIList<FineTune>> ListAsync(FineTuneListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public FineTune Create(FineTuneCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public Task<FineTune> CreateAsync(FineTuneCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Cancels the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>FineTune.</returns>
        public virtual FineTune Cancel(string id, FineTuneCancelPutOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Post, $"/v1/fine-tunes/{id}/cancel", options, requestOptions);
        }

        /// <summary>
        /// Cancels the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> CancelAsync(string id, FineTuneCancelPutOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync(HttpMethod.Post, $"/v1/fine-tunes/{id}/cancel", options, requestOptions, cancellationToken);
        }
    }
}