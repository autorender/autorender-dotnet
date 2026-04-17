using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileRenameResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileRenameResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            FolderID = "folder_id",
            Format = "format",
            Height = 0,
            IsActive = true,
            IsDefault = true,
            IsDelete = true,
            MetaData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Orientation = "orientation",
            OriginalUrl = "original_url",
            Path = "path",
            Source = "source",
            TransformString = "transform_string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = 0,
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedExtension = "extension";
        string expectedFileNo = "file_no";
        long expectedFileSize = 0;
        string expectedFolderID = "folder_id";
        string expectedFormat = "format";
        long expectedHeight = 0;
        bool expectedIsActive = true;
        bool expectedIsDefault = true;
        bool expectedIsDelete = true;
        Dictionary<string, JsonElement> expectedMetaData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        string expectedOrientation = "orientation";
        string expectedOriginalUrl = "original_url";
        string expectedPath = "path";
        string expectedSource = "source";
        string expectedTransformString = "transform_string";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "url";
        long expectedWidth = 0;
        string expectedWorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedExtension, model.Extension);
        Assert.Equal(expectedFileNo, model.FileNo);
        Assert.Equal(expectedFileSize, model.FileSize);
        Assert.Equal(expectedFolderID, model.FolderID);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedIsDelete, model.IsDelete);
        Assert.NotNull(model.MetaData);
        Assert.Equal(expectedMetaData.Count, model.MetaData.Count);
        foreach (var item in expectedMetaData)
        {
            Assert.True(model.MetaData.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.MetaData[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrientation, model.Orientation);
        Assert.Equal(expectedOriginalUrl, model.OriginalUrl);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTransformString, model.TransformString);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
        Assert.Equal(expectedWorkspaceNo, model.WorkspaceNo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileRenameResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            FolderID = "folder_id",
            Format = "format",
            Height = 0,
            IsActive = true,
            IsDefault = true,
            IsDelete = true,
            MetaData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Orientation = "orientation",
            OriginalUrl = "original_url",
            Path = "path",
            Source = "source",
            TransformString = "transform_string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = 0,
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRenameResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileRenameResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            FolderID = "folder_id",
            Format = "format",
            Height = 0,
            IsActive = true,
            IsDefault = true,
            IsDelete = true,
            MetaData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Orientation = "orientation",
            OriginalUrl = "original_url",
            Path = "path",
            Source = "source",
            TransformString = "transform_string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = 0,
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRenameResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedExtension = "extension";
        string expectedFileNo = "file_no";
        long expectedFileSize = 0;
        string expectedFolderID = "folder_id";
        string expectedFormat = "format";
        long expectedHeight = 0;
        bool expectedIsActive = true;
        bool expectedIsDefault = true;
        bool expectedIsDelete = true;
        Dictionary<string, JsonElement> expectedMetaData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        string expectedOrientation = "orientation";
        string expectedOriginalUrl = "original_url";
        string expectedPath = "path";
        string expectedSource = "source";
        string expectedTransformString = "transform_string";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "url";
        long expectedWidth = 0;
        string expectedWorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedExtension, deserialized.Extension);
        Assert.Equal(expectedFileNo, deserialized.FileNo);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
        Assert.Equal(expectedFolderID, deserialized.FolderID);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedIsDelete, deserialized.IsDelete);
        Assert.NotNull(deserialized.MetaData);
        Assert.Equal(expectedMetaData.Count, deserialized.MetaData.Count);
        foreach (var item in expectedMetaData)
        {
            Assert.True(deserialized.MetaData.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.MetaData[item.Key]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrientation, deserialized.Orientation);
        Assert.Equal(expectedOriginalUrl, deserialized.OriginalUrl);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTransformString, deserialized.TransformString);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
        Assert.Equal(expectedWorkspaceNo, deserialized.WorkspaceNo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileRenameResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            FolderID = "folder_id",
            Format = "format",
            Height = 0,
            IsActive = true,
            IsDefault = true,
            IsDelete = true,
            MetaData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Orientation = "orientation",
            OriginalUrl = "original_url",
            Path = "path",
            Source = "source",
            TransformString = "transform_string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = 0,
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileRenameResponse
        {
            FolderID = "folder_id",
            Height = 0,
            Orientation = "orientation",
            OriginalUrl = "original_url",
            Path = "path",
            TransformString = "transform_string",
            Width = 0,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.Extension);
        Assert.False(model.RawData.ContainsKey("extension"));
        Assert.Null(model.FileNo);
        Assert.False(model.RawData.ContainsKey("file_no"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("is_default"));
        Assert.Null(model.IsDelete);
        Assert.False(model.RawData.ContainsKey("is_delete"));
        Assert.Null(model.MetaData);
        Assert.False(model.RawData.ContainsKey("meta_data"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileRenameResponse
        {
            FolderID = "folder_id",
            Height = 0,
            Orientation = "orientation",
            OriginalUrl = "original_url",
            Path = "path",
            TransformString = "transform_string",
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileRenameResponse
        {
            FolderID = "folder_id",
            Height = 0,
            Orientation = "orientation",
            OriginalUrl = "original_url",
            Path = "path",
            TransformString = "transform_string",
            Width = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CreatedBy = null,
            Extension = null,
            FileNo = null,
            FileSize = null,
            Format = null,
            IsActive = null,
            IsDefault = null,
            IsDelete = null,
            MetaData = null,
            Name = null,
            Source = null,
            UpdatedAt = null,
            Url = null,
            WorkspaceID = null,
            WorkspaceNo = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.Extension);
        Assert.False(model.RawData.ContainsKey("extension"));
        Assert.Null(model.FileNo);
        Assert.False(model.RawData.ContainsKey("file_no"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.IsDefault);
        Assert.False(model.RawData.ContainsKey("is_default"));
        Assert.Null(model.IsDelete);
        Assert.False(model.RawData.ContainsKey("is_delete"));
        Assert.Null(model.MetaData);
        Assert.False(model.RawData.ContainsKey("meta_data"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileRenameResponse
        {
            FolderID = "folder_id",
            Height = 0,
            Orientation = "orientation",
            OriginalUrl = "original_url",
            Path = "path",
            TransformString = "transform_string",
            Width = 0,

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CreatedBy = null,
            Extension = null,
            FileNo = null,
            FileSize = null,
            Format = null,
            IsActive = null,
            IsDefault = null,
            IsDelete = null,
            MetaData = null,
            Name = null,
            Source = null,
            UpdatedAt = null,
            Url = null,
            WorkspaceID = null,
            WorkspaceNo = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileRenameResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            IsActive = true,
            IsDefault = true,
            IsDelete = true,
            MetaData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        Assert.Null(model.FolderID);
        Assert.False(model.RawData.ContainsKey("folder_id"));
        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Orientation);
        Assert.False(model.RawData.ContainsKey("orientation"));
        Assert.Null(model.OriginalUrl);
        Assert.False(model.RawData.ContainsKey("original_url"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.TransformString);
        Assert.False(model.RawData.ContainsKey("transform_string"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileRenameResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            IsActive = true,
            IsDefault = true,
            IsDelete = true,
            MetaData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FileRenameResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            IsActive = true,
            IsDefault = true,
            IsDelete = true,
            MetaData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",

            FolderID = null,
            Height = null,
            Orientation = null,
            OriginalUrl = null,
            Path = null,
            TransformString = null,
            Width = null,
        };

        Assert.Null(model.FolderID);
        Assert.True(model.RawData.ContainsKey("folder_id"));
        Assert.Null(model.Height);
        Assert.True(model.RawData.ContainsKey("height"));
        Assert.Null(model.Orientation);
        Assert.True(model.RawData.ContainsKey("orientation"));
        Assert.Null(model.OriginalUrl);
        Assert.True(model.RawData.ContainsKey("original_url"));
        Assert.Null(model.Path);
        Assert.True(model.RawData.ContainsKey("path"));
        Assert.Null(model.TransformString);
        Assert.True(model.RawData.ContainsKey("transform_string"));
        Assert.Null(model.Width);
        Assert.True(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileRenameResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            Format = "format",
            IsActive = true,
            IsDefault = true,
            IsDelete = true,
            MetaData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",

            FolderID = null,
            Height = null,
            Orientation = null,
            OriginalUrl = null,
            Path = null,
            TransformString = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileRenameResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Extension = "extension",
            FileNo = "file_no",
            FileSize = 0,
            FolderID = "folder_id",
            Format = "format",
            Height = 0,
            IsActive = true,
            IsDefault = true,
            IsDelete = true,
            MetaData = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Orientation = "orientation",
            OriginalUrl = "original_url",
            Path = "path",
            Source = "source",
            TransformString = "transform_string",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = 0,
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        FileRenameResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
