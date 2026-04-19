using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadGenerateTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UploadGenerateTokenParams
        {
            FileName = "file_name",
            AllowOverride = new() { Folder = true, Tags = true },
            CustomID = "custom_id",
            Folder = "folder",
            MaxFileSize = -9007199254740991,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RandomPrefix = true,
            Tags = ["string"],
            TtlSeconds = -9007199254740991,
        };

        string expectedFileName = "file_name";
        AllowOverride expectedAllowOverride = new() { Folder = true, Tags = true };
        string expectedCustomID = "custom_id";
        string expectedFolder = "folder";
        long expectedMaxFileSize = -9007199254740991;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedRandomPrefix = true;
        List<string> expectedTags = ["string"];
        long expectedTtlSeconds = -9007199254740991;

        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedAllowOverride, parameters.AllowOverride);
        Assert.Equal(expectedCustomID, parameters.CustomID);
        Assert.Equal(expectedFolder, parameters.Folder);
        Assert.Equal(expectedMaxFileSize, parameters.MaxFileSize);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.Equal(expectedRandomPrefix, parameters.RandomPrefix);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
        Assert.Equal(expectedTtlSeconds, parameters.TtlSeconds);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UploadGenerateTokenParams { FileName = "file_name" };

        Assert.Null(parameters.AllowOverride);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_override"));
        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.MaxFileSize);
        Assert.False(parameters.RawBodyData.ContainsKey("max_file_size"));
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
        var parameters = new UploadGenerateTokenParams
        {
            FileName = "file_name",

            // Null should be interpreted as omitted for these properties
            AllowOverride = null,
            CustomID = null,
            Folder = null,
            MaxFileSize = null,
            Metadata = null,
            RandomPrefix = null,
            Tags = null,
            TtlSeconds = null,
        };

        Assert.Null(parameters.AllowOverride);
        Assert.False(parameters.RawBodyData.ContainsKey("allow_override"));
        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.MaxFileSize);
        Assert.False(parameters.RawBodyData.ContainsKey("max_file_size"));
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
        UploadGenerateTokenParams parameters = new() { FileName = "file_name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/generate-token"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UploadGenerateTokenParams
        {
            FileName = "file_name",
            AllowOverride = new() { Folder = true, Tags = true },
            CustomID = "custom_id",
            Folder = "folder",
            MaxFileSize = -9007199254740991,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RandomPrefix = true,
            Tags = ["string"],
            TtlSeconds = -9007199254740991,
        };

        UploadGenerateTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AllowOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AllowOverride { Folder = true, Tags = true };

        bool expectedFolder = true;
        bool expectedTags = true;

        Assert.Equal(expectedFolder, model.Folder);
        Assert.Equal(expectedTags, model.Tags);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AllowOverride { Folder = true, Tags = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AllowOverride>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AllowOverride { Folder = true, Tags = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AllowOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedFolder = true;
        bool expectedTags = true;

        Assert.Equal(expectedFolder, deserialized.Folder);
        Assert.Equal(expectedTags, deserialized.Tags);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AllowOverride { Folder = true, Tags = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AllowOverride { };

        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AllowOverride { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AllowOverride
        {
            // Null should be interpreted as omitted for these properties
            Folder = null,
            Tags = null,
        };

        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AllowOverride
        {
            // Null should be interpreted as omitted for these properties
            Folder = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AllowOverride { Folder = true, Tags = true };

        AllowOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}
