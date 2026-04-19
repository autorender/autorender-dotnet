using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;
using Autorender.Exceptions;

namespace Autorender.Models.Files;

/// <summary>
/// Updated file
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileUpdateResponse, FileUpdateResponseFromRaw>))]
public sealed record class FileUpdateResponse : JsonModel
{
    public required FileUpdateResponseData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FileUpdateResponseData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    public required ApiEnum<bool, FileUpdateResponseSuccess> Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<bool, FileUpdateResponseSuccess>>(
                "success"
            );
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        this.Success.Validate();
    }

    public FileUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUpdateResponse(FileUpdateResponse fileUpdateResponse)
        : base(fileUpdateResponse) { }
#pragma warning restore CS8618

    public FileUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUpdateResponseFromRaw.FromRawUnchecked"/>
    public static FileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUpdateResponseFromRaw : IFromRawJson<FileUpdateResponse>
{
    /// <inheritdoc/>
    public FileUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileUpdateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FileUpdateResponseData, FileUpdateResponseDataFromRaw>))]
public sealed record class FileUpdateResponseData : JsonModel
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

    public FileUpdateResponseData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUpdateResponseData(FileUpdateResponseData fileUpdateResponseData)
        : base(fileUpdateResponseData) { }
#pragma warning restore CS8618

    public FileUpdateResponseData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUpdateResponseData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUpdateResponseDataFromRaw.FromRawUnchecked"/>
    public static FileUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUpdateResponseDataFromRaw : IFromRawJson<FileUpdateResponseData>
{
    /// <inheritdoc/>
    public FileUpdateResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileUpdateResponseData.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FileUpdateResponseSuccessConverter))]
public enum FileUpdateResponseSuccess
{
    True,
}

sealed class FileUpdateResponseSuccessConverter : JsonConverter<FileUpdateResponseSuccess>
{
    public override FileUpdateResponseSuccess Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => FileUpdateResponseSuccess.True,
            _ => (FileUpdateResponseSuccess)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUpdateResponseSuccess value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileUpdateResponseSuccess.True => true,
                _ => throw new AutorenderInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
