using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autorender.Core;

namespace Autorender.Models.Uploads;

[JsonConverter(typeof(JsonModelConverter<Upload, UploadFromRaw>))]
public sealed record class Upload : JsonModel
{
    public required UploadData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Indicates if the upload was successful
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        _ = this.Success;
    }

    public Upload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Upload(Upload upload)
        : base(upload) { }
#pragma warning restore CS8618

    public Upload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Upload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadFromRaw.FromRawUnchecked"/>
    public static Upload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadFromRaw : IFromRawJson<Upload>
{
    /// <inheritdoc/>
    public Upload FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Upload.FromRawUnchecked(rawData);
}
