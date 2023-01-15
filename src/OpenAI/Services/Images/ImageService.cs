namespace OpenAI
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute
#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// ImageService class.
    /// Implements the <see cref="OpenAI.Service{OpenAI.Image}" />.
    /// </summary>
    /// <seealso cref="OpenAI.Service{OpenAI.Image}" />
    public class ImageService : Service<Image>
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageService"/> class.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public ImageService()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageService"/> class.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        public ImageService(IOpenAIClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Gets the base path.
        /// </summary>
        /// <value>The base path.</value>
        public override string BasePath => null;

        /// <summary>
        /// Creates the specified image with the passed options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Image.</returns>
        public virtual Image Create(ImageCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Post, "/v1/images/generations", options, requestOptions);
        }

        /// <summary>
        /// Creates the specified image with the passed options asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> CreateAsync(ImageCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync(HttpMethod.Post, "/v1/images/generations", options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Edits the specified image with the passed options.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Image.</returns>
        public virtual Image Edit(EditImageCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Post, "/v1/images/edits", options, requestOptions);
        }

        /// <summary>
        /// Edits the specified image with the passed options asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> EditAsync(EditImageCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync(HttpMethod.Post, "/v1/images/edits", options, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates the image variation.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Image.</returns>
        public virtual Image CreateVariation(ImageVariationCreateOption options, RequestOptions requestOptions = null)
        {
            return this.Request(HttpMethod.Post, "/v1/images/variations", options, requestOptions);
        }

        /// <summary>
        ///  Creates the image variation asynchronously.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> CreateVariationAsync(ImageVariationCreateOption options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync(HttpMethod.Post, "/v1/images/variations", options, requestOptions, cancellationToken);
        }
    }
}