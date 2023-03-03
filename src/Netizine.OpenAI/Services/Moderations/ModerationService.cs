// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// Given a input text, outputs if the model classifies it as violating OpenAI's content policy.
    /// Implements the <see cref="OpenAI.Service{OpenAI.Moderation}" />.
    /// </summary>
    /// <seealso cref="OpenAI.Service{OpenAI.Moderation}" />
    public class ModerationService : Service<Moderation>
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModerationService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public ModerationService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModerationService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public ModerationService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => "/v1/moderations";

        public Moderation Get(ModerationGetOptions options)
        {
            return this.Get(options, null);
        }

        /// <summary>
        /// Gets the specified moderation results.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Moderation.</returns>
        public Moderation Get(ModerationGetOptions options, RequestOptions requestOptions)
        {
            return this.Request(HttpMethod.Post, "/v1/moderations", options, requestOptions);
        }

        /// <summary>
        /// Gets the specified moderation results asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>Task&lt;Moderation&gt;.</returns>
        public Task<Moderation> GetAsync(ModerationGetOptions options)
        {
            return this.GetAsync(options, null, default);
        }

        /// <summary>
        /// Gets the specified moderation results asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Moderation&gt;.</returns>
        public Task<Moderation> GetAsync(ModerationGetOptions options, CancellationToken cancellationToken)
        {
            return this.GetAsync(options, null, cancellationToken);
        }

        /// <summary>
        /// Gets the specified moderation results asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Moderation&gt;.</returns>
        public Task<Moderation> GetAsync(ModerationGetOptions options, RequestOptions requestOptions)
        {
            return this.GetAsync(options, requestOptions, default);
        }

        /// <summary>
        /// Gets the specified moderation results asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Moderation&gt;.</returns>
        public Task<Moderation> GetAsync(ModerationGetOptions options, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.RequestAsync(HttpMethod.Post, "/v1/moderations", options, requestOptions, cancellationToken);
        }
    }
}
