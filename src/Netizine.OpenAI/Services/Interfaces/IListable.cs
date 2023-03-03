namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The listable interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TOptions">The type of the options.</typeparam>
    public interface IListable<TEntity, in TOptions>
        where TEntity : IOpenAIEntity, IHasId
        where TOptions : ListOptions, new()
    {
        /// <summary>
        /// Lists the specified entities based on the provided list options.
        /// </summary>
        /// <returns>A list of the specified entities.</returns>
        OpenAIList<TEntity> List();

        /// <summary>
        /// Lists the specified entities based on the provided list options.
        /// </summary>
        /// <param name="listOptions">The list options.</param>
        /// <returns>A list of the specified entities.</returns>
        OpenAIList<TEntity> List(TOptions listOptions);

        /// <summary>
        /// Lists the specified entities based on the provided list options.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>A list of the specified entities.</returns>
        OpenAIList<TEntity> List(RequestOptions requestOptions);

        /// <summary>
        /// Lists the specified entities based on the provided list options.
        /// </summary>
        /// <param name="listOptions">The list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>A list of the specified entities.</returns>
        OpenAIList<TEntity> List(TOptions listOptions, RequestOptions requestOptions);

        /// <summary>
        /// Lists the specified entities based on the provided list options asynchronously.
        /// </summary>
        /// <returns>A list of the specified entities task.</returns>
        Task<OpenAIList<TEntity>> ListAsync();

        /// <summary>
        /// Lists the specified entities based on the provided list options asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of the specified entities task.</returns>
        Task<OpenAIList<TEntity>> ListAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Lists the specified entities based on the provided list options asynchronously.
        /// </summary>
        /// <param name="listOptions">The list options.</param>
        /// <returns>A list of the specified entities task.</returns>
        Task<OpenAIList<TEntity>> ListAsync(TOptions listOptions);

        /// <summary>
        /// Lists the specified entities based on the provided list options asynchronously.
        /// </summary>
        /// <param name="listOptions">The list options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of the specified entities task.</returns>
        Task<OpenAIList<TEntity>> ListAsync(TOptions listOptions, CancellationToken cancellationToken);

        /// <summary>
        /// Lists the specified entities based on the provided list options asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>A list of the specified entities task.</returns>
        Task<OpenAIList<TEntity>> ListAsync(RequestOptions requestOptions);

        /// <summary>
        /// Lists the specified entities based on the provided list options asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of the specified entities task.</returns>
        Task<OpenAIList<TEntity>> ListAsync(RequestOptions requestOptions, CancellationToken cancellationToken);

        /// <summary>
        /// Lists the specified entities based on the provided list options asynchronously.
        /// </summary>
        /// <param name="listOptions">The list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>A list of the specified entities task.</returns>
        Task<OpenAIList<TEntity>> ListAsync(TOptions listOptions, RequestOptions requestOptions);

        /// <summary>
        /// Lists the specified entities based on the provided list options asynchronously.
        /// </summary>
        /// <param name="listOptions">The list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of the specified entities task.</returns>
        Task<OpenAIList<TEntity>> ListAsync(TOptions listOptions, RequestOptions requestOptions, CancellationToken cancellationToken);
    }
}
