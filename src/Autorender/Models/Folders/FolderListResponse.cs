using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Folders;

/// <summary>
/// List of folders
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FolderListResponse, FolderListResponseFromRaw>))]
public sealed record class FolderListResponse : JsonModel
{
    public required IReadOnlyList<Folder> Folders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Folder>>("folders");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Folder>>(
                "folders",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Folders)
        {
            item.Validate();
        }
    }

    public FolderListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderListResponse(FolderListResponse folderListResponse)
        : base(folderListResponse) { }
#pragma warning restore CS8618

    public FolderListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderListResponseFromRaw.FromRawUnchecked"/>
    public static FolderListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FolderListResponse(IReadOnlyList<Folder> folders)
        : this()
    {
        this.Folders = folders;
    }
}

class FolderListResponseFromRaw : IFromRawJson<FolderListResponse>
{
    /// <inheritdoc/>
    public FolderListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Folder, FolderFromRaw>))]
public sealed record class Folder : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string FolderNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("folder_no");
        }
        init { this._rawData.Set("folder_no", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string? ParentFolderNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parent_folder_no");
        }
        init { this._rawData.Set("parent_folder_no", value); }
    }

    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    public required DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.FolderNo;
        _ = this.Name;
        _ = this.ParentFolderNo;
        _ = this.Path;
        _ = this.UpdatedAt;
    }

    public Folder() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Folder(Folder folder)
        : base(folder) { }
#pragma warning restore CS8618

    public Folder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Folder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderFromRaw.FromRawUnchecked"/>
    public static Folder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderFromRaw : IFromRawJson<Folder>
{
    /// <inheritdoc/>
    public Folder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Folder.FromRawUnchecked(rawData);
}
