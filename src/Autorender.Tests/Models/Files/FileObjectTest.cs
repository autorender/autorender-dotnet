using System;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileObject
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AssetKey = "asset_key",
                AssetUrl = "asset_url",
                Dimensions = new() { Height = 0, Width = 0 },
                Extension = "extension",
                FileNo = "file_no",
                Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
                Format = "format",
                Name = "name",
                Path = "path",
                Size = 0,
                UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UploadedBy = "uploaded_by",
                Url = "url",
                Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
            },
            Success = true,
        };

        Data expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Path = "path",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileObject
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AssetKey = "asset_key",
                AssetUrl = "asset_url",
                Dimensions = new() { Height = 0, Width = 0 },
                Extension = "extension",
                FileNo = "file_no",
                Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
                Format = "format",
                Name = "name",
                Path = "path",
                Size = 0,
                UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UploadedBy = "uploaded_by",
                Url = "url",
                Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
            },
            Success = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileObject
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AssetKey = "asset_key",
                AssetUrl = "asset_url",
                Dimensions = new() { Height = 0, Width = 0 },
                Extension = "extension",
                FileNo = "file_no",
                Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
                Format = "format",
                Name = "name",
                Path = "path",
                Size = 0,
                UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UploadedBy = "uploaded_by",
                Url = "url",
                Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
            },
            Success = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Path = "path",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
        };
        bool expectedSuccess = true;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileObject
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AssetKey = "asset_key",
                AssetUrl = "asset_url",
                Dimensions = new() { Height = 0, Width = 0 },
                Extension = "extension",
                FileNo = "file_no",
                Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
                Format = "format",
                Name = "name",
                Path = "path",
                Size = 0,
                UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UploadedBy = "uploaded_by",
                Url = "url",
                Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
            },
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileObject { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileObject
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            Success = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileObject
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileObject
        {
            Data = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                AssetKey = "asset_key",
                AssetUrl = "asset_url",
                Dimensions = new() { Height = 0, Width = 0 },
                Extension = "extension",
                FileNo = "file_no",
                Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
                Format = "format",
                Name = "name",
                Path = "path",
                Size = 0,
                UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UploadedBy = "uploaded_by",
                Url = "url",
                Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
            },
            Success = true,
        };

        FileObject copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Path = "path",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAssetKey = "asset_key";
        string expectedAssetUrl = "asset_url";
        Dimensions expectedDimensions = new() { Height = 0, Width = 0 };
        string expectedExtension = "extension";
        string expectedFileNo = "file_no";
        JsonElement expectedFolder = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedFormat = "format";
        string expectedName = "name";
        string expectedPath = "path";
        long expectedSize = 0;
        DateTimeOffset expectedUploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUploadedBy = "uploaded_by";
        string expectedUrl = "url";
        Workspace expectedWorkspace = new() { Name = "name", WorkspaceNo = "workspace_no" };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAssetKey, model.AssetKey);
        Assert.Equal(expectedAssetUrl, model.AssetUrl);
        Assert.Equal(expectedDimensions, model.Dimensions);
        Assert.Equal(expectedExtension, model.Extension);
        Assert.Equal(expectedFileNo, model.FileNo);
        Assert.NotNull(model.Folder);
        Assert.True(JsonElement.DeepEquals(expectedFolder, model.Folder.Value));
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSize, model.Size);
        Assert.Equal(expectedUploadedAt, model.UploadedAt);
        Assert.Equal(expectedUploadedBy, model.UploadedBy);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedWorkspace, model.Workspace);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Path = "path",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Path = "path",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedAssetKey = "asset_key";
        string expectedAssetUrl = "asset_url";
        Dimensions expectedDimensions = new() { Height = 0, Width = 0 };
        string expectedExtension = "extension";
        string expectedFileNo = "file_no";
        JsonElement expectedFolder = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedFormat = "format";
        string expectedName = "name";
        string expectedPath = "path";
        long expectedSize = 0;
        DateTimeOffset expectedUploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUploadedBy = "uploaded_by";
        string expectedUrl = "url";
        Workspace expectedWorkspace = new() { Name = "name", WorkspaceNo = "workspace_no" };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAssetKey, deserialized.AssetKey);
        Assert.Equal(expectedAssetUrl, deserialized.AssetUrl);
        Assert.Equal(expectedDimensions, deserialized.Dimensions);
        Assert.Equal(expectedExtension, deserialized.Extension);
        Assert.Equal(expectedFileNo, deserialized.FileNo);
        Assert.NotNull(deserialized.Folder);
        Assert.True(JsonElement.DeepEquals(expectedFolder, deserialized.Folder.Value));
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSize, deserialized.Size);
        Assert.Equal(expectedUploadedAt, deserialized.UploadedAt);
        Assert.Equal(expectedUploadedBy, deserialized.UploadedBy);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedWorkspace, deserialized.Workspace);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Path = "path",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { Path = "path" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AssetKey);
        Assert.False(model.RawData.ContainsKey("asset_key"));
        Assert.Null(model.AssetUrl);
        Assert.False(model.RawData.ContainsKey("asset_url"));
        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.Extension);
        Assert.False(model.RawData.ContainsKey("extension"));
        Assert.Null(model.FileNo);
        Assert.False(model.RawData.ContainsKey("file_no"));
        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.UploadedAt);
        Assert.False(model.RawData.ContainsKey("uploaded_at"));
        Assert.Null(model.UploadedBy);
        Assert.False(model.RawData.ContainsKey("uploaded_by"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.Workspace);
        Assert.False(model.RawData.ContainsKey("workspace"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { Path = "path" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ID = null,
            AssetKey = null,
            AssetUrl = null,
            Dimensions = null,
            Extension = null,
            FileNo = null,
            Folder = null,
            Format = null,
            Name = null,
            Size = null,
            UploadedAt = null,
            UploadedBy = null,
            Url = null,
            Workspace = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AssetKey);
        Assert.False(model.RawData.ContainsKey("asset_key"));
        Assert.Null(model.AssetUrl);
        Assert.False(model.RawData.ContainsKey("asset_url"));
        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.Extension);
        Assert.False(model.RawData.ContainsKey("extension"));
        Assert.Null(model.FileNo);
        Assert.False(model.RawData.ContainsKey("file_no"));
        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Size);
        Assert.False(model.RawData.ContainsKey("size"));
        Assert.Null(model.UploadedAt);
        Assert.False(model.RawData.ContainsKey("uploaded_at"));
        Assert.Null(model.UploadedBy);
        Assert.False(model.RawData.ContainsKey("uploaded_by"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
        Assert.Null(model.Workspace);
        Assert.False(model.RawData.ContainsKey("workspace"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            Path = "path",

            // Null should be interpreted as omitted for these properties
            ID = null,
            AssetKey = null,
            AssetUrl = null,
            Dimensions = null,
            Extension = null,
            FileNo = null,
            Folder = null,
            Format = null,
            Name = null,
            Size = null,
            UploadedAt = null,
            UploadedBy = null,
            Url = null,
            Workspace = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
        };

        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },

            Path = null,
        };

        Assert.Null(model.Path);
        Assert.True(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },

            Path = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AssetKey = "asset_key",
            AssetUrl = "asset_url",
            Dimensions = new() { Height = 0, Width = 0 },
            Extension = "extension",
            FileNo = "file_no",
            Folder = JsonSerializer.Deserialize<JsonElement>("{}"),
            Format = "format",
            Name = "name",
            Path = "path",
            Size = 0,
            UploadedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UploadedBy = "uploaded_by",
            Url = "url",
            Workspace = new() { Name = "name", WorkspaceNo = "workspace_no" },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DimensionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Dimensions { Height = 0, Width = 0 };

        long expectedHeight = 0;
        long expectedWidth = 0;

        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Dimensions { Height = 0, Width = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dimensions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Dimensions { Height = 0, Width = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dimensions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedHeight = 0;
        long expectedWidth = 0;

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Dimensions { Height = 0, Width = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Dimensions { };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Dimensions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Dimensions
        {
            // Null should be interpreted as omitted for these properties
            Height = null,
            Width = null,
        };

        Assert.Null(model.Height);
        Assert.False(model.RawData.ContainsKey("height"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Dimensions
        {
            // Null should be interpreted as omitted for these properties
            Height = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Dimensions { Height = 0, Width = 0 };

        Dimensions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkspaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Workspace { Name = "name", WorkspaceNo = "workspace_no" };

        string expectedName = "name";
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedWorkspaceNo, model.WorkspaceNo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Workspace { Name = "name", WorkspaceNo = "workspace_no" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Workspace>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Workspace { Name = "name", WorkspaceNo = "workspace_no" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Workspace>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedWorkspaceNo, deserialized.WorkspaceNo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Workspace { Name = "name", WorkspaceNo = "workspace_no" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Workspace { };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Workspace { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Workspace
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            WorkspaceNo = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Workspace
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            WorkspaceNo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Workspace { Name = "name", WorkspaceNo = "workspace_no" };

        Workspace copied = new(model);

        Assert.Equal(model, copied);
    }
}
