// ReSharper disable once CheckNamespace
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
        /// Creates the specified image with the specified options.
        /// </summary>
        /// <param name="imageCreateOptions">The image create options.</param>
        /// <returns>Image.</returns>
        public virtual Image Create(ImageCreateOptions imageCreateOptions)
        {
            return Create(imageCreateOptions, null);
        }

        /// <summary>
        /// Creates the specified image with the specified options.
        /// </summary>
        /// <param name="imageCreateOptions">The image create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Image.</returns>
        public virtual Image Create(ImageCreateOptions imageCreateOptions, RequestOptions requestOptions)
        {
            return Request(HttpMethod.Post, "/v1/images/generations", imageCreateOptions, requestOptions);
        }

        /// <summary>
        /// Creates the specified image with the specified options asynchronously.
        /// </summary>
        /// <param name="imageCreateOptions">The image create options.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> CreateAsync(ImageCreateOptions imageCreateOptions)
        {
            return CreateAsync(imageCreateOptions, null, default);
        }

        /// <summary>
        /// Creates the specified image with the specified options asynchronously.
        /// </summary>
        /// <param name="imageCreateOptions">The image create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> CreateAsync(ImageCreateOptions imageCreateOptions, RequestOptions requestOptions)
        {
            return CreateAsync(imageCreateOptions, requestOptions, default);
        }

        /// <summary>
        /// Creates the specified image with the specified options asynchronously.
        /// </summary>
        /// <param name="imageCreateOptions">The image create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> CreateAsync(ImageCreateOptions imageCreateOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return RequestAsync(HttpMethod.Post, "/v1/images/generations", imageCreateOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Edits the image with the specified options.
        /// </summary>
        /// <param name="editImageCreateOptions">The edit image create options.</param>
        /// <returns>Image.</returns>
        public virtual Image Edit(EditImageCreateOptions editImageCreateOptions)
        {
            return Edit(editImageCreateOptions, null);
        }

        /// <summary>
        /// Edits the image with the specified options.
        /// </summary>
        /// <param name="editImageCreateOptions">The edit image create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Image.</returns>
        public virtual Image Edit(EditImageCreateOptions editImageCreateOptions, RequestOptions requestOptions)
        {
            return Request(HttpMethod.Post, "/v1/images/edits", editImageCreateOptions, requestOptions);
        }

        /// <summary>
        /// Edits the image with the specified options asynchronously.
        /// </summary>
        /// <param name="editImageCreateOptions">The edit image create options.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> EditAsync(EditImageCreateOptions editImageCreateOptions)
        {
            return EditAsync(editImageCreateOptions, null, default);
        }

        /// <summary>
        /// Edits the image with the specified options asynchronously.
        /// </summary>
        /// <param name="editImageCreateOptions">The edit image create options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> EditAsync(EditImageCreateOptions editImageCreateOptions, CancellationToken cancellationToken)
        {
            return EditAsync(editImageCreateOptions, null, cancellationToken);
        }

        /// <summary>
        /// Edits the image with the specified options asynchronously.
        /// </summary>
        /// <param name="editImageCreateOptions">The edit image create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> EditAsync(EditImageCreateOptions editImageCreateOptions, RequestOptions requestOptions)
        {
            return EditAsync(editImageCreateOptions, requestOptions, default);
        }

        /// <summary>
        /// Edits the image with the specified options asynchronously.
        /// </summary>
        /// <param name="editImageCreateOptions">The edit image create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> EditAsync(EditImageCreateOptions editImageCreateOptions, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return RequestAsync(HttpMethod.Post, "/v1/images/edits", editImageCreateOptions, requestOptions, cancellationToken);
        }

        /// <summary>
        /// Creates a image variation.
        /// </summary>
        /// <param name="imageVariationCreateOption">The image variation create options.</param>
        /// <returns>Image.</returns>
        public virtual Image CreateVariation(ImageVariationCreateOption imageVariationCreateOption)
        {
            return CreateVariation(imageVariationCreateOption, null);
        }

        /// <summary>
        /// Creates image variations.
        /// </summary>
        /// <param name="imageVariationCreateOption">The image variation create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Image.</returns>
        public virtual Image CreateVariation(ImageVariationCreateOption imageVariationCreateOption, RequestOptions requestOptions)
        {
            return Request(HttpMethod.Post, "/v1/images/variations", imageVariationCreateOption, requestOptions);
        }

        /// <summary>
        ///  Creates image variations asynchronously.
        /// </summary>
        /// <param name="imageVariationCreateOption">The image variation create options.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> CreateVariationAsync(ImageVariationCreateOption imageVariationCreateOption)
        {
            return CreateVariationAsync(imageVariationCreateOption, null, default);
        }

        /// <summary>
        ///  Creates image variations asynchronously.
        /// </summary>
        /// <param name="imageVariationCreateOption">The image variation create options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> CreateVariationAsync(ImageVariationCreateOption imageVariationCreateOption, CancellationToken cancellationToken)
        {
            return CreateVariationAsync(imageVariationCreateOption, null, cancellationToken);
        }

        /// <summary>
        ///  Creates image variations asynchronously.
        /// </summary>
        /// <param name="imageVariationCreateOption">The image variation create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> CreateVariationAsync(ImageVariationCreateOption imageVariationCreateOption, RequestOptions requestOptions)
        {
            return CreateVariationAsync(imageVariationCreateOption, requestOptions, default);
        }

        /// <summary>
        ///  Creates image variations asynchronously.
        /// </summary>
        /// <param name="imageVariationCreateOption">The image variation create options.</param>
        /// <param name="requestOptions">The request options.</param>
        /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Task&lt;Image&gt;.</returns>
        public virtual Task<Image> CreateVariationAsync(ImageVariationCreateOption imageVariationCreateOption, RequestOptions requestOptions, CancellationToken cancellationToken)
        {
            return RequestAsync(HttpMethod.Post, "/v1/images/variations", imageVariationCreateOption, requestOptions, cancellationToken);
        }
    }
}