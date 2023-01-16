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
        /// <returns>FineTune.</returns>
        public virtual FineTune Get(string id)
        {
            return this.Get(id, null, null);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneGetOptions">The fine tune get options.</param>
        /// <returns>FineTune.</returns>
        public virtual FineTune Get(string id, FineTuneGetOptions fineTuneGetOptions)
        {
            return this.Get(id, fineTuneGetOptions, null);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>FineTune.</returns>
        public virtual FineTune Get(string id, RequestOptions requestOptions)
        {
            return this.Get(id, null, requestOptions);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneGetOptions">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>FineTune.</returns>
        public virtual FineTune Get(string id, FineTuneGetOptions fineTuneGetOptions, RequestOptions requestOptions)
        {
            return this.GetEntity(id, fineTuneGetOptions, requestOptions);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> GetAsync(string id)
        {
            return this.GetAsync(id, null, null, default);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> GetAsync(string id, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneGetOptions">The fine tune get options.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> GetAsync(string id, FineTuneGetOptions fineTuneGetOptions)
        {
            return this.GetAsync(id, fineTuneGetOptions, null, default);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> GetAsync(string id, RequestOptions requestOptions)
        {
            return this.GetAsync(id, null, requestOptions, default);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneGetOptions">The fine tune get options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> GetAsync(string id, FineTuneGetOptions fineTuneGetOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, fineTuneGetOptions, null, cancellationToken);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> GetAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneGetOptions">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> GetAsync(string id, FineTuneGetOptions fineTuneGetOptions, RequestOptions requestOptions, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, fineTuneGetOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes.
        /// </summary>
        /// <returns>OpenAIList&lt;FineTune&gt;.</returns>
        public virtual OpenAIList<FineTune> List()
        {
            return this.List(null, null);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes.
        /// </summary>
        /// <param name="fineTuneListOptions">The options.</param>
        /// <returns>OpenAIList&lt;FineTune&gt;.</returns>
        public virtual OpenAIList<FineTune> List(FineTuneListOptions fineTuneListOptions)
        {
            return this.List(fineTuneListOptions, null);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;FineTune&gt;.</returns>
        public virtual OpenAIList<FineTune> List(RequestOptions requestOptions)
        {
            return this.List(null, requestOptions);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes.
        /// </summary>
        /// <param name="fineTuneListOptions">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;FineTune&gt;.</returns>
        public virtual OpenAIList<FineTune> List(FineTuneListOptions fineTuneListOptions, RequestOptions requestOptions)
        {
            return this.ListEntities(fineTuneListOptions, requestOptions);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes asynchronously.
        /// </summary>
        /// <returns>Task&lt;OpenAIList&lt;FineTune&gt;&gt;.</returns>
        public virtual Task<OpenAIList<FineTune>> ListAsync()
        {
            return this.ListAsync(null, null, default);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;FineTune&gt;&gt;.</returns>
        public virtual Task<OpenAIList<FineTune>> ListAsync(CancellationToken cancellationToken)
        {
            return this.ListAsync(null, null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes asynchronously.
        /// </summary>
        /// <param name="fineTuneListOptions">The fine-tine list options.</param>
        /// <returns>Task&lt;OpenAIList&lt;FineTune&gt;&gt;.</returns>
        public virtual Task<OpenAIList<FineTune>> ListAsync(FineTuneListOptions fineTuneListOptions)
        {
            return this.ListAsync(fineTuneListOptions, null, default);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes asynchronously.
        /// </summary>
        /// <param name="fineTuneListOptions">The fine-tine list options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;FineTune&gt;&gt;.</returns>
        public virtual Task<OpenAIList<FineTune>> ListAsync(FineTuneListOptions fineTuneListOptions, CancellationToken cancellationToken)
        {
            return this.ListAsync(fineTuneListOptions, null, cancellationToken);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;OpenAIList&lt;FineTune&gt;&gt;.</returns>
        public virtual Task<OpenAIList<FineTune>> ListAsync(RequestOptions requestOptions)
        {
            return this.ListAsync(null, requestOptions, default);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;FineTune&gt;&gt;.</returns>
        public virtual Task<OpenAIList<FineTune>> ListAsync(RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.ListAsync(null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes asynchronously.
        /// </summary>
        /// <param name="fineTuneListOptions">The fine-tine list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;OpenAIList&lt;FineTune&gt;&gt;.</returns>
        public virtual Task<OpenAIList<FineTune>> ListAsync(FineTuneListOptions fineTuneListOptions, RequestOptions requestOptions)
        {
            return this.ListAsync(fineTuneListOptions, requestOptions, default);
        }

        /// <summary>
        /// Gets a list of the specified fine-tunes asynchronously.
        /// </summary>
        /// <param name="fineTuneListOptions">The fine-tine list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;FineTune&gt;&gt;.</returns>
        public virtual Task<OpenAIList<FineTune>> ListAsync(FineTuneListOptions fineTuneListOptions, RequestOptions requestOptions, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(fineTuneListOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a fine-tune entity with the specified options.
        /// </summary>
        /// <param name="fineTuneCreateOptions">The options.</param>
        /// <returns>The created entity.</returns>
        public FineTune Create(FineTuneCreateOptions fineTuneCreateOptions)
        {
            return this.Create(fineTuneCreateOptions, null);
        }

        /// <summary>
        /// Creates a fine-tune entity with the specified options.
        /// </summary>
        /// <param name="fineTuneCreateOptions">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public FineTune Create(FineTuneCreateOptions fineTuneCreateOptions, RequestOptions requestOptions)
        {
            return this.CreateEntity(fineTuneCreateOptions, requestOptions);
        }

        /// <summary>
        /// Creates a fine-tune entity with the specified options asynchronously.
        /// </summary>
        /// <param name="fineTuneCreateOptions">The options.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public Task<FineTune> CreateAsync(FineTuneCreateOptions fineTuneCreateOptions)
        {
            return this.CreateEntityAsync(fineTuneCreateOptions, null, default);
        }

        /// <summary>
        /// Creates a fine-tune entity with the specified options asynchronously.
        /// </summary>
        /// <param name="fineTuneCreateOptions">The options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public Task<FineTune> CreateAsync(FineTuneCreateOptions fineTuneCreateOptions, CancellationToken cancellationToken)
        {
            return this.CreateEntityAsync(fineTuneCreateOptions, null, cancellationToken);
        }

        /// <summary>
        /// Creates a fine-tune entity with the specified options asynchronously.
        /// </summary>
        /// <param name="fineTuneCreateOptions">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public Task<FineTune> CreateAsync(FineTuneCreateOptions fineTuneCreateOptions, RequestOptions requestOptions)
        {
            return this.CreateEntityAsync(fineTuneCreateOptions, requestOptions, default);
        }

        /// <summary>
        /// Creates a fine-tune entity with the specified options asynchronously.
        /// </summary>
        /// <param name="fineTuneCreateOptions">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public Task<FineTune> CreateAsync(FineTuneCreateOptions fineTuneCreateOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.CreateEntityAsync(fineTuneCreateOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>FineTune.</returns>
        public virtual FineTune Cancel(string id)
        {
            return this.Cancel(id, null, null);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneCancelPutOptions">The fine-tune cancel options.</param>
        /// <returns>FineTune.</returns>
        public virtual FineTune Cancel(string id, FineTuneCancelPutOptions fineTuneCancelPutOptions)
        {
            return this.Cancel(id, fineTuneCancelPutOptions, null);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>FineTune.</returns>
        public virtual FineTune Cancel(string id, RequestOptions requestOptions)
        {
            return this.Cancel(id, null, requestOptions);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneCancelPutOptions">The fine-tune cancel options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>FineTune.</returns>
        public virtual FineTune Cancel(string id, FineTuneCancelPutOptions fineTuneCancelPutOptions, RequestOptions requestOptions)
        {
            return this.Request(HttpMethod.Post, $"/v1/fine-tunes/{id}/cancel", fineTuneCancelPutOptions, requestOptions);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> CancelAsync(string id)
        {
            return this.CancelAsync(id, null, null, default);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> CancelAsync(string id, CancellationToken cancellationToken)
        {
            return this.CancelAsync(id, null, null, cancellationToken);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneCancelPutOptions">The fine tune cancel options.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> CancelAsync(string id, FineTuneCancelPutOptions fineTuneCancelPutOptions)
        {
            return this.CancelAsync(id, fineTuneCancelPutOptions, null, default);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneCancelPutOptions">The fine tune cancel options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> CancelAsync(string id, FineTuneCancelPutOptions fineTuneCancelPutOptions, CancellationToken cancellationToken)
        {
            return this.CancelAsync(id, fineTuneCancelPutOptions, null, cancellationToken);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> CancelAsync(string id, RequestOptions requestOptions)
        {
            return this.CancelAsync(id, null, requestOptions, default);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> CancelAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.CancelAsync(id, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneCancelPutOptions">The fine tune cancel options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> CancelAsync(string id, FineTuneCancelPutOptions fineTuneCancelPutOptions, RequestOptions requestOptions)
        {
            return this.CancelAsync(id, fineTuneCancelPutOptions, requestOptions, default);
        }

        /// <summary>
        /// Cancels the specified fine-tune  event by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneCancelPutOptions">The fine tune cancel options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTune&gt;.</returns>
        public virtual Task<FineTune> CancelAsync(string id, FineTuneCancelPutOptions fineTuneCancelPutOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.RequestAsync(HttpMethod.Post, $"/v1/fine-tunes/{id}/cancel", fineTuneCancelPutOptions, requestOptions, cancellationToken);
        }
    }
}