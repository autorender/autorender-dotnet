using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.MultipartUploads;

namespace Autorender.Tests.Models.MultipartUploads;

public class MultipartUploadStartParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MultipartUploadStartParams
        {
            FileName = "x",
            Format = "x",
            Size = 1,
            CustomID = "custom_id",
            Folder = "folder",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RandomPrefix = true,
            Tags = new(["string"]),
            TtlSeconds = 1,
        };

        string expectedFileName = "x";
        string expectedFormat = "x";
        long expectedSize = 1;
        string expectedCustomID = "custom_id";
        string expectedFolder = "folder";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedRandomPrefix = true;
        Tags expectedTags = new(["string"]);
        long expectedTtlSeconds = 1;

        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedSize, parameters.Size);
        Assert.Equal(expectedCustomID, parameters.CustomID);
        Assert.Equal(expectedFolder, parameters.Folder);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedRandomPrefix, parameters.RandomPrefix);
        Assert.Equal(expectedTags, parameters.Tags);
        Assert.Equal(expectedTtlSeconds, parameters.TtlSeconds);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MultipartUploadStartParams
        {
            FileName = "x",
            Format = "x",
            Size = 1,
        };

        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RandomPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("random_prefix"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.TtlSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("ttl_seconds"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MultipartUploadStartParams
        {
            FileName = "x",
            Format = "x",
            Size = 1,

            // Null should be interpreted as omitted for these properties
            CustomID = null,
            Folder = null,
            Metadata = null,
            RandomPrefix = null,
            Tags = null,
            TtlSeconds = null,
        };

        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RandomPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("random_prefix"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.TtlSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("ttl_seconds"));
    }

    [Fact]
    public void Url_Works()
    {
        MultipartUploadStartParams parameters = new()
        {
            FileName = "x",
            Format = "x",
            Size = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/multipart/start"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MultipartUploadStartParams
        {
            FileName = "x",
            Format = "x",
            Size = 1,
            CustomID = "custom_id",
            Folder = "folder",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RandomPrefix = true,
            Tags = new(["string"]),
            TtlSeconds = 1,
        };

        MultipartUploadStartParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TagsTest : TestBase
{
    [Fact]
    public void StringsValidationWorks()
    {
        Tags value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Tags value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        Tags value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tags>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Tags value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tags>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
