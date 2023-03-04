// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The deletable interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TOptions">The type of the options.</typeparam>
    public interface IDeletable<TEntity, in TOptions>
        where TEntity : IOpenAIEntity, IHasId
        where TOptions : BaseOptions, new()
    {
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted entity.</returns>
        TEntity Delete(string id);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <returns>The deleted entity.</returns>
        TEntity Delete(string id, TOptions options);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The deleted entity.</returns>
        TEntity Delete(string id, RequestOptions requestOptions);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The deleted entity.</returns>
        TEntity Delete(string id, TOptions options, RequestOptions requestOptions);

        /// <summary>
        /// Deletes the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted entity task.</returns>
        Task<TEntity> DeleteAsync(string id);

        /// <summary>
        /// Deletes the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deleted entity task.</returns>
        Task<TEntity> DeleteAsync(string id, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <returns>The deleted entity task.</returns>
        Task<TEntity> DeleteAsync(string id, TOptions options);

        /// <summary>
        /// Deletes the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deleted entity task.</returns>
        Task<TEntity> DeleteAsync(string id, TOptions options, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The deleted entity task.</returns>
        Task<TEntity> DeleteAsync(string id, RequestOptions requestOptions);

        /// <summary>
        /// Deletes the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deleted entity task.</returns>
        Task<TEntity> DeleteAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The deleted entity task.</returns>
        Task<TEntity> DeleteAsync(string id, TOptions options, RequestOptions requestOptions);

        /// <summary>
        /// Deletes the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deleted entity task.</returns>
        Task<TEntity> DeleteAsync(string id, TOptions options, RequestOptions requestOptions, CancellationToken cancellationToken);
    }
}
