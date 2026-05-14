using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.MultipartUploads;

/// <summary>
/// Session created
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MultipartUploadStartResponse, MultipartUploadStartResponseFromRaw>)
)]
public sealed record class MultipartUploadStartResponse : JsonModel
{
    /// <summary>
    /// Unix timestamp when the session expires
    /// </summary>
    public required long ExpireAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expire_at");
        }
        init { this._rawData.Set("expire_at", value); }
    }

    public required long MinPartSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("min_part_size");
        }
        init { this._rawData.Set("min_part_size", value); }
    }

    public required long PartSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("part_size");
        }
        init { this._rawData.Set("part_size", value); }
    }

    /// <summary>
    /// Pre-signed S3 upload URLs, one per part
    /// </summary>
    public required IReadOnlyList<string> Parts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("parts");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "parts",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Policy Policy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Policy>("policy");
        }
        init { this._rawData.Set("policy", value); }
    }

    public required string PublicKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("public_key");
        }
        init { this._rawData.Set("public_key", value); }
    }

    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    public required string Uuid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("uuid");
        }
        init { this._rawData.Set("uuid", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExpireAt;
        _ = this.MinPartSize;
        _ = this.PartSize;
        _ = this.Parts;
        this.Policy.Validate();
        _ = this.PublicKey;
        _ = this.SessionID;
        _ = this.Uuid;
        _ = this.WorkspaceID;
    }

    public MultipartUploadStartResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MultipartUploadStartResponse(MultipartUploadStartResponse multipartUploadStartResponse)
        : base(multipartUploadStartResponse) { }
#pragma warning restore CS8618

    public MultipartUploadStartResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MultipartUploadStartResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MultipartUploadStartResponseFromRaw.FromRawUnchecked"/>
    public static MultipartUploadStartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MultipartUploadStartResponseFromRaw : IFromRawJson<MultipartUploadStartResponse>
{
    /// <inheritdoc/>
    public MultipartUploadStartResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MultipartUploadStartResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Policy, PolicyFromRaw>))]
public sealed record class Policy : JsonModel
{
    public required string Folder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("folder");
        }
        init { this._rawData.Set("folder", value); }
    }

    public required string Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("format");
        }
        init { this._rawData.Set("format", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Folder;
        _ = this.Format;
        _ = this.Size;
        _ = this.Tags;
    }

    public Policy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Policy(Policy policy)
        : base(policy) { }
#pragma warning restore CS8618

    public Policy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Policy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PolicyFromRaw.FromRawUnchecked"/>
    public static Policy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PolicyFromRaw : IFromRawJson<Policy>
{
    /// <inheritdoc/>
    public Policy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Policy.FromRawUnchecked(rawData);
}
