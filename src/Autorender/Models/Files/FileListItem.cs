using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Files;

/// <summary>
/// File summary row in list responses
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileListItem, FileListItemFromRaw>))]
public sealed record class FileListItem : JsonModel
{
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Asset category, e.g. image
    /// </summary>
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

    public long? FileSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("file_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("file_size", value);
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

    public long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init { this._rawData.Set("height", value); }
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

    /// <summary>
    /// Relative path / display path
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("path", value);
        }
    }

    /// <summary>
    /// Thumbnail CDN URL (field name as returned by the API)
    /// </summary>
    public string? Thumbanil
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("thumbanil");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("thumbanil", value);
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

    public long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
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
        _ = this.CreatedAt;
        _ = this.Extension;
        _ = this.FileNo;
        _ = this.FileSize;
        _ = this.Format;
        _ = this.Height;
        _ = this.Name;
        _ = this.Path;
        _ = this.Thumbanil;
        _ = this.Url;
        _ = this.Width;
        _ = this.WorkspaceNo;
    }

    public FileListItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListItem(FileListItem fileListItem)
        : base(fileListItem) { }
#pragma warning restore CS8618

    public FileListItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileListItemFromRaw.FromRawUnchecked"/>
    public static FileListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileListItemFromRaw : IFromRawJson<FileListItem>
{
    /// <inheritdoc/>
    public FileListItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileListItem.FromRawUnchecked(rawData);
}
