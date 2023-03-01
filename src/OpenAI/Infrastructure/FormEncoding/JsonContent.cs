using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json.Converters;
using OpenAI.Entities.Chat.Completions;

namespace OpenAI.Infrastructure.FormEncoding
{
    using System;
    using System.Data;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// A container for name/value tuples encoded using <c>application/json</c>
    /// MIME type.
    /// </summary>
    internal class JsonContent : ByteArrayContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonContent"/> class.
        /// </summary>
        /// <param name="nameValueCollection">The collection of name/value tuples to encode.</param>
        public JsonContent(object nameValueCollection)
            : base(CreateContentByteArray(nameValueCollection))
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        private static byte[] CreateContentByteArray(
            object nameValueCollection)
        {
            if (nameValueCollection == null)
            {
                throw new ArgumentNullException(nameof(nameValueCollection));
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore

            };
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(nameValueCollection, jsonSerializerSettings));
        }
    }
}
