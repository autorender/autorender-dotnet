using System;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUploadService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUploadServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUploadService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Upload a file to your AutoRender workspace with optional transformations, tags,
    /// and folder organization
    /// </summary>
    Task<Upload> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUploadService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUploadServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUploadServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/uploads</c>, but is otherwise the
    /// same as <see cref="IUploadService.Create(UploadCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Upload>> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
