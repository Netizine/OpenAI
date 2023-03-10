// ReSharper disable once CheckNamespace
namespace OpenAI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Infrastructure;

    /// <summary>
    /// Standard client to make requests to OpenAI's API, using
    /// <see cref="System.Net.Http.HttpClient"/> to send HTTP requests.
    /// It can automatically retry failed requests when it's safe to do so.
    /// </summary>
    public class SystemNetHttpClient : IHttpClient
    {
        /// <summary>Default maximum number of retries made by the client.</summary>
        public static readonly int DefaultMaxNumberRetries = 2;

        private const string OpenAINetTargetFramework =
#if NET7_0
            "net7.0"
#elif NET6_0
            "net6.0"
#elif NETSTANDARD2_0
            "netstandard2.0"
#elif NET462
            "net462"
#else
            "unknown"
#endif
        ;

        private static readonly Lazy<HttpClient> LazyDefaultHttpClient
            = new Lazy<HttpClient>(BuildDefaultSystemNetHttpClient);

        private readonly HttpClient httpClient;

        private readonly object randLock = new object();

        private readonly Random rand = new Random();

        private readonly string userAgentString;

        static SystemNetHttpClient()
        {
            // Enable support for TLS 1.2, as OpenAI's API requires it. This should only be
            // necessary for .NET Framework 4.5 as more recent run-times should have TLS 1.2 enabled
            // by default, but it can be disabled in some environments.
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemNetHttpClient"/> class.
        /// </summary>
        public SystemNetHttpClient()
        {
            httpClient = LazyDefaultHttpClient.Value;
            MaxNetworkRetries = DefaultMaxNumberRetries;
            userAgentString = BuildOpenAIClientUserAgentString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemNetHttpClient"/> class.
        /// </summary>
        /// <param name="maxNetworkRetries">
        /// The maximum number of times the client will retry requests that fail due to an
        /// intermittent problem.
        /// </param>
        public SystemNetHttpClient(int maxNetworkRetries)
        {
            httpClient = LazyDefaultHttpClient.Value;
            MaxNetworkRetries = maxNetworkRetries;
            userAgentString = BuildOpenAIClientUserAgentString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemNetHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="System.Net.Http.HttpClient"/> client to use. If <c>null</c>, an HTTP
        /// client will be created with default parameters.
        /// </param>
        public SystemNetHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? LazyDefaultHttpClient.Value;
            MaxNetworkRetries = DefaultMaxNumberRetries;
            userAgentString = BuildOpenAIClientUserAgentString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemNetHttpClient"/> class.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="System.Net.Http.HttpClient"/> client to use. If <c>null</c>, an HTTP
        /// client will be created with default parameters.
        /// </param>
        /// <param name="maxNetworkRetries">
        /// The maximum number of times the client will retry requests that fail due to an
        /// intermittent problem.
        /// </param>
        public SystemNetHttpClient(
            HttpClient httpClient,
            int maxNetworkRetries)
        {
            this.httpClient = httpClient ?? LazyDefaultHttpClient.Value;
            MaxNetworkRetries = maxNetworkRetries;
            userAgentString = BuildOpenAIClientUserAgentString();
        }

        /// <summary>Default timespan before the request times out.</summary>
        public static TimeSpan DefaultHttpTimeout => TimeSpan.FromSeconds(80);

        /// <summary>
        /// Maximum sleep time between tries to send HTTP requests after network failure.
        /// </summary>
        public static TimeSpan MaxNetworkRetriesDelay => TimeSpan.FromSeconds(5);

        /// <summary>
        /// Minimum sleep time between tries to send HTTP requests after network failure.
        /// </summary>
        public static TimeSpan MinNetworkRetriesDelay => TimeSpan.FromMilliseconds(500);

        /// <summary>
        /// Gets how many network retries were configured for this client.
        /// </summary>
        public int MaxNetworkRetries { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the client should sleep between automatic
        /// request retries.
        /// </summary>
        /// <remarks>This is an internal property meant to be used in tests only.</remarks>
        internal bool NetworkRetriesSleep { get; set; } = true;

        private static string BuildOpenAIClientUserAgentString()
        {
            var values = new Dictionary<string, object>
            {
                { "bindings_version", OpenAIConfiguration.OpenAIClientVersion },
                { "lang", ".NET" },
                { "publisher", "OpenAI" },
                { "target_framework", OpenAINetTargetFramework },
            };

            // The following values are in try/catch blocks on the off chance that the
            // RuntimeInformation methods fail in an unexpected way. This should ~never happen, but
            // if it does it should not prevent users from sending requests.
            try
            {
                values.Add("lang_version", RuntimeInformation.GetRuntimeVersion());
            }
            catch
            {
                values.Add("lang_version", "(unknown)");
            }

            try
            {
                values.Add("os_version", RuntimeInformation.GetOSVersion());
            }
            catch
            {
                values.Add("os_version", "(unknown)");
            }

            return JsonUtils.SerializeObject(values);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="System.Net.Http.HttpClient"/> class
        /// with default parameters.
        /// </summary>
        /// <returns>The new instance of the <see cref="System.Net.Http.HttpClient"/> class.</returns>
        public static HttpClient BuildDefaultSystemNetHttpClient()
        {
            // We set the User-Agent headers in each request
            // message rather than through the client's `DefaultRequestHeaders` because we
            // want these headers to be present even when a custom HTTP client is used.
            return new HttpClient
            {
                Timeout = DefaultHttpTimeout,
            };
        }

        /// <summary>
        /// Make a HTTP request as an asynchronous operation.
        /// </summary>
        /// <param name="request">The parameters of the request to send.</param>
        /// <returns>A Task&lt;OpenAIResponse&gt; representing the asynchronous operation.</returns>
        public Task<OpenAIResponse> MakeRequestAsync(
            OpenAIRequest request)
        {
            return MakeRequestAsync(request, default);
        }

        /// <summary>
        /// Make a HTTP request as an asynchronous operation.
        /// </summary>
        /// <param name="request">The parameters of the request to send.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A Task&lt;OpenAIResponse&gt; representing the asynchronous operation.</returns>
        public async Task<OpenAIResponse> MakeRequestAsync(
            OpenAIRequest request,
            CancellationToken cancellationToken)
        {
            var (response, retries) = await SendHttpRequest(request, cancellationToken).ConfigureAwait(false);

#if NET7_0 || NET6_0
            var reader = new StreamReader(
                await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false));
#else
            var reader = new StreamReader(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
#endif

            return new OpenAIResponse(
                response.StatusCode,
                response.Headers,
                await reader.ReadToEndAsync().ConfigureAwait(false))
            {
                NumRetries = retries,
            };
        }

        private async Task<(HttpResponseMessage responseMessage, int retries)> SendHttpRequest(
            OpenAIRequest request,
            CancellationToken cancellationToken)
        {
            TimeSpan duration;
            Exception requestException;
            HttpResponseMessage response = null;
            int retry = 0;

            while (true)
            {
                requestException = null;

                var httpRequest = BuildRequestMessage(request);

                var stopwatch = Stopwatch.StartNew();

                try
                {
                    response = await httpClient.SendAsync(httpRequest, cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (HttpRequestException exception)
                {
                    requestException = exception;
                }
                catch (OperationCanceledException exception)
                    when (!cancellationToken.IsCancellationRequested)
                {
                    requestException = exception;
                }

                stopwatch.Stop();

                duration = stopwatch.Elapsed;

                if (!ShouldRetry(
                    retry,
                    requestException != null,
                    response?.StatusCode,
                    response?.Headers))
                {
                    break;
                }

                retry += 1;
                await Task.Delay(SleepTime(retry), cancellationToken).ConfigureAwait(false);
            }

            if (requestException != null)
            {
                throw requestException;
            }

            Console.WriteLine("Execution Time: " + duration.ToString("c"));
            return (response, retry);
        }

        private bool ShouldRetry(
            int numRetries,
            bool error,
            HttpStatusCode? statusCode,
            HttpHeaders headers)
        {
            // Do not retry if we are out of retries.
            if (numRetries >= MaxNetworkRetries)
            {
                return false;
            }

            // Retry on connection error.
            if (error)
            {
                return true;
            }

            // The API may ask us not to retry (eg; if doing so would be a no-op)
            // or advise us to retry (eg; in cases of lock timeouts); we defer to that.
            if (headers != null && headers.Contains("Should-Retry"))
            {
                var value = headers.GetValues("Should-Retry").First();

                return value switch
                {
                    "true" => true,
                    "false" => false,
                    _ => false,
                };
            }

            // Retry on conflict errors.
            if (statusCode == HttpStatusCode.Conflict)
            {
                return true;
            }

            // Retry on 500, 503, and other internal errors.
            //
            // Note that we expect the Should-Retry header to be false
            // in most cases when a 500 is returned.
            return statusCode.HasValue && ((int)statusCode.Value >= 500);
        }

        private HttpRequestMessage BuildRequestMessage(OpenAIRequest request)
        {
            var requestMessage = new HttpRequestMessage(request.Method, request.Uri);

            // Standard headers
            requestMessage.Headers.TryAddWithoutValidation("User-Agent", userAgentString);
            requestMessage.Headers.Authorization = request.AuthorizationHeader;

            // Custom headers
            foreach (var header in request.OpenAIHeaders)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }

            // Request body
            requestMessage.Content = request.Content;

            return requestMessage;
        }

        private TimeSpan SleepTime(int numRetries)
        {
            // We disable sleeping in some cases for tests.
            if (!NetworkRetriesSleep)
            {
                return TimeSpan.Zero;
            }

            // Apply exponential backoff with MinNetworkRetriesDelay on the number of numRetries
            // so far as inputs.
            var delay = TimeSpan.FromTicks((long)(MinNetworkRetriesDelay.Ticks
                * Math.Pow(2, numRetries - 1)));

            // Do not allow the number to exceed MaxNetworkRetriesDelay
            if (delay > MaxNetworkRetriesDelay)
            {
                delay = MaxNetworkRetriesDelay;
            }

            // Apply some jitter by randomizing the value in the range of 75%-100%.
            double jitter;
            lock (randLock)
            {
                jitter = (3.0 + rand.NextDouble()) / 4.0;
            }

            delay = TimeSpan.FromTicks((long)(delay.Ticks * jitter));

            // But never sleep less than the base sleep seconds.
            if (delay < MinNetworkRetriesDelay)
            {
                delay = MinNetworkRetriesDelay;
            }

            return delay;
        }
    }
}
