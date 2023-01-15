namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The creatable interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TOptions">The type of the options.</typeparam>
    public interface ICreatable<TEntity, in TOptions>
        where TEntity : IOpenAIEntity
        where TOptions : BaseOptions, new()
    {
        /// <summary>
        /// Creates a entity with the specified options.
        /// </summary>
        /// <param name="createOptions">The create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The created entity.</returns>
        TEntity Create(TOptions createOptions, RequestOptions requestOptions = null);

        /// <summary>
        /// Creates a entity with the specified options asynchronously.
        /// </summary>
        /// <param name="createOptions">The create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created entity task.</returns>
        Task<TEntity> CreateAsync(TOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
