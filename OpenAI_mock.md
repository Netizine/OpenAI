# openai-mock 

openai-mock is a mock HTTP server based on the real OpenAI API. It accepts the
same requests and parameters that the OpenAI API accepts, and rejects requests
whose parameters are not recognized or have incorrect types. Its responses
resemble the responses of the real OpenAI API in terms of data type; however,
openai-mock **does not attempt to reproduce the _behavior_ of the real OpenAI API
at all**. It cannot reject all invalid requests, and its responses are completely
hardcoded. They will have a correct type, but they will not necessarily be
realistic OpenAI responses.

openai-mock is meant for basic sanity checks. We use it in the test suite of
our server-side SDK, to help validate that the SDK hits the right URL and sends 
the right parameters. If you have more sophisticated testing needs, you shouldn't 
use openai-mock. Always test changes to your OpenAI integration against
OpenAI. For regression test suites, you should define your own mocks, or use a 
playback testing tool such as [VCR gem](https://github.com/vcr/vcr).

While openai-mock is naïve, it is powered by [the OpenAPI specification][openapi] 
and is therefore kept up-to-date with the latest methods, resources, and fields.

## Features and limitations

openai-mock supports the following features:

- It has a catalog of every API URL and their signatures. It responds to URLs
  that exist with a resource that it returns and 404s on URLs that don't exist.
- JSON Schema is used to check the validity of the parameters of incoming
  requests. Validation is far from exhaustive, so don't
  expect the full barrage of checks of the live API.
- Responses are generated based off resource fixtures. They're also generated
  from within OpenAPI's API, and similar to the sample data available in OpenAI's
  [API reference][apiref]. **They are hardcoded**, and will not necessarily
  represent realistic responses based on the parameters you input into the
  request.
- It reflects the values of valid input parameters into responses where the
  naming and type are the same. So if a completion is created with `Prompt="Say this is a test"`, a
  charge will be returned with `"Prompt": "Say this is a test"`.
- It will respond over HTTP or over HTTPS. HTTP/2 over HTTPS is available if the
  client supports it.

Limitations:

- openai-mock is stateless. Data you send on a `POST` request will be validated,
  but it will be completely ignored beyond that. It will not be reflected on the
  response or on any future request -- unlike the real OpenAI API, which stores
  the information you send it.
- It's locked to the latest version of OpenAI's API and doesn't support old
  versions.
- Testing for specific responses and errors is currently only partially supported. 
  It will return a certain response but not all error responses instead of the desired 
  error response.

## Future plans

The scope we envision for openai-mock has significantly narrowed since 2017 when
we first released it. Back in 2017, our vision was for openai-mock was to return
responses that were _realistic_ as well as just having the expected types. This
has changed. We are currently **not** planning to add statefulness or more
sophisticated testing features to openai-mock. openai-mock will remain a tool
for basic sanity checks. If you have more sophisticated needs, you should define
your own mocks, use a playback testing tool like the
[VCR gem](https://github.com/vcr/vcr), or find a community library you trust. Be
careful, though. Always test changes to your OpenAI integration against
the actual OpenAI API. Mock implementations of OpenAI can never behave exactly as 
the OpenAI API does, and might differ in nuanced (and potentially dangerous) ways.

## Usage

If you have [the .NET SDK][openapi] installed, you can install the mock server with:

```sh
dotnet tool install OpenAI.Mock
```

With no arguments, openai-mock will listen with HTTP on the first available port.
You can launch the mock server with:

```sh
openai-mock
```

Ports can be specified explicitly with:

```sh
openai-mock --port 12111
```


### Sample request

After you've started openai-mock, you can try a sample request against it:

```sh
curl -i http://localhost:12111/v1/models -H "Authorization: Bearer sk_test"
```

### Testing

Run the test suite:

```sh
dotnet test
```

### Updating OpenAPI

Update the OpenAPI mock server by running the following command:

```sh
dotnet tool update
```


[openapi]: https://openai.com/
[apiref]: https://beta.openai.com/docs/introduction
[net-sdk]: https://dotnet.microsoft.com/en-us/download/visual-studio-sdks