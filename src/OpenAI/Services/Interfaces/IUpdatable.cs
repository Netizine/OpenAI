namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The IUpdatable Interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TOptions">The type of the t options.</typeparam>
    public interface IUpdatable<TEntity, in TOptions>
        where TEntity : IOpenAIEntity, IHasId
        where TOptions : BaseOptions, new()
    {
        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updateOptions">The update options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>TEntity.</returns>
        TEntity Update(string id, TOptions updateOptions, RequestOptions requestOptions = null);

        /// <summary>
        /// Updates the specified identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updateOptions">The update options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        Task<TEntity> UpdateAsync(string id, TOptions updateOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
