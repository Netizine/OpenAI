namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Given a prompt and an instruction, the model will return an edited version of the prompt.
    /// </summary>
    public class EditService : Service<Edit>,
        ICreatable<Edit, EditCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public EditService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public EditService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => "/v1/edits";

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public virtual Edit Create(EditCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Edit&gt;.</returns>
        public virtual Task<Edit> CreateAsync(EditCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.CreateEntityAsync(options, requestOptions, cancellationToken);
        }
    }
}
