# OpenAI

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/d19cad2e2bb647c89b351e2f380e12c6)](https://www.codacy.com/gh/Netizine/OpenAI/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=Netizine/OpenAI&amp;utm_campaign=Badge_Grade)
## The unofficial [OpenAI][openai] .NET library, supporting .NET Standard 2.0+, .NET Core 2.0+, and .NET Framework 4.6.2+.

## Installation

Using the [.NET Core command-line interface (CLI) tools][dotnet-core-cli-tools]:

```sh
dotnet add package OpenAI
```

Using the [NuGet Command Line Interface (CLI)][nuget-cli]:

```sh
nuget install OpenAI
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package OpenAI
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "OpenAI".
5. Click on the OpenAI package, select the appropriate version in the
   right-tab and click *Install*.

## Documentation

For a comprehensive list of examples, check out the [API
documentation][api-docs]. See [video demonstrations][youtube-playlist] covering
how to use the library.

## Usage

### Authentication

OpenAI authenticates API requests using your account’s secret key, which you can find in the OpenAI Dashboard. By default, secret keys can be used to perform any API request without restriction.

Use `OpenAI.OpenAIConfiguration.ApiKey` property to set the secret key.

``` C#
OpenAI.OpenAIConfiguration.ApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
```

### Retrieve a resource

The `Retrieve` method of the service class can be used to retrieve a resource:

``` C#
ModelService modelService = new ModelService();
Model model = modelService.Get("davinci");
Console.WriteLine(model.OwnedBy);
```

### Creating a resource

The `Create` method of the service class can be used to create a new resource:

``` C#
ChatCompletionMessage chatMessage = new ChatCompletionMessage {
    Role = ChatRoles.User,
    Content = "Can you explain the meaning of life"
};
List<ChatCompletionMessage> chatMessageList = new List<ChatCompletionMessage>
{
    chatMessage
};
ChatGPT3CompletionService chatCompletionService = new ChatGPT3CompletionService();
ChatGPT3CompletionCreateOptions chatCompletionOptions = new ChatGPT3CompletionCreateOptions {
    Model = "gpt-3.5-turbo",
    Messages = chatMessageList,
    Temperature = 0,
};
ChatCompletion chatCompletion = chatCompletionService.Create(chatCompletionOptions);
Console.WriteLine(chatCompletion.Choices[0].Message);
```

``` C#
CompletionService completionService = new CompletionService();
Completion completion = completionService.Create(new CompletionCreateOptions
{
    Prompt = "Say this is a test",
    Model = "text-davinci-003",
    MaxTokens = 7,
    Temperature = 0,
});
Console.WriteLine(completion.Id);
```


### Deleting a resource

The `Delete` method of the service class can be used to delete a resource:

```C#
FileService fileService = new FileService();
File deleteFile = fileService.Delete(createdFile.Id, new FileDeleteOptions());
Console.WriteLine(deleteFile.Id);
```

### Listing a resource

The `List` method on the service class can be used to list resources page-by-page.

```C#
ModelService modelService = new ModelService();
OpenAIList<Model> models = modelService.List();

// Enumerate the list
foreach (Model model in models)
{
    Console.WriteLine(model.Id);
}
```

### FormEncoder provides methods to serialize various objects with application/x-www-form-urlencoded</c> encoding.

```C#
var imageService = new ImageService();
Image editedImage = imageService.Edit(new EditImageCreateOptions
{
    Image = "otters.png",
    ImageSource = System.IO.File.ReadAllBytes("otters.png"),
    Mask = "otters-mask.png",
    MaskSource = System.IO.File.ReadAllBytes("otters-mask.png"),
    Prompt = "A cute baby sea otter wearing a beret",
    N = 2,
    Size = "1024x1024",
});
Console.WriteLine(editedImage.Data[0].Url);
```

### Per-request configuration

All of the service methods accept an optional `RequestOptions` object. This is
used if you want to pass the secret API key on each method etc.

```c#
var requestOptions = new RequestOptions
{
    ApiKey = "SECRET API KEY",
    OrganizationId = "ORGANIZATION ID"
};
```

### Using a custom `HttpClient`

You can configure the library with your own custom `HttpClient`:

```c#
OpenAIConfiguration.OpenAIClient = new OpenAIClient(
    apiKey,
    httpClient: new SystemNetHttpClient(httpClient));
```

Please refer to the [Advanced client usage][advanced-client-usage] page
to see more examples of using custom clients, e.g. for using a proxy server, a
custom message handler, etc.

### Automatic retries

The library automatically retries requests on intermittent failures like on a
connection error, timeout, or on certain API responses like a status `409
Conflict`.

By default, it will perform up to two retries. That number can be configured
with `OpenAIConfiguration.MaxNetworkRetries`:

```c#
OpenAIConfiguration.MaxNetworkRetries = 0; // Zero retries
```

### How to use parameters and properties

OpenAI is a typed library and it supports all public properties or parameters.
In cases where OpenAI adds some new features which introduce new properties or parameters that are not immediately available in the SDK, the library may not support these properties or parameters yet but there is still an approach that allows you to use them.

Parameters
To pass undocumented parameters to OpenAI using the OpenAI SDK, you need to use the AddExtraParam() method, as shown below:

```c#
CompletionService completionService = new CompletionService();
var completionOptions = new CompletionCreateOptions
{
    Prompt = "Say this is a test",
    Model = "text-davinci-003",
    MaxTokens = 7,
    Temperature = 0,
};
completionOptions.AddExtraParam("new_feature_enabled", "true");
Completion completion = completionService.Create(completionOptions);
Console.WriteLine(completion.Id);
```

#### Properties

To retrieve undocumented properties from OpenAI using C# you can use an option in the library to return the raw JSON object and return the property. An example of this is shown below:

```c#
ModelService modelService = new ModelService();
Model model = modelService.Get("davinci");
var featureEnabled = model.RawJObject["feature_enabled"];
```

This information is passed along when the library makes calls to the OpenAI API.

```
dotnet add package OpenAI --version
```

## Support

New features and bug fixes are released on the latest major version of the OpenAI .NET client library. If you are on an older major version, we recommend that you upgrade to the latest in order to use the new features and bug fixes including those for security vulnerabilities. Older major versions of the package will continue to be available for use, but will not be receiving any updates.

## Development

The test suite depends on [openai-mock][openai-mock], so make sure to fetch
and run it from a background terminal
([openai-mock's README][openai-mock-usage] also contains instructions for
installing via Nuget):

```sh
dotnet tool install --global OpenAI.Mock
openai-mock
```

Alternatively, if you have already installed it, run 
```sh
dotnet tool update --global OpenAI.Mock
openai-mock
```

Run all tests from the `tests/OpenAI.Tests` directory:

```sh
dotnet test
```

Run some tests, filtering by name:

```sh
dotnet test --filter FullyQualifiedName~ModelServiceTest
```

Run tests for a single target framework:

```sh
dotnet test --framework netcoreapp2.1
```

# CI/CD Tests

If you need to run tests in a CI/CD pipeline, you can specify the `OPENAI_MOCK_PORT` environment variable to a specific port.
Then in your pipeline, add a step to install the openai-mock server before running unit tests.

```yaml
    - name: Install OpenAI.Mock
      run: dotnet tool install --global OpenAI.Mock
```

The library uses [`dotnet-format`][dotnet-format] for code formatting. Code
must be formatted before PRs are submitted, otherwise CI will fail. Run the
formatter with:

```sh
dotnet format src/OpenAI.sln
```

For any requests, bug or comments, please [open an issue][issues] or [submit a
pull request][pulls].

[advanced-client-usage]: https://github.com/Netizine/OpenAI//blob/master/ADVANCED_CLIENT_USAGE.md
[api-docs]: https://beta.openai.com/docs/introduction
[api-keys]: https://beta.openai.com/account/api-keys
[connect-auth]: https://beta.openai.com/docs/api-reference/authentication
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[dotnet-format]: https://github.com/dotnet/format
[issues]: https://github.com/Netizine/OpenAI/issues/new
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
[pulls]: https://github.com/Netizine/OpenAI/pulls
[openai]: https://openai.com
[openai-mock]: https://github.com/Netizine/OpenAI.Mock/blob/master/README.md
[openai-mock-usage]: https://github.com/Netizine/OpenAI.Mock/blob/master/README.md#usage
[youtube-playlist]: https://www.youtube.com/openai
