using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Services;

/// <inheritdoc/>
public sealed class UploadService : IUploadService
{
    readonly Lazy<IUploadServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUploadServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAutorenderClient _client;

    /// <inheritdoc/>
    public IUploadService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UploadService(this._client.WithOptions(modifier));
    }

    public UploadService(IAutorenderClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UploadServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Upload> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Upload> CreateFromUrl(
        UploadCreateFromUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateFromUrl(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UploadServiceWithRawResponse : IUploadServiceWithRawResponse
{
    readonly IAutorenderClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUploadServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UploadServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UploadServiceWithRawResponse(IAutorenderClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Upload>> Create(
        UploadCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UploadCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var upload = await response.Deserialize<Upload>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    upload.Validate();
                }
                return upload;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Upload>> CreateFromUrl(
        UploadCreateFromUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UploadCreateFromUrlParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var upload = await response.Deserialize<Upload>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    upload.Validate();
                }
                return upload;
            }
        );
    }
}
