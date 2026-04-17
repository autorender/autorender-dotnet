using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Autorender.Core;

namespace Autorender.Models.Uploads;

/// <summary>
/// Upload a file to your AutoRender workspace with optional transformations, tags,
/// and folder organization
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UploadCreateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The file to upload (binary data)
    /// </summary>
    public required BinaryContent File
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<BinaryContent>("file");
        }
        init { this._rawBodyData.Set("file", value); }
    }

    /// <summary>
    /// File name for the uploaded file (e.g., my-image.jpg)
    /// </summary>
    public required string FileName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("file_name");
        }
        init { this._rawBodyData.Set("file_name", value); }
    }

    /// <summary>
    /// Custom identifier for the file
    /// </summary>
    public string? CustomID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("custom_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("custom_id", value);
        }
    }

    /// <summary>
    /// Folder path where the file will be stored (e.g., uploads/my-folder)
    /// </summary>
    public string? Folder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("folder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("folder", value);
        }
    }

    /// <summary>
    /// JSON string for custom metadata (e.g., {"key": "value"})
    /// </summary>
    public string? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Set to "true" to add a random suffix to filename
    /// </summary>
    public string? RandomPrefix
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("random_prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("random_prefix", value);
        }
    }

    /// <summary>
    /// Comma-separated tags (e.g., tag1,tag2,tag3)
    /// </summary>
    public string? Tags
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tags", value);
        }
    }

    /// <summary>
    /// Image transformation string (e.g., w_800,h_600,q_90)
    /// </summary>
    public string? Transform
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("transform");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("transform", value);
        }
    }

    public UploadCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadCreateParams(UploadCreateParams uploadCreateParams)
        : base(uploadCreateParams)
    {
        this._rawBodyData = new(uploadCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public UploadCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UploadCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, MultipartJsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UploadCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/uploads")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return MultipartJsonSerializer.Serialize(RawBodyData);
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
