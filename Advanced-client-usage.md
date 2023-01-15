# This page illustrates some advanced usages of OpenAIClient and SystemNetHttpClient.

## Using a proxy server

``` C#
using System.Net;
using System.Net.Http;
using OpenAI;

var handler = new HttpClientHandler
{
    Proxy = new WebProxy(proxyUrl),
    UseProxy = true,
};
var httpClient = new HttpClient(handler);

var openAIClient = new OpenAIClient(
    openAIApiKey,
    httpClient: new SystemNetHttpClient(httpClient)
);
OpenAIConfiguration.OpenAIClient = openAIClient;
```

## Using a custom message handler

E.g. to use Xamarin's [AndroidClientHandler][android-client-handler]:

``` C#
using System.Net.Http;
using OpenAI;

var handler = new Xamarin.Android.Net.AndroidClientHandler();
var httpClient = new HttpClient(handler);

var openAIClient = new OpenAIClient(
    openAIApiKey,
    httpClient: new SystemNetHttpClient(httpClient)
);
OpenAIConfiguration.OpenAIClient = openAIClient;
```

## Using custom base URLs

This is useful to send API requests to a local server, e.g. openai-mock:

``` C#
using OpenAI;

var openAIClient = new OpenAIClient(
    openAIApiKey,
    apiBase: "http://localhost:12111",
);
OpenAIConfiguration.OpenAIClient = openAIClient;
```

## Enabling automatic request retries

``` C#
using OpenAI;

var openAIClient = new OpenAIClient(
    openAIApiKey,
    httpClient: new SystemNetHttpClient(maxNetworkRetries: 2)
);
OpenAIConfiguration.OpenAIClient = openAIClient;
```

[android-client-handler]: https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/http-stack?tabs=macos#androidclienthandler