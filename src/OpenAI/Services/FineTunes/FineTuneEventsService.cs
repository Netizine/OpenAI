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
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>FineTuneEvents.</returns>
        public FineTuneEvents Get(string id, FineTuneEventsGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Get, $"/v1/fine-tunes/{id}/events", options, requestOptions);
        }

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;FineTuneEvents&gt;.</returns>
        public Task<FineTuneEvents> GetAsync(string id, FineTuneEventsGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync(HttpMethod.Get, $"/v1/fine-tunes/{id}/events", options, requestOptions, cancellationToken);
        }
    }
}