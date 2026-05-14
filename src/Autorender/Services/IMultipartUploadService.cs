using System;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Models.MultipartUploads;

namespace Autorender.Services;

/// <summary>
/// Upload endpoints (API key required)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IMultipartUploadService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMultipartUploadServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMultipartUploadService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Finalise a multipart upload session and return the stored file record.
    /// </summary>
    Task<MultipartUploadCompleteResponse> Complete(
        MultipartUploadCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Initialise a multipart upload session and receive pre-signed part URLs.
    /// </summary>
    Task<MultipartUploadStartResponse> Start(
        MultipartUploadStartParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMultipartUploadService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMultipartUploadServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMultipartUploadServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/multipart/complete</c>, but is otherwise the
    /// same as <see cref="IMultipartUploadService.Complete(MultipartUploadCompleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MultipartUploadCompleteResponse>> Complete(
        MultipartUploadCompleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/multipart/start</c>, but is otherwise the
    /// same as <see cref="IMultipartUploadService.Start(MultipartUploadStartParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MultipartUploadStartResponse>> Start(
        MultipartUploadStartParams parameters,
        CancellationToken cancellationToken = default
    );
}
