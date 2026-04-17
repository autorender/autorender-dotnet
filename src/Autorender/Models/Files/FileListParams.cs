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
/// Paginated list of files in the workspace. Filter by folder, sort by field and
/// order, and page through results.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FileListParams : ParamsBase
{
    /// <summary>
    /// Restrict results to files in this folder (folder number)
    /// </summary>
    public string? FolderNo
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("folder_no");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("folder_no", value);
        }
    }

    /// <summary>
    /// Items per page
    /// </summary>
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
    /// Filter by filename (partial match, if supported)
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

    /// <summary>
    /// Page number (1-based)
    /// </summary>
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
    /// Filter by path prefix (if supported)
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

    /// <summary>
    /// Field to sort by
    /// </summary>
    public ApiEnum<string, SortField>? SortField
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SortField>>("sort_field");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sort_field", value);
        }
    }

    /// <summary>
    /// Sort direction
    /// </summary>
    public ApiEnum<string, SortOrder>? SortOrder
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SortOrder>>("sort_order");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sort_order", value);
        }
    }

    /// <summary>
    /// Comma-separated tags (if supported)
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

/// <summary>
/// Field to sort by
/// </summary>
[JsonConverter(typeof(SortFieldConverter))]
public enum SortField
{
    FileSize,
    Name,
    CreatedAt,
    UpdatedAt,
}

sealed class SortFieldConverter : JsonConverter<SortField>
{
    public override SortField Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file_size" => SortField.FileSize,
            "name" => SortField.Name,
            "created_at" => SortField.CreatedAt,
            "updated_at" => SortField.UpdatedAt,
            _ => (SortField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SortField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortField.FileSize => "file_size",
                SortField.Name => "name",
                SortField.CreatedAt => "created_at",
                SortField.UpdatedAt => "updated_at",
                _ => throw new AutorenderInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort direction
/// </summary>
[JsonConverter(typeof(SortOrderConverter))]
public enum SortOrder
{
    Asc,
    Desc,
}

sealed class SortOrderConverter : JsonConverter<SortOrder>
{
    public override SortOrder Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc" => SortOrder.Asc,
            "desc" => SortOrder.Desc,
            _ => (SortOrder)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SortOrder value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SortOrder.Asc => "asc",
                SortOrder.Desc => "desc",
                _ => throw new AutorenderInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
