using System;
using System.Text;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new UploadCreateParams
        {
            File = file,
            FileName = "product.jpg",
            CustomID = "sku123",
            Folder = "products/sku123",
            Metadata = "{\"productId\":\"123\"}",
            RandomPrefix = "random_prefix",
            Tags = "product,thumbnail",
            Transform = "transform",
            WebhookUrl = "webhook_url",
        };

        BinaryContent expectedFile = file;
        string expectedFileName = "product.jpg";
        string expectedCustomID = "sku123";
        string expectedFolder = "products/sku123";
        string expectedMetadata = "{\"productId\":\"123\"}";
        string expectedRandomPrefix = "random_prefix";
        string expectedTags = "product,thumbnail";
        string expectedTransform = "transform";
        string expectedWebhookUrl = "webhook_url";

        Assert.Equal(expectedFile, parameters.File);
        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedCustomID, parameters.CustomID);
        Assert.Equal(expectedFolder, parameters.Folder);
        Assert.Equal(expectedMetadata, parameters.Metadata);
        Assert.Equal(expectedRandomPrefix, parameters.RandomPrefix);
        Assert.Equal(expectedTags, parameters.Tags);
        Assert.Equal(expectedTransform, parameters.Transform);
        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new UploadCreateParams { File = file, FileName = "product.jpg" };

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
        Assert.Null(parameters.Transform);
        Assert.False(parameters.RawBodyData.ContainsKey("transform"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new UploadCreateParams
        {
            File = file,
            FileName = "product.jpg",

            // Null should be interpreted as omitted for these properties
            CustomID = null,
            Folder = null,
            Metadata = null,
            RandomPrefix = null,
            Tags = null,
            Transform = null,
            WebhookUrl = null,
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
        Assert.Null(parameters.Transform);
        Assert.False(parameters.RawBodyData.ContainsKey("transform"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void Url_Works()
    {
        UploadCreateParams parameters = new()
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            FileName = "product.jpg",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/uploads"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UploadCreateParams
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            FileName = "product.jpg",
            CustomID = "sku123",
            Folder = "products/sku123",
            Metadata = "{\"productId\":\"123\"}",
            RandomPrefix = "random_prefix",
            Tags = "product,thumbnail",
            Transform = "transform",
            WebhookUrl = "webhook_url",
        };

        UploadCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
