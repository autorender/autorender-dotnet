using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Exceptions;
using Autorender.Models.Folders;

namespace Autorender.Services;

/// <inheritdoc/>
public sealed class FolderService : IFolderService
{
    readonly Lazy<IFolderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFolderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAutorenderClient _client;

    /// <inheritdoc/>
    public IFolderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FolderService(this._client.WithOptions(modifier));
    }

    public FolderService(IAutorenderClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FolderServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FolderCreateResponse> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FolderListResponse> List(
        FolderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(FolderDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string folderNo,
        FolderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { FolderNo = folderNo }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FolderRenameResponse> Rename(
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Rename(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FolderRenameResponse> Rename(
        string folderNo,
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Rename(parameters with { FolderNo = folderNo }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FolderServiceWithRawResponse : IFolderServiceWithRawResponse
{
    readonly IAutorenderClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFolderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FolderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FolderServiceWithRawResponse(IAutorenderClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FolderCreateResponse>> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FolderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var folder = await response
                    .Deserialize<FolderCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    folder.Validate();
                }
                return folder;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FolderListResponse>> List(
        FolderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FolderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var folders = await response
                    .Deserialize<FolderListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    folders.Validate();
                }
                return folders;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        FolderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FolderNo == null)
        {
            throw new AutorenderInvalidDataException("'parameters.FolderNo' cannot be null");
        }

        HttpRequest<FolderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string folderNo,
        FolderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { FolderNo = folderNo }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FolderRenameResponse>> Rename(
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FolderNo == null)
        {
            throw new AutorenderInvalidDataException("'parameters.FolderNo' cannot be null");
        }

        HttpRequest<FolderRenameParams> request = new()
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
                    .Deserialize<FolderRenameResponse>(token)
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
    public Task<HttpResponse<FolderRenameResponse>> Rename(
        string folderNo,
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Rename(parameters with { FolderNo = folderNo }, cancellationToken);
    }
}
