using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Exceptions;
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
    public async Task<UploadCreateResponse> Create(
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
    public async Task<UploadCreateFromUrlResponse> CreateFromUrl(
        UploadCreateFromUrlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateFromUrl(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UploadGenerateTokenResponse> GenerateToken(
        UploadGenerateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GenerateToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UploadUploadWithTokenResponse> UploadWithToken(
        UploadUploadWithTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UploadWithToken(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UploadUploadWithTokenResponse> UploadWithToken(
        string token,
        BinaryContent file,
        UploadUploadWithTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UploadWithToken(
            parameters with
            {
                Token = token,
                File = file,
            },
            cancellationToken
        );
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
    public async Task<HttpResponse<UploadCreateResponse>> Create(
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
                var upload = await response
                    .Deserialize<UploadCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    upload.Validate();
                }
                return upload;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UploadCreateFromUrlResponse>> CreateFromUrl(
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
                var deserializedResponse = await response
                    .Deserialize<UploadCreateFromUrlResponse>(token)
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
    public async Task<HttpResponse<UploadGenerateTokenResponse>> GenerateToken(
        UploadGenerateTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UploadGenerateTokenParams> request = new()
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
                    .Deserialize<UploadGenerateTokenResponse>(token)
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
    public async Task<HttpResponse<UploadUploadWithTokenResponse>> UploadWithToken(
        UploadUploadWithTokenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Token == null)
        {
            throw new AutorenderInvalidDataException("'parameters.Token' cannot be null");
        }
        if (parameters.File == null)
        {
            throw new AutorenderInvalidDataException("'parameters.File' cannot be null");
        }

        HttpRequest<UploadUploadWithTokenParams> request = new()
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
                    .Deserialize<UploadUploadWithTokenResponse>(token)
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
    public Task<HttpResponse<UploadUploadWithTokenResponse>> UploadWithToken(
        string token,
        BinaryContent file,
        UploadUploadWithTokenParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UploadWithToken(
            parameters with
            {
                Token = token,
                File = file,
            },
            cancellationToken
        );
    }
}
