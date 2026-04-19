using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Uploads;

/// <summary>
/// Token generated
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UploadGenerateTokenResponse, UploadGenerateTokenResponseFromRaw>)
)]
public sealed record class UploadGenerateTokenResponse : JsonModel
{
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    public required long ExpireAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("expire_at");
        }
        init { this._rawData.Set("expire_at", value); }
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

    public required string Signature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("signature");
        }
        init { this._rawData.Set("signature", value); }
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
        _ = this.Token;
        _ = this.ExpireAt;
        this.Policy.Validate();
        _ = this.PublicKey;
        _ = this.Signature;
        _ = this.WorkspaceID;
    }

    public UploadGenerateTokenResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadGenerateTokenResponse(UploadGenerateTokenResponse uploadGenerateTokenResponse)
        : base(uploadGenerateTokenResponse) { }
#pragma warning restore CS8618

    public UploadGenerateTokenResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadGenerateTokenResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadGenerateTokenResponseFromRaw.FromRawUnchecked"/>
    public static UploadGenerateTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadGenerateTokenResponseFromRaw : IFromRawJson<UploadGenerateTokenResponse>
{
    /// <inheritdoc/>
    public UploadGenerateTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadGenerateTokenResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Policy, PolicyFromRaw>))]
public sealed record class Policy : JsonModel
{
    public required PolicyAllowOverride AllowOverride
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PolicyAllowOverride>("allow_override");
        }
        init { this._rawData.Set("allow_override", value); }
    }

    public required string Folder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("folder");
        }
        init { this._rawData.Set("folder", value); }
    }

    public required long MaxFileSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("max_file_size");
        }
        init { this._rawData.Set("max_file_size", value); }
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
        this.AllowOverride.Validate();
        _ = this.Folder;
        _ = this.MaxFileSize;
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

[JsonConverter(typeof(JsonModelConverter<PolicyAllowOverride, PolicyAllowOverrideFromRaw>))]
public sealed record class PolicyAllowOverride : JsonModel
{
    public bool? Folder
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("folder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("folder", value);
        }
    }

    public bool? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tags", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Folder;
        _ = this.Tags;
    }

    public PolicyAllowOverride() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PolicyAllowOverride(PolicyAllowOverride policyAllowOverride)
        : base(policyAllowOverride) { }
#pragma warning restore CS8618

    public PolicyAllowOverride(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PolicyAllowOverride(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PolicyAllowOverrideFromRaw.FromRawUnchecked"/>
    public static PolicyAllowOverride FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PolicyAllowOverrideFromRaw : IFromRawJson<PolicyAllowOverride>
{
    /// <inheritdoc/>
    public PolicyAllowOverride FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PolicyAllowOverride.FromRawUnchecked(rawData);
}
