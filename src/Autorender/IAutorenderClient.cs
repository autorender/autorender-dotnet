using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Services;

namespace Autorender;

/// <summary>
/// A client for interacting with the Autorender REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IAutorenderClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAutorenderClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutorenderClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IUploadService Uploads { get; }

    IFileService Files { get; }

    IFolderService Folders { get; }

    IMultipartUploadService MultipartUploads { get; }
}

/// <summary>
/// A view of <see cref="IAutorenderClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IAutorenderClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutorenderClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IUploadServiceWithRawResponse Uploads { get; }

    IFileServiceWithRawResponse Files { get; }

    IFolderServiceWithRawResponse Folders { get; }

    IMultipartUploadServiceWithRawResponse MultipartUploads { get; }

    /// <summary>
    /// Sends a request to the Autorender REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
