using System;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileListItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Thumbanil = "thumbanil",
            Url = "https://example.com",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExtension = "extension";
        string expectedFileNo = "file_no";
        long expectedFileSize = 0;
        string expectedFormat = "format";
        long expectedHeight = 0;
        string expectedName = "name";
        string expectedPath = "path";
        string expectedThumbanil = "thumbanil";
        string expectedUrl = "https://example.com";
        long expectedWidth = 0;
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExtension, model.Extension);
        Assert.Equal(expectedFileNo, model.FileNo);
        Assert.Equal(expectedFileSize, model.FileSize);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedThumbanil, model.Thumbanil);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedWorkspaceNo, model.WorkspaceNo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Thumbanil = "thumbanil",
            Url = "https://example.com",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Thumbanil = "thumbanil",
            Url = "https://example.com",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExtension = "extension";
        string expectedFileNo = "file_no";
        long expectedFileSize = 0;
        string expectedFormat = "format";
        long expectedHeight = 0;
        string expectedName = "name";
        string expectedPath = "path";
        string expectedThumbanil = "thumbanil";
        string expectedUrl = "https://example.com";
        long expectedWidth = 0;
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExtension, deserialized.Extension);
        Assert.Equal(expectedFileNo, deserialized.FileNo);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedThumbanil, deserialized.Thumbanil);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedWorkspaceNo, deserialized.WorkspaceNo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Thumbanil = "thumbanil",
            Url = "https://example.com",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileListItem { Height = 0, Width = 0 };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Extension);
        Assert.False(model.RawData.ContainsKey("extension"));
        Assert.Null(model.FileNo);
        Assert.False(model.RawData.ContainsKey("file_no"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Thumbanil);
        Assert.False(model.RawData.ContainsKey("thumbanil"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileListItem { Height = 0, Width = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileListItem
        {
            Height = 0,
            Width = 0,

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Extension = null,
            FileNo = null,
            FileSize = null,
            Format = null,
            Name = null,
            Path = null,
            Thumbanil = null,
            Url = null,
            WorkspaceNo = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Extension);
        Assert.False(model.RawData.ContainsKey("extension"));
        Assert.Null(model.FileNo);
        Assert.False(model.RawData.ContainsKey("file_no"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Thumbanil);
        Assert.False(model.RawData.ContainsKey("thumbanil"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileListItem
        {
            Height = 0,
            Width = 0,

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Extension = null,
            FileNo = null,
            FileSize = null,
            Format = null,
            Name = null,
            Path = null,
            Thumbanil = null,
            Url = null,
            WorkspaceNo = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Name = "name",
            Path = "path",
            Thumbanil = "thumbanil",
            Url = "https://example.com",
            WorkspaceNo = "workspace_no",
        };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Name = "name",
            Path = "path",
            Thumbanil = "thumbanil",
            Url = "https://example.com",
            WorkspaceNo = "workspace_no",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FileListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Name = "name",
            Path = "path",
            Thumbanil = "thumbanil",
            Url = "https://example.com",
            WorkspaceNo = "workspace_no",

            Height = null,
            Width = null,
        };

        Assert.Null(model.Height);
        Assert.True(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.True(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Name = "name",
            Path = "path",
            Thumbanil = "thumbanil",
            Url = "https://example.com",
            WorkspaceNo = "workspace_no",

            Height = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileListItem
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            Height = 0,
            Name = "name",
            Path = "path",
            Thumbanil = "thumbanil",
            Url = "https://example.com",
            Width = 0,
            WorkspaceNo = "workspace_no",
        };

        FileListItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
