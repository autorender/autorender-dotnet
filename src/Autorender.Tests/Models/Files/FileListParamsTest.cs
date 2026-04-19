using System;
using System.Text.Json;
using Autorender.Core;
using Autorender.Exceptions;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileListParams
        {
            FolderNo = "folderNo",
            Limit = 1,
            Name = "name",
            Page = 1,
            Path = "path",
            Sort = Sort.CreatedAtAsc,
            Tags = "tags",
        };

        string expectedFolderNo = "folderNo";
        long expectedLimit = 1;
        string expectedName = "name";
        long expectedPage = 1;
        string expectedPath = "path";
        ApiEnum<string, Sort> expectedSort = Sort.CreatedAtAsc;
        string expectedTags = "tags";

        Assert.Equal(expectedFolderNo, parameters.FolderNo);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPage, parameters.Page);
        Assert.Equal(expectedPath, parameters.Path);
        Assert.Equal(expectedSort, parameters.Sort);
        Assert.Equal(expectedTags, parameters.Tags);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams { };

        Assert.Null(parameters.FolderNo);
        Assert.False(parameters.RawQueryData.ContainsKey("folderNo"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawQueryData.ContainsKey("path"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            // Null should be interpreted as omitted for these properties
            FolderNo = null,
            Limit = null,
            Name = null,
            Page = null,
            Path = null,
            Sort = null,
            Tags = null,
        };

        Assert.Null(parameters.FolderNo);
        Assert.False(parameters.RawQueryData.ContainsKey("folderNo"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawQueryData.ContainsKey("path"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawQueryData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        FileListParams parameters = new()
        {
            FolderNo = "folderNo",
            Limit = 1,
            Name = "name",
            Page = 1,
            Path = "path",
            Sort = Sort.CreatedAtAsc,
            Tags = "tags",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://upload.autorender.io/api/v1/files?folderNo=folderNo&limit=1&name=name&page=1&path=path&sort=created_at_asc&tags=tags"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileListParams
        {
            FolderNo = "folderNo",
            Limit = 1,
            Name = "name",
            Page = 1,
            Path = "path",
            Sort = Sort.CreatedAtAsc,
            Tags = "tags",
        };

        FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SortTest : TestBase
{
    [Theory]
    [InlineData(Sort.CreatedAtAsc)]
    [InlineData(Sort.CreatedAtDesc)]
    [InlineData(Sort.SizeAsc)]
    [InlineData(Sort.SizeDesc)]
    public void Validation_Works(Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AutorenderInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sort.CreatedAtAsc)]
    [InlineData(Sort.CreatedAtDesc)]
    [InlineData(Sort.SizeAsc)]
    [InlineData(Sort.SizeDesc)]
    public void SerializationRoundtrip_Works(Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
