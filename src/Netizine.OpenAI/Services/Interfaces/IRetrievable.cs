// ReSharper disable once CheckNamespace
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
        /// <returns>The specified entity.</returns>
        TEntity Get(string id);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="retrieveOptions">The retrieve options.</param>
        /// <returns>The specified entity.</returns>
        TEntity Get(string id, TOptions retrieveOptions);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The specified entity.</returns>
        TEntity Get(string id, RequestOptions requestOptions);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="retrieveOptions">The retrieve options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The specified entity.</returns>
        TEntity Get(string id, TOptions retrieveOptions, RequestOptions requestOptions);

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The specified entity task.</returns>
        Task<TEntity> GetAsync(string id);

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The specified entity task.</returns>
        Task<TEntity> GetAsync(string id, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="retrieveOptions">The retrieve options.</param>
        /// <returns>The specified entity task.</returns>
        Task<TEntity> GetAsync(string id, TOptions retrieveOptions);

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="retrieveOptions">The retrieve options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The specified entity task.</returns>
        Task<TEntity> GetAsync(string id, TOptions retrieveOptions, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The specified entity task.</returns>
        Task<TEntity> GetAsync(string id, RequestOptions requestOptions);

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The specified entity task.</returns>
        Task<TEntity> GetAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="retrieveOptions">The retrieve options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The specified entity task.</returns>
        Task<TEntity> GetAsync(string id, TOptions retrieveOptions, RequestOptions requestOptions, CancellationToken cancellationToken);
    }
}
