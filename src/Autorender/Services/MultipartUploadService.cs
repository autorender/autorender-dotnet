using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Models.MultipartUploads;

namespace Autorender.Services;

/// <inheritdoc/>
public sealed class MultipartUploadService : IMultipartUploadService
{
    readonly Lazy<IMultipartUploadServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMultipartUploadServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAutorenderClient _client;

    /// <inheritdoc/>
    public IMultipartUploadService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MultipartUploadService(this._client.WithOptions(modifier));
    }

    public MultipartUploadService(IAutorenderClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new MultipartUploadServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<MultipartUploadCompleteResponse> Complete(
        MultipartUploadCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Complete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<MultipartUploadStartResponse> Start(
        MultipartUploadStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Start(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MultipartUploadServiceWithRawResponse : IMultipartUploadServiceWithRawResponse
{
    readonly IAutorenderClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMultipartUploadServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new MultipartUploadServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MultipartUploadServiceWithRawResponse(IAutorenderClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MultipartUploadCompleteResponse>> Complete(
        MultipartUploadCompleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MultipartUploadCompleteParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<MultipartUploadCompleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MultipartUploadStartResponse>> Start(
        MultipartUploadStartParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<MultipartUploadStartParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<MultipartUploadStartResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
