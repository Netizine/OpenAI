namespace OpenAI
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// FineTuneEventsService class.
    /// Implements the <see cref="OpenAI.Service{OpenAI.FineTuneEvents}" />.
    /// </summary>
    /// <seealso cref="OpenAI.Service{OpenAI.FineTuneEvents}" />
    public class FineTuneEventsService : Service<FineTuneEvents>
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FineTuneEventsService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public FineTuneEventsService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FineTuneEventsService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public FineTuneEventsService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => null;

        /// <summary>
        /// Gets the fine-tune events by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>FineTuneEvents.</returns>
        public FineTuneEvents Get(string id)
        {
            return this.Get(id, null, null);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneEventsGetOptions">The fine tune events get options.</param>
        /// <returns>FineTuneEvents.</returns>
        public FineTuneEvents Get(string id, FineTuneEventsGetOptions fineTuneEventsGetOptions)
        {
            return this.Get(id, fineTuneEventsGetOptions, null);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>FineTuneEvents.</returns>
        public FineTuneEvents Get(string id, RequestOptions requestOptions)
        {
            return this.Get(id, null, requestOptions);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneEventsGetOptions">The fine tune events get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>FineTuneEvents.</returns>
        public FineTuneEvents Get(string id, FineTuneEventsGetOptions fineTuneEventsGetOptions, RequestOptions requestOptions)
        {
            return this.Request(HttpMethod.Get, $"/v1/fine-tunes/{id}/events", fineTuneEventsGetOptions, requestOptions);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;FineTuneEvents&gt;.</returns>
        public Task<FineTuneEvents> GetAsync(string id)
        {
            return this.GetAsync(id, null, null, default);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTuneEvents&gt;.</returns>
        public Task<FineTuneEvents> GetAsync(string id, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneEventsGetOptions">The fine-tune events get options.</param>
        /// <returns>Task&lt;FineTuneEvents&gt;.</returns>
        public Task<FineTuneEvents> GetAsync(string id, FineTuneEventsGetOptions fineTuneEventsGetOptions)
        {
            return this.GetAsync(id, fineTuneEventsGetOptions, null, default);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneEventsGetOptions">The fine-tune events get options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTuneEvents&gt;.</returns>
        public Task<FineTuneEvents> GetAsync(string id, FineTuneEventsGetOptions fineTuneEventsGetOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, fineTuneEventsGetOptions, null, cancellationToken);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;FineTuneEvents&gt;.</returns>
        public Task<FineTuneEvents> GetAsync(string id, RequestOptions requestOptions)
        {
            return this.GetAsync(id, null, requestOptions, default);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTuneEvents&gt;.</returns>
        public Task<FineTuneEvents> GetAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneEventsGetOptions">The fine-tune events get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;FineTuneEvents&gt;.</returns>
        public Task<FineTuneEvents> GetAsync(string id, FineTuneEventsGetOptions fineTuneEventsGetOptions, RequestOptions requestOptions)
        {
            return this.GetAsync(id, fineTuneEventsGetOptions, requestOptions, default);
        }

        /// <summary>
        /// Gets the fine-tune events by the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fineTuneEventsGetOptions">The fine-tune events get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTuneEvents&gt;.</returns>
        public Task<FineTuneEvents> GetAsync(string id, FineTuneEventsGetOptions fineTuneEventsGetOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.RequestAsync(HttpMethod.Get, $"/v1/fine-tunes/{id}/events", fineTuneEventsGetOptions, requestOptions, cancellationToken);
        }
    }
}