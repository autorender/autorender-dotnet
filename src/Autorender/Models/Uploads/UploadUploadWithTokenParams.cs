using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Autorender.Core;

namespace Autorender.Models.Uploads;

/// <summary>
/// Upload a file directly from the browser using a token from /generate-token. Send
/// the raw file as binary in the request body.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UploadUploadWithTokenParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? Token { get; init; }

    /// <summary>
    /// Raw file bytes. Accepts any file type (images, documents, videos, etc.).
    /// </summary>
    public BinaryContent? File
    {
        get
        {
            return WrappedMultipartJsonSerializer.GetNotNullClass<BinaryContent>(
                this.RawBodyData,
                "RawBodyData"
            );
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public UploadUploadWithTokenParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadUploadWithTokenParams(UploadUploadWithTokenParams uploadUploadWithTokenParams)
        : base(uploadUploadWithTokenParams)
    {
        this.Token = uploadUploadWithTokenParams.Token;

        this.RawBodyData = uploadUploadWithTokenParams.RawBodyData;
    }
#pragma warning restore CS8618

    public UploadUploadWithTokenParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadUploadWithTokenParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string token
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.Token = token;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UploadUploadWithTokenParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string token
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            token
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Token"] = JsonSerializer.SerializeToElement(this.Token),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UploadUploadWithTokenParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Token?.Equals(other.Token) ?? other.Token == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/uploads/{0}", this.Token)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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
