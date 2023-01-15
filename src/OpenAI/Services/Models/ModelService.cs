﻿namespace OpenAI
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

        /// <summary>
        /// Gets the specified model based on the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>The specified entity.</returns>
        public virtual Model Get(string id, ModelGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.GetEntity(id, options, requestOptions);
        }

        /// <summary>
        /// Gets the specified model based on the identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Model&gt;.</returns>
        public virtual Task<Model> GetAsync(string id, ModelGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.GetEntityAsync(id, options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Lists the specified models based on the passed options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>OpenAIList&lt;Model&gt;.</returns>
        public virtual OpenAIList<Model> List(ModelListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListEntities(options, requestOptions);
        }

        /// <summary>
        /// Lists the specified models based on the passed options asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;OpenAIList&lt;Model&gt;&gt;.</returns>
        public virtual Task<OpenAIList<Model>> ListAsync(ModelListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListEntitiesAsync(options, requestOptions, cancellationToken);
        }
    }
}
