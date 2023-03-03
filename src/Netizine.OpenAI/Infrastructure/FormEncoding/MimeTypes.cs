namespace OpenAI.Infrastructure.FormEncoding
{
    using System;
    using System.Collections.Generic;

    internal static class MimeTypes
    {
        // Dictionary mapping file extensions to MIME types. OpenAI's file upload API accepts
        // only a limited set of file types that are listed below. It's not hugely important if
        // a type is missing or incorrect, as the server doesn't trust the Content-Type header
        // and checks the actual file contents anyway.
        private static readonly IDictionary<string, string> MimeTypeMap
            = new Dictionary<string, string>
        {
            { ".csv", "text/csv" },
            { ".gif", "image/gif" },
            { ".jpeg", "image/jpeg" },
            { ".jpg", "image/jpeg" },
            { ".png", "image/png" },
        };

        /// <summary>Gets the content type for a given file extension.</summary>
        /// <param name="extension">The file extension.</param>
        /// <returns>
        /// The content type, or <c>application/octet-stream</c> if the file extension is unknown.
        /// </returns>
        public static string GetMimeType(string extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException(nameof(extension));
            }

            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            return MimeTypeMap.TryGetValue(extension, out var mime) ? mime : "application/octet-stream";
        }
    }
}
