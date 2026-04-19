using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;
using Autorender.Exceptions;

namespace Autorender.Models.Files;

/// <summary>
/// List/search files with pagination, filtering, and sorting.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FileListParams : ParamsBase
{
    /// <summary>
    /// Exact folder number
    /// </summary>
    public string? FolderNo
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("folderNo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("folderNo", value);
        }
    }

    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Partial name match (case-insensitive)
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("name", value);
        }
    }

    public long? Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// Folder prefix (e.g. products/sku123/)
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("path", value);
        }
    }

    public ApiEnum<string, Sort>? Sort
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Sort>>("sort");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    /// <summary>
    /// Comma-separated tags
    /// </summary>
    public string? Tags
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tags", value);
        }
    }

    public FileListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListParams(FileListParams fileListParams)
        : base(fileListParams) { }
#pragma warning restore CS8618

    public FileListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FileListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FileListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/files")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    CreatedAtAsc,
    CreatedAtDesc,
    SizeAsc,
    SizeDesc,
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at_asc" => Sort.CreatedAtAsc,
            "created_at_desc" => Sort.CreatedAtDesc,
            "size_asc" => Sort.SizeAsc,
            "size_desc" => Sort.SizeDesc,
            _ => (Sort)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Sort value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Sort.CreatedAtAsc => "created_at_asc",
                Sort.CreatedAtDesc => "created_at_desc",
                Sort.SizeAsc => "size_asc",
                Sort.SizeDesc => "size_desc",
                _ => throw new AutorenderInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
