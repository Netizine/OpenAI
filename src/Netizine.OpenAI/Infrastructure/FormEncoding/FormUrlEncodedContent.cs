// ReSharper disable once CheckNamespace
namespace OpenAI.Infrastructure.FormEncoding
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    /// <summary>
    /// A container for name/value tuples encoded using <c>application/x-www-form-urlencoded</c>
    /// MIME type.
    /// </summary>
    internal class FormUrlEncodedContent : ByteArrayContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormUrlEncodedContent"/> class.
        /// </summary>
        /// <param name="nameValueCollection">The collection of name/value tuples to encode.</param>
        public FormUrlEncodedContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
            : base(CreateContentByteArray(nameValueCollection))
        {
            Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded")
            {
                CharSet = "utf-8",
            };
        }

        private static byte[] CreateContentByteArray(
            IEnumerable<KeyValuePair<string, string>> nameValueCollection)
        {
            if (nameValueCollection == null)
            {
                throw new ArgumentNullException(nameof(nameValueCollection));
            }

            return Encoding.UTF8.GetBytes(FormEncoder.CreateQueryString(nameValueCollection));
        }
    }
}
