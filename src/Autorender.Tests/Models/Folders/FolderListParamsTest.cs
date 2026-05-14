using System;
using System.Text.Json;
using Autorender.Core;
using Autorender.Exceptions;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderListParams
        {
            ParentFolderNo = "parent_folder_no",
            Search = "search",
            Sort = Sort.NameAsc,
        };

        string expectedParentFolderNo = "parent_folder_no";
        string expectedSearch = "search";
        ApiEnum<string, Sort> expectedSort = Sort.NameAsc;

        Assert.Equal(expectedParentFolderNo, parameters.ParentFolderNo);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedSort, parameters.Sort);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FolderListParams { };

        Assert.Null(parameters.ParentFolderNo);
        Assert.False(parameters.RawQueryData.ContainsKey("parent_folder_no"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FolderListParams
        {
            // Null should be interpreted as omitted for these properties
            ParentFolderNo = null,
            Search = null,
            Sort = null,
        };

        Assert.Null(parameters.ParentFolderNo);
        Assert.False(parameters.RawQueryData.ContainsKey("parent_folder_no"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
    }

    [Fact]
    public void Url_Works()
    {
        FolderListParams parameters = new()
        {
            ParentFolderNo = "parent_folder_no",
            Search = "search",
            Sort = Sort.NameAsc,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://upload.autorender.io/api/v1/folders?parent_folder_no=parent_folder_no&search=search&sort=name_asc"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderListParams
        {
            ParentFolderNo = "parent_folder_no",
            Search = "search",
            Sort = Sort.NameAsc,
        };

        FolderListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SortTest : TestBase
{
    [Theory]
    [InlineData(Sort.NameAsc)]
    [InlineData(Sort.NameDesc)]
    [InlineData(Sort.CreatedAtAsc)]
    [InlineData(Sort.CreatedAtDesc)]
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
    [InlineData(Sort.NameAsc)]
    [InlineData(Sort.NameDesc)]
    [InlineData(Sort.CreatedAtAsc)]
    [InlineData(Sort.CreatedAtDesc)]
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
