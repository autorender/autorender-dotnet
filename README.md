# Autorender C# API Library

The Autorender C# SDK provides convenient access to the [Autorender REST API](https://autorender.mintlify.app/) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [autorender.mintlify.app](https://autorender.mintlify.app/).

## Installation

```bash
git clone git@github.com:autorenderhq/autorender-dotnet.git
dotnet add reference autorender-dotnet/src/Autorender
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Autorender;
using Autorender.Models.Files;

AutorenderClient client = new();

FileListParams parameters = new() { Limit = 10 };

var files = await client.Files.List(parameters);

Console.WriteLine(files);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Autorender;

// Configured using the AUTORENDER_API_KEY and AUTORENDER_BASE_URL environment variables
AutorenderClient client = new();
```

Or manually:

```csharp
using Autorender;

AutorenderClient client = new() { ApiKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property  | Environment variable  | Required | Default value                    |
| --------- | --------------------- | -------- | -------------------------------- |
| `ApiKey`  | `AUTORENDER_API_KEY`  | false    | -                                |
| `BaseUrl` | `AUTORENDER_BASE_URL` | true     | `"https://upload.autorender.io"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var upload = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Uploads.Create(parameters);

Console.WriteLine(upload);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Autorender API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Files.List` should be called with an instance of `FileListParams`, and it will return an instance of `Task<FileListResponse>`.

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Uploads.Create(parameters);
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using Autorender.Models.Uploads;

var response = await client.WithRawResponse.Uploads.Create(parameters);
UploadCreateResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## Error handling

The SDK throws custom unchecked exception types:

- `AutorenderApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                                 |
| ------ | ----------------------------------------- |
| 400    | `AutorenderBadRequestException`           |
| 401    | `AutorenderUnauthorizedException`         |
| 403    | `AutorenderForbiddenException`            |
| 404    | `AutorenderNotFoundException`             |
| 422    | `AutorenderUnprocessableEntityException`  |
| 429    | `AutorenderRateLimitException`            |
| 5xx    | `Autorender5xxException`                  |
| others | `AutorenderUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Autorender4xxException`.

- `AutorenderIOException`: I/O networking errors.

- `AutorenderInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `AutorenderException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Autorender;

AutorenderClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var upload = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Uploads.Create(parameters);

Console.WriteLine(upload);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Autorender;

AutorenderClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var upload = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Uploads.Create(parameters);

Console.WriteLine(upload);
```

### Proxies

To route requests through a proxy, configure your client with a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0):

```csharp
using System.Net;
using System.Net.Http;
using Autorender;

var httpClient = new HttpClient
(
    new HttpClientHandler
    {
        Proxy = new WebProxy("https://example.com:8080")
    }
);

AutorenderClient client = new() { HttpClient = httpClient };
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Parameters

To set undocumented parameters, a constructor exists that accepts dictionaries for additional header, query, and body values. If the method type doesn't support request bodies (e.g. `GET` requests), the constructor will only accept a header and query dictionary.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Models.Files;

FileListParams parameters = new
(
    rawHeaderData: new Dictionary<string, JsonElement>()
    {
        { "Custom-Header", JsonSerializer.SerializeToElement(42) }
    },

    rawQueryData: new Dictionary<string, JsonElement>()
    {
        { "custom_query_param", JsonSerializer.SerializeToElement(42) }
    }
)
{
    // Documented properties can still be added here.
    // In case of conflict, these parameters take precedence over the custom parameters.
    Limit = 1
};
```

The raw parameters can also be accessed through the `RawHeaderData`, `RawQueryData`, and `RawBodyData` (if available) properties.

This can also be used to set a documented parameter to an undocumented or not yet supported _value_, as long as the parameter is optional. If the parameter is required, omitting its `init` property will result in a compile-time error. To work around this, the `FromRawUnchecked` method can be used:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Models.Uploads;

var parameters = UploadCreateParams.FromRawUnchecked
(

    rawHeaderData: new Dictionary<string, JsonElement>(),
    rawQueryData: new Dictionary<string, JsonElement>(),
    rawBodyData: new Dictionary<string, JsonElement>
    {
        {
            "file",
            JsonSerializer.SerializeToElement("custom value")
        }
    }
);
```

### Response properties

To access undocumented response properties, the `RawData` property can be used:

```csharp
using System.Text.Json;

var response = client.Files.List()
if (response.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Do something with `value`
}
```

`RawData` is a `IReadonlyDictionary<string, JsonElement>`. It holds the full data received from the API server.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `AutorenderInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var files = client.Files.List();
files.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Autorender;

AutorenderClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var files = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Files.List(parameters);

Console.WriteLine(files);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/autorenderhq/autorender-dotnet/issues) with questions, bugs, or suggestions.
