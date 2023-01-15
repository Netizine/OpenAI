namespace OpenAI.Infrastructure.FormEncoding
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using Newtonsoft.Json;

    /// <summary>
    /// This class provides methods to serialize various objects with
    /// <c>application/x-www-form-urlencoded</c> encoding. This is used to encode request
    /// parameters to be sent to OpenAI's API.
    /// </summary>
    internal static class FormEncoder
    {
        /// <summary>Creates an <see cref="HttpContent"/> for a given options class.</summary>
        /// <param name="options">The options class.</param>
        /// <returns>The <see cref="HttpContent"/>.</returns>
        public static HttpContent CreateHttpContent(BaseOptions options)
        {
            // If options is null, we create an empty FormUrlEncodedContent because we still
            // want to send the Content-Type header.
            if (options == null)
            {
                return new FormUrlEncodedContent(new List<KeyValuePair<string, string>>());
            }

            var optionsType = options.GetType();
            if (optionsType == typeof(CompletionCreateOptions) || optionsType == typeof(EditCreateOptions) || optionsType == typeof(ImageCreateOptions) || optionsType == typeof(EmbeddingCreateOptions) || optionsType == typeof(FineTuneCreateOptions) || optionsType == typeof(ModerationGetOptions))
            {
                return new JsonContent(options);
            }

            if (optionsType == typeof(EditImageCreateOptions))
            {
                var multipartContent = new System.Net.Http.MultipartFormDataContent();
                var editImageCreateOptions = (EditImageCreateOptions)options;
                multipartContent.Add(new ByteArrayContent(editImageCreateOptions.ImageSource), "image", editImageCreateOptions.Image);

                if (!string.IsNullOrEmpty(editImageCreateOptions.Mask))
                {
                    multipartContent.Add(new ByteArrayContent(editImageCreateOptions.MaskSource), "mask", editImageCreateOptions.Mask);
                }

                multipartContent.Add(new StringContent(editImageCreateOptions.Prompt), "prompt");

                if (editImageCreateOptions.N != null && editImageCreateOptions.N > 0)
                {
                    multipartContent.Add(new StringContent(editImageCreateOptions.N.ToString()), "n");
                }

                if (!string.IsNullOrEmpty(editImageCreateOptions.Size))
                {
                    multipartContent.Add(new StringContent(editImageCreateOptions.Size), "size");
                }

                if (!string.IsNullOrEmpty(editImageCreateOptions.ResponseFormat))
                {
                    multipartContent.Add(new StringContent(editImageCreateOptions.ResponseFormat), "response_format");
                }

                if (!string.IsNullOrEmpty(editImageCreateOptions.User))
                {
                    multipartContent.Add(new StringContent(editImageCreateOptions.User), "user");
                }

                return multipartContent;
            }

            if (optionsType == typeof(ImageVariationCreateOption))
            {
                var multipartContent = new System.Net.Http.MultipartFormDataContent();
                var imageVariationCreateOption = (ImageVariationCreateOption)options;
                multipartContent.Add(new ByteArrayContent(imageVariationCreateOption.ImageSource), "image", imageVariationCreateOption.Image);

                if (imageVariationCreateOption.N != null && imageVariationCreateOption.N > 0)
                {
                    multipartContent.Add(new StringContent(imageVariationCreateOption.N.ToString()), "n");
                }

                if (!string.IsNullOrEmpty(imageVariationCreateOption.Size))
                {
                    multipartContent.Add(new StringContent(imageVariationCreateOption.Size), "size");
                }

                if (!string.IsNullOrEmpty(imageVariationCreateOption.ResponseFormat))
                {
                    multipartContent.Add(new StringContent(imageVariationCreateOption.ResponseFormat), "response_format");
                }

                if (!string.IsNullOrEmpty(imageVariationCreateOption.User))
                {
                    multipartContent.Add(new StringContent(imageVariationCreateOption.User), "user");
                }

                return multipartContent;
            }

            if (optionsType == typeof(FileCreateOptions))
            {
                var multipartContent = new System.Net.Http.MultipartFormDataContent();
                var fileCreateOptions = (FileCreateOptions)options;
                multipartContent.Add(new ByteArrayContent(fileCreateOptions.FileSource), "file", fileCreateOptions.File);

                if (!string.IsNullOrEmpty(fileCreateOptions.Purpose))
                {
                    multipartContent.Add(new StringContent(fileCreateOptions.Purpose), "purpose");
                }

                return multipartContent;
            }

            // if (optionsType == typeof(OpenAI.FineTuneCreateOptions))
            // {
            //     var multipartContent = new System.Net.Http.MultipartFormDataContent();
            //     var fineTuneCreateOptions = (OpenAI.FineTuneCreateOptions)options;
            //     multipartContent.Add(new ByteArrayContent(fineTuneCreateOptions.TrainingFileSource), "training_file", fineTuneCreateOptions.TrainingFile);
            //
            //     if (!string.IsNullOrEmpty(fineTuneCreateOptions.ValidationFile))
            //     {
            //         multipartContent.Add(new ByteArrayContent(fineTuneCreateOptions.ValidationFileSource), "validation_file", fineTuneCreateOptions.ValidationFile);
            //     }
            //
            //     if (!string.IsNullOrEmpty(fineTuneCreateOptions.Model))
            //     {
            //         multipartContent.Add(new StringContent(fineTuneCreateOptions.Model), "model");
            //     }
            //
            //     if (fineTuneCreateOptions.NEpochs != null)
            //     {
            //         multipartContent.Add(new StringContent(fineTuneCreateOptions.NEpochs.ToString()), "n_epochs");
            //     }
            //
            //     if (fineTuneCreateOptions.BatchSize != null)
            //     {
            //         multipartContent.Add(new StringContent(fineTuneCreateOptions.BatchSize.ToString()), "batch_size");
            //     }
            //
            //     if (fineTuneCreateOptions.LearningRateMultiplier != null)
            //     {
            //         multipartContent.Add(new StringContent(fineTuneCreateOptions.LearningRateMultiplier.ToString()), "learning_rate_multiplier");
            //     }
            //
            //     return multipartContent;
            // }

            // Fall back if we don't have a special case for this type.
            var flatParams = FlattenParamsValue(options, null);

            // If all parameters have been encoded as strings, then the content can be represented
            // with application/x-www-form-url-encoded encoding. Otherwise, use
            // multipart/form-data encoding.
            if (flatParams.All(kvp => kvp.Value is string))
            {
                var flatParamsString = flatParams
                    .Select(kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value as string));
                return new FormUrlEncodedContent(flatParamsString);
            }

            return new MultipartFormDataContent(flatParams);
        }

        /// <summary>Creates the HTTP query string for a given options class.</summary>
        /// <param name="options">The options class.</param>
        /// <returns>The query string.</returns>
        public static string CreateQueryString(BaseOptions options)
        {
            var flatParams = FlattenParamsValue(options, null)
                .Where(kvp => kvp.Value is string)
                .Select(kvp => new KeyValuePair<string, string>(
                    kvp.Key,
                    kvp.Value as string));
            return CreateQueryString(flatParams);
        }

        /// <summary>Creates the HTTP query string for a collection of name/value tuples.</summary>
        /// <param name="nameValueCollection">The collection of name/value tuples.</param>
        /// <returns>The query string.</returns>
        public static string CreateQueryString(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
        {
            return string.Join(
                "&",
                nameValueCollection.Select(kvp => $"{UrlEncode(kvp.Key)}={UrlEncode(kvp.Value)}"));
        }

        /// <summary>URL-encodes a string.</summary>
        /// <param name="value">The string to URL-encode.</param>
        /// <returns>The URL-encoded string.</returns>
        private static string UrlEncode(string value)
        {
            if (value == null)
            {
                return null;
            }

            // Don't use strict form encoding by changing the square bracket control
            // characters back to their literals. This is fine by the server, and
            // makes these parameter strings easier to read.
            return WebUtility.UrlEncode(value)
                ?.Replace("%5B", "[")
                .Replace("%5D", "]");
        }

        /// <summary>
        /// Returns a list of parameters for a given value. The value can be basically anything, as
        /// long as it can be encoded in some way.
        /// </summary>
        /// <param name="value">The value for which to create the list of parameters.</param>
        /// <param name="keyPrefix">The key under which new keys should be nested, if any.</param>
        /// <returns>The list of parameters.</returns>
        private static List<KeyValuePair<string, object>> FlattenParamsValue(object value, string keyPrefix)
        {
            List<KeyValuePair<string, object>> flatParams;

#pragma warning disable IDE0066 // Convert switch statement to expression
            switch (value)
            {
                case null:
                    flatParams = SingleParam(keyPrefix, string.Empty);
                    break;

                case IAnyOf anyOf:
                    flatParams = FlattenParamsAnyOf(anyOf, keyPrefix);
                    break;

                case INestedOptions options:
                    flatParams = FlattenParamsOptions(options, keyPrefix);
                    break;

                case IDictionary dictionary:
                    flatParams = FlattenParamsDictionary(dictionary, keyPrefix);
                    break;

                case string s:
                    flatParams = SingleParam(keyPrefix, s);
                    break;

                case Stream s:
                    flatParams = SingleParam(keyPrefix, s);
                    break;

                case IEnumerable enumerable:
                    flatParams = FlattenParamsList(enumerable, keyPrefix);
                    break;

                case DateTime dateTime:
                    flatParams = SingleParam(
                        keyPrefix,
                        ((DateTimeOffset)dateTime).ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture));
                    break;

                case Enum e:
                    flatParams = SingleParam(keyPrefix, JsonUtils.SerializeObject(e).Trim('"'));
                    break;

                default:
                    flatParams = SingleParam(
                        keyPrefix,
                        string.Format(CultureInfo.InvariantCulture, "{0}", value));
                    break;
            }
#pragma warning restore IDE0066 // Convert switch statement to expression

            return flatParams;
        }

        /// <summary>
        /// Returns a list of parameters for a given <see cref="IAnyOf"/> instance.
        /// </summary>
        /// <param name="anyOf">The instance for which to create the list of parameters.</param>
        /// <param name="keyPrefix">The key under which new keys should be nested, if any.</param>
        /// <returns>The list of parameters.</returns>
        private static List<KeyValuePair<string, object>> FlattenParamsAnyOf(
            IAnyOf anyOf,
            string keyPrefix)
        {
            List<KeyValuePair<string, object>> flatParams = new List<KeyValuePair<string, object>>();

            // If the value contained within the `AnyOf` instance is null, we don't encode it in the
            // request. We do this to mimic the behavior of regular (non-`AnyOf`) properties in
            // options classes, which are skipped by the encoder when they have a null value
            // because it's the default value (cf. FlattenParamsOptions).
            if (anyOf.Value == null)
            {
                return flatParams;
            }

            flatParams.AddRange(FlattenParamsValue(anyOf.Value, keyPrefix));

            return flatParams;
        }

        /// <summary>
        /// Returns a list of parameters for a given options class. If a key prefix is provided, the
        /// keys for the new parameters will be nested under the key prefix. E.g. if the key prefix
        /// `foo` is passed and the options class contains a parameter `bar`, then a parameter
        /// with key `foo[bar]` will be returned.
        /// </summary>
        /// <param name="options">The options class for which to create the list of parameters.</param>
        /// <param name="keyPrefix">The key under which new keys should be nested, if any.</param>
        /// <returns>The list of parameters.</returns>
        private static List<KeyValuePair<string, object>> FlattenParamsOptions(
            INestedOptions options,
            string keyPrefix)
        {
            List<KeyValuePair<string, object>> flatParams = new List<KeyValuePair<string, object>>();
            if (options == null)
            {
                return flatParams;
            }

            foreach (var property in options.GetType().GetRuntimeProperties())
            {
                // `[JsonExtensionData]` tells the serializer to write the values contained in
                // the collection as if they were class properties.
                var extensionAttribute = property.GetCustomAttribute<JsonExtensionDataAttribute>();
                if (extensionAttribute != null)
                {
                    var extensionValue = property.GetValue(options, null) as IDictionary;

                    flatParams.AddRange(FlattenParamsDictionary(extensionValue, keyPrefix));
                    continue;
                }

                // Skip properties not annotated with `[JsonProperty]`
                var attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
                if (attribute == null)
                {
                    continue;
                }

                var value = property.GetValue(options, null);

                // Fields on a class which are never set by the user will contain null values (for
                // reference types), so skip those to avoid encoding them in the request.
                if (value == null)
                {
                    continue;
                }

                string key = attribute.PropertyName;
                string newPrefix = NewPrefix(key, keyPrefix);

                flatParams.AddRange(FlattenParamsValue(value, newPrefix));
            }

            return flatParams;
        }

        /// <summary>
        /// Returns a list of parameters for a given dictionary. If a key prefix is provided, the
        /// keys for the new parameters will be nested under the key prefix. E.g. if the key prefix
        /// `foo` is passed and the dictionary contains a key `bar`, then a parameter with key
        /// `foo[bar]` will be returned.
        /// </summary>
        /// <param name="dictionary">The dictionary for which to create the list of parameters.</param>
        /// <param name="keyPrefix">The key under which new keys should be nested, if any.</param>
        /// <returns>The list of parameters.</returns>
        private static List<KeyValuePair<string, object>> FlattenParamsDictionary(
            IDictionary dictionary,
            string keyPrefix)
        {
            List<KeyValuePair<string, object>> flatParams = new List<KeyValuePair<string, object>>();
            if (dictionary == null)
            {
                return flatParams;
            }

            foreach (DictionaryEntry entry in dictionary)
            {
                string key = string.Format(CultureInfo.InvariantCulture, "{0}", entry.Key);
                object value = entry.Value;

                string newPrefix = NewPrefix(key, keyPrefix);

                flatParams.AddRange(FlattenParamsValue(value, newPrefix));
            }

            return flatParams;
        }

        /// <summary>
        /// Returns a list of parameters for a given list of objects. The parameter keys will be
        /// indexed under the `keyPrefix` parameter. E.g. if the `keyPrefix` is `foo`, then the
        /// key for the first element's will be `foo[0]`, etc.
        /// </summary>
        /// <param name="list">The list for which to create the list of parameters.</param>
        /// <param name="keyPrefix">The key under which new keys should be nested.</param>
        /// <returns>The list of parameters.</returns>
        private static List<KeyValuePair<string, object>> FlattenParamsList(
            IEnumerable list,
            string keyPrefix)
        {
            List<KeyValuePair<string, object>> flatParams = new List<KeyValuePair<string, object>>();
            if (list == null)
            {
                return flatParams;
            }

            int index = 0;
            foreach (object value in list)
            {
                string newPrefix = $"{keyPrefix}[{index}]";
                flatParams.AddRange(FlattenParamsValue(value, newPrefix));
                index += 1;
            }

            // Because application/x-www-form-urlencoded cannot represent an empty list, convention
            // is to take the list parameter and just set it to an empty string. (E.g. A regular
            // list might look like `a[0]=1&b[1]=2`. Emptying it would look like `a=`.)
            if (!flatParams.Any())
            {
                flatParams.Add(new KeyValuePair<string, object>(keyPrefix, string.Empty));
            }

            return flatParams;
        }

        /// <summary>Creates a list containing a single parameter.</summary>
        /// <param name="key">The parameter's key.</param>
        /// <param name="value">The parameter's value.</param>
        /// <returns>A list containing the single parameter.</returns>
        private static List<KeyValuePair<string, object>> SingleParam(string key, object value)
        {
            List<KeyValuePair<string, object>> flatParams = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(key, value),
            };
            return flatParams;
        }

        /// <summary>
        /// Computes the new key prefix, given a key and an existing prefix (if any).
        /// E.g. if the key is `bar` and the existing prefix is `foo`, then `foo[bar]` is returned.
        /// If a key already contains nested values, then only the non-nested part is nested under
        /// the prefix, e.g. if the key is `bar[baz]` and the prefix is `foo`, then `foo[bar][baz]`
        /// is returned.
        /// If no prefix is provided, the key is returned unchanged.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="keyPrefix">The existing key prefix, if any.</param>
        /// <returns>The new key prefix.</returns>
        private static string NewPrefix(string key, string keyPrefix)
        {
            if (string.IsNullOrEmpty(keyPrefix))
            {
                return key;
            }

            int i = key.IndexOf("[", StringComparison.Ordinal);
            return i == -1 ? $"{keyPrefix}[{key}]" : $"{keyPrefix}[{key.Substring(0, i)}]{key.Substring(i)}";
        }
    }
}