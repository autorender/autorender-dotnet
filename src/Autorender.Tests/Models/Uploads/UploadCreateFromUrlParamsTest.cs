using System;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadCreateFromUrlParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UploadCreateFromUrlParams
        {
            RemoteUrl = "https://example.com",
            CustomID = "custom_id",
            FileName = "file_name",
            Folder = "folder",
            Metadata = "metadata",
            RandomPrefix = "random_prefix",
            Tags = new(["string"]),
            WebhookUrl = "https://example.com",
        };

        string expectedRemoteUrl = "https://example.com";
        string expectedCustomID = "custom_id";
        string expectedFileName = "file_name";
        string expectedFolder = "folder";
        string expectedMetadata = "metadata";
        string expectedRandomPrefix = "random_prefix";
        Tags expectedTags = new(["string"]);
        string expectedWebhookUrl = "https://example.com";

        Assert.Equal(expectedRemoteUrl, parameters.RemoteUrl);
        Assert.Equal(expectedCustomID, parameters.CustomID);
        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedFolder, parameters.Folder);
        Assert.Equal(expectedMetadata, parameters.Metadata);
        Assert.Equal(expectedRandomPrefix, parameters.RandomPrefix);
        Assert.Equal(expectedTags, parameters.Tags);
        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UploadCreateFromUrlParams { RemoteUrl = "https://example.com" };

        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.FileName);
        Assert.False(parameters.RawBodyData.ContainsKey("file_name"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RandomPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("random_prefix"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UploadCreateFromUrlParams
        {
            RemoteUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            CustomID = null,
            FileName = null,
            Folder = null,
            Metadata = null,
            RandomPrefix = null,
            Tags = null,
            WebhookUrl = null,
        };

        Assert.Null(parameters.CustomID);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_id"));
        Assert.Null(parameters.FileName);
        Assert.False(parameters.RawBodyData.ContainsKey("file_name"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RandomPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("random_prefix"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void Url_Works()
    {
        UploadCreateFromUrlParams parameters = new() { RemoteUrl = "https://example.com" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/uploads/remote"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UploadCreateFromUrlParams
        {
            RemoteUrl = "https://example.com",
            CustomID = "custom_id",
            FileName = "file_name",
            Folder = "folder",
            Metadata = "metadata",
            RandomPrefix = "random_prefix",
            Tags = new(["string"]),
            WebhookUrl = "https://example.com",
        };

        UploadCreateFromUrlParams copied = new(parameters);

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
