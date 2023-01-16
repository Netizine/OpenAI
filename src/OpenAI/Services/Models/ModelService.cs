namespace OpenAI
{
    using System.Threading;
    using System.Threading.Tasks;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// ModelService class.
    /// Implements the <see cref="OpenAI.Service{OpenAI.Model}" />.
    /// Implements the <see cref="OpenAI.IListable{OpenAI.Model, OpenAI.ModelListOptions}" />.
    /// Implements the <see cref="OpenAI.IRetrievable{OpenAI.Model, OpenAI.ModelGetOptions}" />.
    /// Implements the <see cref="OpenAI.IDeletable{OpenAI.Model, OpenAI.ModelDeleteOptions}" />.
    /// </summary>
    /// <seealso cref="OpenAI.Service{OpenAI.Model}" />
    /// <seealso cref="OpenAI.IListable{OpenAI.Model, OpenAI.ModelListOptions}" />
    /// <seealso cref="OpenAI.IRetrievable{OpenAI.Model, OpenAI.ModelGetOptions}" />
    /// <seealso cref="OpenAI.IDeletable{OpenAI.Model, OpenAI.ModelDeleteOptions}" />
    public class ModelService : Service<Model>,
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
        IListable<Model, ModelListOptions>,
        IRetrievable<Model, ModelGetOptions>,
        IDeletable<Model, ModelDeleteOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public ModelService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public ModelService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => "/v1/models";

        /// <summary>
        /// Gets the specified model based on the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Model.</returns>
        public virtual Model Get(string id)
        {
            return this.Get(id, null, null);
        }

        /// <summary>
        /// Gets the specified model based on the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelGetOptions">The model get options.</param>
        /// <returns>Model.</returns>
        public virtual Model Get(string id, ModelGetOptions modelGetOptions)
        {
            return this.Get(id, modelGetOptions, null);
        }

        /// <summary>
        /// Gets the specified model based on the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Model.</returns>
        public virtual Model Get(string id, RequestOptions requestOptions)
        {
            return this.Get(id, null, requestOptions);
        }

        /// <summary>
        /// Gets the specified model based on the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelGetOptions">The model get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Model.</returns>
        public virtual Model Get(string id, ModelGetOptions modelGetOptions, RequestOptions requestOptions)
        {
            return this.GetEntity(id, modelGetOptions, requestOptions);
        }

        public virtual Task<Model> GetAsync(string id)
        {
            return this.GetAsync(id, null, null, default);
        }

        public virtual Task<Model> GetAsync(string id, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, null, cancellationToken);
        }

        public virtual Task<Model> GetAsync(string id, ModelGetOptions modelGetOptions)
        {
            return this.GetAsync(id, modelGetOptions, null, default);
        }

        public virtual Task<Model> GetAsync(string id, ModelGetOptions modelGetOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, modelGetOptions, null, cancellationToken);
        }

        public virtual Task<Model> GetAsync(string id, RequestOptions requestOptions)
        {
            return this.GetAsync(id, null, requestOptions, default);
        }

        public virtual Task<Model> GetAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, requestOptions, cancellationToken);
        }

        public virtual Task<Model> GetAsync(string id, ModelGetOptions modelGetOptions, RequestOptions requestOptions)
        {
            return this.GetAsync(id, modelGetOptions, requestOptions, default);
        }

        /// <summary>
        /// Gets the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelGetOptions">The model get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public virtual Task<Model> GetAsync(string id, ModelGetOptions modelGetOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.GetEntityAsync(id, modelGetOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The deleted entity.</returns>
        public Model Delete(string id, ModelDeleteOptions options = null, RequestOptions requestOptions = null)
        {
            return this.DeleteEntity(id, options, requestOptions);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deleted entity task.</returns>
        public Task<Model> DeleteAsync(string id, ModelDeleteOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.DeleteEntityAsync(id, options, requestOptions, cancellationToken);
        }

        public virtual OpenAIList<Model> List()
        {
            return this.List(null, null);
        }

        public virtual OpenAIList<Model> List(ModelListOptions modelListOptions)
        {
            return this.List(modelListOptions, null);
        }

        public virtual OpenAIList<Model> List(RequestOptions requestOptions)
        {
            return this.List(null, requestOptions);
        }

        /// <summary>
        /// Lists the specified models based on the passed options.
        /// </summary>
        /// <param name="modelListOptions">The model list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;Model&gt;.</returns>
        public virtual OpenAIList<Model> List(ModelListOptions modelListOptions, RequestOptions requestOptions)
        {
            return this.ListEntities(modelListOptions, requestOptions);
        }

        /// <summary>
        /// Lists the specified models based on the passed options asynchronously.
        /// </summary>
        /// <returns>Task&lt;OpenAIList&lt;Model&gt;&gt;.</returns>
        public Task<OpenAIList<Model>> ListAsync()
        {
            return this.ListAsync(null, null, default);
        }

        /// <summary>
        /// Lists the specified models based on the passed options asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Model&gt;&gt;.</returns>
        public Task<OpenAIList<Model>> ListAsync(CancellationToken cancellationToken)
        {
            return this.ListAsync(null, null, cancellationToken);
        }

        /// <summary>
        /// Lists the specified models based on the passed options asynchronously.
        /// </summary>
        /// <param name="modelListOptions">The model list options.</param>
        /// <returns>Task&lt;OpenAIList&lt;Model&gt;&gt;.</returns>
        public Task<OpenAIList<Model>> ListAsync(ModelListOptions modelListOptions)
        {
            return this.ListAsync(modelListOptions, null, default);
        }

        /// <summary>
        /// Lists the specified models based on the passed options asynchronously.
        /// </summary>
        /// <param name="modelListOptions">The model list options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Model&gt;&gt;.</returns>
        public Task<OpenAIList<Model>> ListAsync(ModelListOptions modelListOptions, CancellationToken cancellationToken)
        {
            return this.ListAsync(modelListOptions, null, cancellationToken);
        }

        /// <summary>
        /// Lists the specified models based on the passed options asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;OpenAIList&lt;Model&gt;&gt;.</returns>
        public Task<OpenAIList<Model>> ListAsync(RequestOptions requestOptions)
        {
            return this.ListAsync(null, requestOptions, default);
        }

        /// <summary>
        /// Lists the specified models based on the passed options asynchronously.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Model&gt;&gt;.</returns>
        public Task<OpenAIList<Model>> ListAsync(RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.ListAsync(null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists the specified models based on the passed options asynchronously.
        /// </summary>
        /// <param name="modelListOptions">The model list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;OpenAIList&lt;Model&gt;&gt;.</returns>
        public Task<OpenAIList<Model>> ListAsync(ModelListOptions modelListOptions, RequestOptions requestOptions)
        {
            return this.ListAsync(modelListOptions, requestOptions, default);
        }

        /// <summary>
        /// Lists the specified models based on the passed options asynchronously.
        /// </summary>
        /// <param name="modelListOptions">The model list options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Model&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Model>> ListAsync(ModelListOptions modelListOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.ListEntitiesAsync(modelListOptions, requestOptions, cancellationToken);
        }
    }
}
