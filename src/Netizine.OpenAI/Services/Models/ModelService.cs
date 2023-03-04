// ReSharper disable once CheckNamespace
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

        /// <summary>
        /// Gets the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public virtual Task<Model> GetAsync(string id)
        {
            return this.GetAsync(id, null, null, default);
        }

        /// <summary>
        /// Gets the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public virtual Task<Model> GetAsync(string id, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelGetOptions">The model get options.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public virtual Task<Model> GetAsync(string id, ModelGetOptions modelGetOptions)
        {
            return this.GetAsync(id, modelGetOptions, null, default);
        }

        /// <summary>
        /// Gets the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelGetOptions">The model get options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public virtual Task<Model> GetAsync(string id, ModelGetOptions modelGetOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, modelGetOptions, null, cancellationToken);
        }

        /// <summary>
        /// Gets the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public virtual Task<Model> GetAsync(string id, RequestOptions requestOptions)
        {
            return this.GetAsync(id, null, requestOptions, default);
        }

        /// <summary>
        /// Gets the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public virtual Task<Model> GetAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.GetAsync(id, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Gets the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelGetOptions">The model get options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
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
        /// <returns>The deleted entity.</returns>
        public Model Delete(string id)
        {
            return this.Delete(id, null, null);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelDeleteOptions">The model delete options.</param>
        /// <returns>The deleted entity.</returns>
        public Model Delete(string id, ModelDeleteOptions modelDeleteOptions)
        {
            return this.Delete(id, modelDeleteOptions, null);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The deleted entity.</returns>
        public Model Delete(string id, RequestOptions requestOptions)
        {
            return this.Delete(id, null, requestOptions);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelDeleteOptions">The model delete options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The deleted entity.</returns>
        public Model Delete(string id, ModelDeleteOptions modelDeleteOptions, RequestOptions requestOptions)
        {
            return this.DeleteEntity(id, modelDeleteOptions, requestOptions);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public Task<Model> DeleteAsync(string id)
        {
            return this.DeleteAsync(id, null, null, default);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public Task<Model> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            return this.DeleteAsync(id, null, null, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelDeleteOptions">The model delete options.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public Task<Model> DeleteAsync(string id, ModelDeleteOptions modelDeleteOptions)
        {
            return this.DeleteAsync(id, modelDeleteOptions, null, default);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelDeleteOptions">The model delete options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public Task<Model> DeleteAsync(string id, ModelDeleteOptions modelDeleteOptions, CancellationToken cancellationToken)
        {
            return this.DeleteAsync(id, modelDeleteOptions, null, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public Task<Model> DeleteAsync(string id, RequestOptions requestOptions)
        {
            return this.DeleteAsync(id, null, requestOptions, default);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public Task<Model> DeleteAsync(string id, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.DeleteAsync(id, null, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelDeleteOptions">The model delete options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public Task<Model> DeleteAsync(string id, ModelDeleteOptions modelDeleteOptions, RequestOptions requestOptions)
        {
            return this.DeleteAsync(id, modelDeleteOptions, requestOptions, default);
        }

        /// <summary>
        /// Deletes the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="modelDeleteOptions">The model delete options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public Task<Model> DeleteAsync(string id, ModelDeleteOptions modelDeleteOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return this.DeleteEntityAsync(id, modelDeleteOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists the specified models based on the passed options.
        /// </summary>
        /// <returns>OpenAIList&lt;Model&gt;.</returns>
        public virtual OpenAIList<Model> List()
        {
            return this.List(null, null);
        }

        /// <summary>
        /// Lists the specified models based on the passed options.
        /// </summary>
        /// <param name="modelListOptions">The model list options.</param>
        /// <returns>OpenAIList&lt;Model&gt;.</returns>
        public virtual OpenAIList<Model> List(ModelListOptions modelListOptions)
        {
            return this.List(modelListOptions, null);
        }

        /// <summary>
        /// Lists the specified models based on the passed options.
        /// </summary>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;Model&gt;.</returns>
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
