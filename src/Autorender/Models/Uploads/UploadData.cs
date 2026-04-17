using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Uploads;

[JsonConverter(typeof(JsonModelConverter<UploadData, UploadDataFromRaw>))]
public sealed record class UploadData : JsonModel
{
    /// <summary>
    /// Unique file record ID
    /// </summary>
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

    /// <summary>
    /// 10-character file number identifier
    /// </summary>
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

    /// <summary>
    /// File size in bytes (after processing)
    /// </summary>
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

    /// <summary>
    /// File format/extension (e.g., jpg, png, webp)
    /// </summary>
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

    /// <summary>
    /// Image height in pixels (null for non-image files)
    /// </summary>
    public long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init { this._rawData.Set("height", value); }
    }

    /// <summary>
    /// Final filename (may include random suffix if requested)
    /// </summary>
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
    /// Folder path where the file is stored
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
    /// Full CDN URL to access the uploaded file
    /// </summary>
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

    /// <summary>
    /// Image width in pixels (null for non-image files)
    /// </summary>
    public long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    /// <summary>
    /// Workspace identifier
    /// </summary>
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
        _ = this.ID;
        _ = this.FileNo;
        _ = this.FileSize;
        _ = this.Format;
        _ = this.Height;
        _ = this.Name;
        _ = this.Path;
        _ = this.Url;
        _ = this.Width;
        _ = this.WorkspaceNo;
    }

    public UploadData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadData(UploadData uploadData)
        : base(uploadData) { }
#pragma warning restore CS8618

    public UploadData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadDataFromRaw.FromRawUnchecked"/>
    public static UploadData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadDataFromRaw : IFromRawJson<UploadData>
{
    /// <inheritdoc/>
    public UploadData FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UploadData.FromRawUnchecked(rawData);
}
