using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Files;

/// <summary>
/// Updated file record after rename
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileRenameResponse, FileRenameResponseFromRaw>))]
public sealed record class FileRenameResponse : JsonModel
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

    public string? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_by", value);
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

    public string? FolderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folder_id");
        }
        init { this._rawData.Set("folder_id", value); }
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

    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_active", value);
        }
    }

    public bool? IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_default");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_default", value);
        }
    }

    public bool? IsDelete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_delete");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_delete", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? MetaData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "meta_data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "meta_data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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

    public string? Orientation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("orientation");
        }
        init { this._rawData.Set("orientation", value); }
    }

    public string? OriginalUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("original_url");
        }
        init { this._rawData.Set("original_url", value); }
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

    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    public string? TransformString
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transform_string");
        }
        init { this._rawData.Set("transform_string", value); }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated_at", value);
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

    public string? WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("workspace_id", value);
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
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CreatedBy;
        _ = this.Extension;
        _ = this.FileNo;
        _ = this.FileSize;
        _ = this.FolderID;
        _ = this.Format;
        _ = this.Height;
        _ = this.IsActive;
        _ = this.IsDefault;
        _ = this.IsDelete;
        _ = this.MetaData;
        _ = this.Name;
        _ = this.Orientation;
        _ = this.OriginalUrl;
        _ = this.Path;
        _ = this.Source;
        _ = this.TransformString;
        _ = this.UpdatedAt;
        _ = this.Url;
        _ = this.Width;
        _ = this.WorkspaceID;
        _ = this.WorkspaceNo;
    }

    public FileRenameResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileRenameResponse(FileRenameResponse fileRenameResponse)
        : base(fileRenameResponse) { }
#pragma warning restore CS8618

    public FileRenameResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileRenameResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileRenameResponseFromRaw.FromRawUnchecked"/>
    public static FileRenameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileRenameResponseFromRaw : IFromRawJson<FileRenameResponse>
{
    /// <inheritdoc/>
    public FileRenameResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileRenameResponse.FromRawUnchecked(rawData);
}
