using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Files;

/// <summary>
/// Files list
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileListResponse, FileListResponseFromRaw>))]
public sealed record class FileListResponse : JsonModel
{
    public required IReadOnlyList<File> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<File>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<File>>(
                "files",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Meta Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>("meta");
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Files)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public FileListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListResponse(FileListResponse fileListResponse)
        : base(fileListResponse) { }
#pragma warning restore CS8618

    public FileListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileListResponseFromRaw.FromRawUnchecked"/>
    public static FileListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileListResponseFromRaw : IFromRawJson<FileListResponse>
{
    /// <inheritdoc/>
    public FileListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
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

    public required string FileNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_no");
        }
        init { this._rawData.Set("file_no", value); }
    }

    public required string? FolderName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folder_name");
        }
        init { this._rawData.Set("folder_name", value); }
    }

    public required string? FolderNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folder_no");
        }
        init { this._rawData.Set("folder_no", value); }
    }

    public required string? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("format");
        }
        init { this._rawData.Set("format", value); }
    }

    public required long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init { this._rawData.Set("height", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mime_type");
        }
        init { this._rawData.Set("mime_type", value); }
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

    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    public required long Size
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("size");
        }
        init { this._rawData.Set("size", value); }
    }

    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required IReadOnlyList<string> Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "tags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    public required long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.FileNo;
        _ = this.FolderName;
        _ = this.FolderNo;
        _ = this.Format;
        _ = this.Height;
        _ = this.Metadata;
        _ = this.MimeType;
        _ = this.Name;
        _ = this.Path;
        _ = this.Size;
        _ = this.Source;
        _ = this.Tags;
        _ = this.UpdatedAt;
        _ = this.Url;
        _ = this.Width;
    }

    public File() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public File(File file)
        : base(file) { }
#pragma warning restore CS8618

    public File(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileFromRaw.FromRawUnchecked"/>
    public static File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileFromRaw : IFromRawJson<File>
{
    /// <inheritdoc/>
    public File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        File.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public required bool HasNext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasNext");
        }
        init { this._rawData.Set("hasNext", value); }
    }

    public required bool HasPrev
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasPrev");
        }
        init { this._rawData.Set("hasPrev", value); }
    }

    public required long Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    public required long Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page");
        }
        init { this._rawData.Set("page", value); }
    }

    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasNext;
        _ = this.HasPrev;
        _ = this.Limit;
        _ = this.Page;
        _ = this.Total;
    }

    public Meta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta(Meta meta)
        : base(meta) { }
#pragma warning restore CS8618

    public Meta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meta.FromRawUnchecked(rawData);
}
