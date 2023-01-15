namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for singleton retrievable.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Type of the entity.
    /// </typeparam>
    public interface ISingletonRetrievable<TEntity>
        where TEntity : IOpenAIEntity
    {
        /// <summary>
        /// Gets a T entity using the given request options.
        /// </summary>
        /// <param name="requestOptions">
        /// (Optional) The request options to get.</param>
        /// <returns>A TEntity.</returns>
        TEntity Get(RequestOptions requestOptions = null);

        /// <summary>
        /// Gets a T entity using the given request options asynchronously.
        /// </summary>
        /// <param name="requestOptions">
        /// (Optional) Options for controlling the request.
        /// </param>
        /// <param name="cancellationToken">
        /// (Optional) A token that allows processing to be cancelled.
        /// </param>
        /// <returns>A TEntity task.</returns>
        Task<TEntity> GetAsync(RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
