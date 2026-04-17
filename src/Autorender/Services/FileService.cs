using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Exceptions;
using Autorender.Models.Files;

namespace Autorender.Services;

/// <inheritdoc/>
public sealed class FileService : IFileService
{
    readonly Lazy<IFileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAutorenderClient _client;

    /// <inheritdoc/>
    public IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileService(this._client.WithOptions(modifier));
    }

    public FileService(IAutorenderClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FileServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FileObject> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileObject> Retrieve(
        string fileNo,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FileNo = fileNo }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FileListResponse> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FileDeleteResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileDeleteResponse> Delete(
        string fileNo,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { FileNo = fileNo }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FileRenameResponse> Rename(
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Rename(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileRenameResponse> Rename(
        string fileNo,
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Rename(parameters with { FileNo = fileNo }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FileServiceWithRawResponse : IFileServiceWithRawResponse
{
    readonly IAutorenderClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FileServiceWithRawResponse(IAutorenderClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileObject>> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileNo == null)
        {
            throw new AutorenderInvalidDataException("'parameters.FileNo' cannot be null");
        }

        HttpRequest<FileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var fileObject = await response
                    .Deserialize<FileObject>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    fileObject.Validate();
                }
                return fileObject;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FileObject>> Retrieve(
        string fileNo,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FileNo = fileNo }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileListResponse>> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var files = await response
                    .Deserialize<FileListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    files.Validate();
                }
                return files;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileDeleteResponse>> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileNo == null)
        {
            throw new AutorenderInvalidDataException("'parameters.FileNo' cannot be null");
        }

        HttpRequest<FileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var file = await response
                    .Deserialize<FileDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    file.Validate();
                }
                return file;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FileDeleteResponse>> Delete(
        string fileNo,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { FileNo = fileNo }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileRenameResponse>> Rename(
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileNo == null)
        {
            throw new AutorenderInvalidDataException("'parameters.FileNo' cannot be null");
        }

        HttpRequest<FileRenameParams> request = new()
        {
            Method = AutorenderClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FileRenameResponse>(token)
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
    public Task<HttpResponse<FileRenameResponse>> Rename(
        string fileNo,
        FileRenameParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Rename(parameters with { FileNo = fileNo }, cancellationToken);
    }
}
