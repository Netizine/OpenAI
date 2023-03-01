namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Given a prompt, the model will return one or more predicted completions, and can also return the probabilities of alternative tokens at each position.
    /// </summary>
    public class ChatGPT3CompletionService : Service<ChatCompletion>,
        ICreatable<ChatCompletion, ChatGPT3CompletionCreateOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatGPT3CompletionService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public ChatGPT3CompletionService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatGPT3CompletionService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public ChatGPT3CompletionService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => "/v1/chat/completions";

        /// <summary>
        /// Creates a chat gpt3 completion entity with the specified options.
        /// </summary>
        /// <param name="chatGPT3CompletionCreateOptions">The chat gpt-3 completion create options.</param>
        /// <returns>The created entity.</returns>
        public virtual ChatCompletion Create(ChatGPT3CompletionCreateOptions chatGPT3CompletionCreateOptions)
        {
            return this.Create(chatGPT3CompletionCreateOptions, null);
        }

        /// <summary>
        /// Creates a chat gpt3 completion entity with the specified options.
        /// </summary>
        /// <param name="chatGPT3CompletionCreateOptions">The chat gpt-3 completion create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        public virtual ChatCompletion Create(ChatGPT3CompletionCreateOptions chatGPT3CompletionCreateOptions, RequestOptions requestOptions)
        {
            return this.CreateEntity(chatGPT3CompletionCreateOptions, requestOptions);
        }

        /// <summary>
        /// Creates a chat gpt3 completion entity with the specified options asynchronously.
        /// </summary>
        /// <param name="chatGPT3CompletionCreateOptions">The chat gpt-3 completion create options.</param>
        /// <returns>Task&lt;Completion&gt;.</returns>
        public virtual Task<ChatCompletion> CreateAsync(ChatGPT3CompletionCreateOptions chatGPT3CompletionCreateOptions)
        {
            return this.CreateAsync(chatGPT3CompletionCreateOptions, null, default);
        }

        /// <summary>
        /// Creates a chat gpt3 completion entity with the specified options asynchronously.
        /// </summary>
        /// <param name="chatGPT3CompletionCreateOptions">The chat gpt-3 completion create options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Completion&gt;.</returns>
        public virtual Task<ChatCompletion> CreateAsync(ChatGPT3CompletionCreateOptions chatGPT3CompletionCreateOptions, CancellationToken cancellationToken)
        {
            return this.CreateAsync(chatGPT3CompletionCreateOptions, null, cancellationToken);
        }

        /// <summary>
        /// Creates a chat gpt3 completion entity with the specified options asynchronously.
        /// </summary>
        /// <param name="chatGPT3CompletionCreateOptions">The chat gpt-3 completion create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Completion&gt;.</returns>
        public virtual Task<ChatCompletion> CreateAsync(ChatGPT3CompletionCreateOptions chatGPT3CompletionCreateOptions, RequestOptions requestOptions)
        {
            return this.CreateAsync(chatGPT3CompletionCreateOptions, requestOptions, default);
        }

        /// <summary>
        /// Creates a chat gpt3 completion entity with the specified options asynchronously.
        /// </summary>
        /// <param name="chatGPT3CompletionCreateOptions">The chat gpt-3 completion create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Completion&gt;.</returns>
        public virtual Task<ChatCompletion> CreateAsync(ChatGPT3CompletionCreateOptions chatGPT3CompletionCreateOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.CreateEntityAsync(chatGPT3CompletionCreateOptions, requestOptions, cancellationToken);
        }
    }
}
