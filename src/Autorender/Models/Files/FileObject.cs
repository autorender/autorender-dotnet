using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Files;

[JsonConverter(typeof(JsonModelConverter<FileObject, FileObjectFromRaw>))]
public sealed record class FileObject : JsonModel
{
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    public bool? Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("success");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
        _ = this.Success;
    }

    public FileObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileObject(FileObject fileObject)
        : base(fileObject) { }
#pragma warning restore CS8618

    public FileObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileObjectFromRaw.FromRawUnchecked"/>
    public static FileObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileObjectFromRaw : IFromRawJson<FileObject>
{
    /// <inheritdoc/>
    public FileObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileObject.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? AssetKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("asset_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("asset_key", value);
        }
    }

    public string? AssetUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("asset_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("asset_url", value);
        }
    }

    public Dimensions? Dimensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Dimensions>("dimensions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dimensions", value);
        }
    }

    public string? Extension
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("extension");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extension", value);
        }
    }

    public string? FileNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_no");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("file_no", value);
        }
    }

    public JsonElement? Folder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("folder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("folder", value);
        }
    }

    public string? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("format", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// File size in bytes
    /// </summary>
    public long? Size
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("size", value);
        }
    }

    public DateTimeOffset? UploadedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("uploaded_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uploaded_at", value);
        }
    }

    public string? UploadedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uploaded_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uploaded_by", value);
        }
    }

    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    public Workspace? Workspace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Workspace>("workspace");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workspace", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AssetKey;
        _ = this.AssetUrl;
        this.Dimensions?.Validate();
        _ = this.Extension;
        _ = this.FileNo;
        _ = this.Folder;
        _ = this.Format;
        _ = this.Name;
        _ = this.Path;
        _ = this.Size;
        _ = this.UploadedAt;
        _ = this.UploadedBy;
        _ = this.Url;
        this.Workspace?.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Dimensions, DimensionsFromRaw>))]
public sealed record class Dimensions : JsonModel
{
    public long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    public long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Width;
    }

    public Dimensions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Dimensions(Dimensions dimensions)
        : base(dimensions) { }
#pragma warning restore CS8618

    public Dimensions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dimensions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DimensionsFromRaw.FromRawUnchecked"/>
    public static Dimensions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DimensionsFromRaw : IFromRawJson<Dimensions>
{
    /// <inheritdoc/>
    public Dimensions FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Dimensions.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Workspace, WorkspaceFromRaw>))]
public sealed record class Workspace : JsonModel
{
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? WorkspaceNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_no");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workspace_no", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.WorkspaceNo;
    }

    public Workspace() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Workspace(Workspace workspace)
        : base(workspace) { }
#pragma warning restore CS8618

    public Workspace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Workspace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceFromRaw.FromRawUnchecked"/>
    public static Workspace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceFromRaw : IFromRawJson<Workspace>
{
    /// <inheritdoc/>
    public Workspace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Workspace.FromRawUnchecked(rawData);
}
