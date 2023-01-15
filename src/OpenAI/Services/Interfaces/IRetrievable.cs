namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The retrievable interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TOptions">The type of the options.</typeparam>
    public interface IRetrievable<TEntity, in TOptions>
        where TEntity : IOpenAIEntity, IHasId
        where TOptions : BaseOptions, new()
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="retrieveOptions">The retrieve options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The specified entity.</returns>
        TEntity Get(string id, TOptions retrieveOptions = null, RequestOptions requestOptions = null);

        /// <summary>
        /// Gets the specified identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="retrieveOptions">The retrieve options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The specified entity task.</returns>
        Task<TEntity> GetAsync(string id, TOptions retrieveOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
