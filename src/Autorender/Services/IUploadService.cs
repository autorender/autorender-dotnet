using System;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Services;

/// <summary>
/// Upload endpoints (API key required)
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Upload a file from your backend server using multipart/form-data.
    /// </summary>
    Task<UploadCreateResponse> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Download a file from a remote URL and store it in AutoRender.
    /// </summary>
    Task<UploadCreateFromUrlResponse> CreateFromUrl(
        UploadCreateFromUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate a short-lived token for direct browser uploads. No file is created at
    /// this stage.
    /// </summary>
    Task<UploadGenerateTokenResponse> GenerateToken(
        UploadGenerateTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a file directly from the browser using a token from /generate-token. Send
    /// the raw file as binary in the request body.
    /// </summary>
    Task<UploadUploadWithTokenResponse> UploadWithToken(
        UploadUploadWithTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadWithToken(UploadUploadWithTokenParams, CancellationToken)"/>
    Task<UploadUploadWithTokenResponse> UploadWithToken(
        string token,
        BinaryContent file,
        UploadUploadWithTokenParams? parameters = null,
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
    Task<HttpResponse<UploadCreateResponse>> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/uploads/remote</c>, but is otherwise the
    /// same as <see cref="IUploadService.CreateFromUrl(UploadCreateFromUrlParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UploadCreateFromUrlResponse>> CreateFromUrl(
        UploadCreateFromUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/generate-token</c>, but is otherwise the
    /// same as <see cref="IUploadService.GenerateToken(UploadGenerateTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UploadGenerateTokenResponse>> GenerateToken(
        UploadGenerateTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/uploads/{token}</c>, but is otherwise the
    /// same as <see cref="IUploadService.UploadWithToken(UploadUploadWithTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UploadUploadWithTokenResponse>> UploadWithToken(
        UploadUploadWithTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UploadWithToken(UploadUploadWithTokenParams, CancellationToken)"/>
    Task<HttpResponse<UploadUploadWithTokenResponse>> UploadWithToken(
        string token,
        BinaryContent file,
        UploadUploadWithTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
