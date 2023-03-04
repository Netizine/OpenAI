// ReSharper disable once CheckNamespace
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
        /// <param name="editCreateOptions">The edit create options.</param>
        /// <returns>The created entity.</returns>
        public Edit Create(EditCreateOptions editCreateOptions)
        {
            return this.Create(editCreateOptions, null);
        }

        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="editCreateOptions">The edit create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public virtual Edit Create(EditCreateOptions editCreateOptions, RequestOptions requestOptions)
        {
            return this.CreateEntity(editCreateOptions, requestOptions);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="editCreateOptions">The edit create options.</param>
        /// <returns>Task&lt;Edit&gt;.</returns>
        public Task<Edit> CreateAsync(EditCreateOptions editCreateOptions)
        {
            return this.CreateAsync(editCreateOptions, null, default);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="editCreateOptions">The edit create options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Edit&gt;.</returns>
        public Task<Edit> CreateAsync(EditCreateOptions editCreateOptions, CancellationToken cancellationToken)
        {
            return this.CreateAsync(editCreateOptions, null, cancellationToken);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="editCreateOptions">The edit create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Edit&gt;.</returns>
        public Task<Edit> CreateAsync(EditCreateOptions editCreateOptions, RequestOptions requestOptions)
        {
            return this.CreateAsync(editCreateOptions, requestOptions, default);
        }

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="editCreateOptions">The edit create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Edit&gt;.</returns>
        public virtual Task<Edit> CreateAsync(EditCreateOptions editCreateOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.CreateEntityAsync(editCreateOptions, requestOptions, cancellationToken);
        }
    }
}
