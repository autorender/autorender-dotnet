using System;
using System.Threading;
using System.Threading.Tasks;
using Autorender.Core;
using Autorender.Models.Folders;

namespace Autorender.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFolderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFolderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFolderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a folder under an optional parent.
    /// </summary>
    Task<FolderCreateResponse> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List folders under an optional parent. Omit `parent_folder_no` to list
    /// root-level folders.
    /// </summary>
    Task<FolderListResponse> List(
        FolderListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a folder by folder number. No request body required.
    /// </summary>
    Task<FolderDeleteResponse> Delete(
        FolderDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FolderDeleteParams, CancellationToken)"/>
    Task<FolderDeleteResponse> Delete(
        string folderNo,
        FolderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rename a folder by `folder_no`.
    /// </summary>
    Task<Folder> Rename(
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Rename(FolderRenameParams, CancellationToken)"/>
    Task<Folder> Rename(
        string folderNo,
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFolderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFolderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFolderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/folders</c>, but is otherwise the
    /// same as <see cref="IFolderService.Create(FolderCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderCreateResponse>> Create(
        FolderCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/folders</c>, but is otherwise the
    /// same as <see cref="IFolderService.List(FolderListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderListResponse>> List(
        FolderListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/folders/{folderNo}</c>, but is otherwise the
    /// same as <see cref="IFolderService.Delete(FolderDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FolderDeleteResponse>> Delete(
        FolderDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FolderDeleteParams, CancellationToken)"/>
    Task<HttpResponse<FolderDeleteResponse>> Delete(
        string folderNo,
        FolderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/folders/rename/{folderNo}</c>, but is otherwise the
    /// same as <see cref="IFolderService.Rename(FolderRenameParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Folder>> Rename(
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Rename(FolderRenameParams, CancellationToken)"/>
    Task<HttpResponse<Folder>> Rename(
        string folderNo,
        FolderRenameParams parameters,
        CancellationToken cancellationToken = default
    );
}
