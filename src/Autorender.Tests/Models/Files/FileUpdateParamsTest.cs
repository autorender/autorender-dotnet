using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileUpdateParams
        {
            FileNo = "fileNo",
            AddTags = ["string"],
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RemoveTags = ["string"],
        };

        string expectedFileNo = "fileNo";
        List<string> expectedAddTags = ["string"];
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRemoveTags = ["string"];

        Assert.Equal(expectedFileNo, parameters.FileNo);
        Assert.NotNull(parameters.AddTags);
        Assert.Equal(expectedAddTags.Count, parameters.AddTags.Count);
        for (int i = 0; i < expectedAddTags.Count; i++)
        {
            Assert.Equal(expectedAddTags[i], parameters.AddTags[i]);
        }
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
        Assert.NotNull(parameters.RemoveTags);
        Assert.Equal(expectedRemoveTags.Count, parameters.RemoveTags.Count);
        for (int i = 0; i < expectedRemoveTags.Count; i++)
        {
            Assert.Equal(expectedRemoveTags[i], parameters.RemoveTags[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileUpdateParams { FileNo = "fileNo" };

        Assert.Null(parameters.AddTags);
        Assert.False(parameters.RawBodyData.ContainsKey("add_tags"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RemoveTags);
        Assert.False(parameters.RawBodyData.ContainsKey("remove_tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileUpdateParams
        {
            FileNo = "fileNo",

            // Null should be interpreted as omitted for these properties
            AddTags = null,
            Metadata = null,
            RemoveTags = null,
        };

        Assert.Null(parameters.AddTags);
        Assert.False(parameters.RawBodyData.ContainsKey("add_tags"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.RemoveTags);
        Assert.False(parameters.RawBodyData.ContainsKey("remove_tags"));
    }

    [Fact]
    public void Url_Works()
    {
        FileUpdateParams parameters = new() { FileNo = "fileNo" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/files/fileNo"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUpdateParams
        {
            FileNo = "fileNo",
            AddTags = ["string"],
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RemoveTags = ["string"],
        };

        FileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
