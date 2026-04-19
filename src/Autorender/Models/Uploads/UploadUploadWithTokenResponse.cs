using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Uploads;

/// <summary>
/// Upload created
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UploadUploadWithTokenResponse, UploadUploadWithTokenResponseFromRaw>)
)]
public sealed record class UploadUploadWithTokenResponse : JsonModel
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

    public required string? CustomID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("custom_id");
        }
        init { this._rawData.Set("custom_id", value); }
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

    public required string? FolderNo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folder_no");
        }
        init { this._rawData.Set("folder_no", value); }
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

    public required bool IsDuplicate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_duplicate");
        }
        init { this._rawData.Set("is_duplicate", value); }
    }

    public required bool IsPrivate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_private");
        }
        init { this._rawData.Set("is_private", value); }
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

    public required string UploadSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("upload_source");
        }
        init { this._rawData.Set("upload_source", value); }
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

    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
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

    public string? Hash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hash");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hash", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.CustomID;
        _ = this.FileNo;
        _ = this.FolderNo;
        _ = this.Height;
        _ = this.IsDuplicate;
        _ = this.IsPrivate;
        _ = this.Metadata;
        _ = this.MimeType;
        _ = this.Name;
        _ = this.Path;
        _ = this.Size;
        _ = this.Tags;
        _ = this.UploadSource;
        _ = this.Url;
        _ = this.Width;
        _ = this.WorkspaceID;
        _ = this.Format;
        _ = this.Hash;
    }

    public UploadUploadWithTokenResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadUploadWithTokenResponse(
        UploadUploadWithTokenResponse uploadUploadWithTokenResponse
    )
        : base(uploadUploadWithTokenResponse) { }
#pragma warning restore CS8618

    public UploadUploadWithTokenResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadUploadWithTokenResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadUploadWithTokenResponseFromRaw.FromRawUnchecked"/>
    public static UploadUploadWithTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadUploadWithTokenResponseFromRaw : IFromRawJson<UploadUploadWithTokenResponse>
{
    /// <inheritdoc/>
    public UploadUploadWithTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadUploadWithTokenResponse.FromRawUnchecked(rawData);
}
