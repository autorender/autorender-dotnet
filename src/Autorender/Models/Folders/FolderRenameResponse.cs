using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Folders;

/// <summary>
/// Renamed folder
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FolderRenameResponse, FolderRenameResponseFromRaw>))]
public sealed record class FolderRenameResponse : JsonModel
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

    public FolderRenameResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderRenameResponse(FolderRenameResponse folderRenameResponse)
        : base(folderRenameResponse) { }
#pragma warning restore CS8618

    public FolderRenameResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderRenameResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderRenameResponseFromRaw.FromRawUnchecked"/>
    public static FolderRenameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderRenameResponseFromRaw : IFromRawJson<FolderRenameResponse>
{
    /// <inheritdoc/>
    public FolderRenameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderRenameResponse.FromRawUnchecked(rawData);
}
