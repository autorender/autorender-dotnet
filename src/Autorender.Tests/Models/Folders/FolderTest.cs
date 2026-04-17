using System;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FolderNo = "folder_no",
            IsActive = true,
            IsDelete = true,
            Name = "name",
            ParentFolder = "parent_folder",
            Path = "path",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspace = new() { WorkspaceNo = "workspace_no" },
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFolderNo = "folder_no";
        bool expectedIsActive = true;
        bool expectedIsDelete = true;
        string expectedName = "name";
        string expectedParentFolder = "parent_folder";
        string expectedPath = "path";
        string expectedSource = "source";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Workspace expectedWorkspace = new() { WorkspaceNo = "workspace_no" };
        string expectedWorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedFolderNo, model.FolderNo);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedIsDelete, model.IsDelete);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedParentFolder, model.ParentFolder);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedWorkspace, model.Workspace);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
        Assert.Equal(expectedWorkspaceNo, model.WorkspaceNo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FolderNo = "folder_no",
            IsActive = true,
            IsDelete = true,
            Name = "name",
            ParentFolder = "parent_folder",
            Path = "path",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspace = new() { WorkspaceNo = "workspace_no" },
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Folder>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FolderNo = "folder_no",
            IsActive = true,
            IsDelete = true,
            Name = "name",
            ParentFolder = "parent_folder",
            Path = "path",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspace = new() { WorkspaceNo = "workspace_no" },
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Folder>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFolderNo = "folder_no";
        bool expectedIsActive = true;
        bool expectedIsDelete = true;
        string expectedName = "name";
        string expectedParentFolder = "parent_folder";
        string expectedPath = "path";
        string expectedSource = "source";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Workspace expectedWorkspace = new() { WorkspaceNo = "workspace_no" };
        string expectedWorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedFolderNo, deserialized.FolderNo);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedIsDelete, deserialized.IsDelete);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedParentFolder, deserialized.ParentFolder);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedWorkspace, deserialized.Workspace);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
        Assert.Equal(expectedWorkspaceNo, deserialized.WorkspaceNo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FolderNo = "folder_no",
            IsActive = true,
            IsDelete = true,
            Name = "name",
            ParentFolder = "parent_folder",
            Path = "path",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspace = new() { WorkspaceNo = "workspace_no" },
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Folder { ParentFolder = "parent_folder" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.FolderNo);
        Assert.False(model.RawData.ContainsKey("folder_no"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.IsDelete);
        Assert.False(model.RawData.ContainsKey("is_delete"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Workspace);
        Assert.False(model.RawData.ContainsKey("workspace"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Folder { ParentFolder = "parent_folder" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Folder
        {
            ParentFolder = "parent_folder",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CreatedBy = null,
            FolderNo = null,
            IsActive = null,
            IsDelete = null,
            Name = null,
            Path = null,
            Source = null,
            UpdatedAt = null,
            Workspace = null,
            WorkspaceID = null,
            WorkspaceNo = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CreatedBy);
        Assert.False(model.RawData.ContainsKey("created_by"));
        Assert.Null(model.FolderNo);
        Assert.False(model.RawData.ContainsKey("folder_no"));
        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.IsDelete);
        Assert.False(model.RawData.ContainsKey("is_delete"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Workspace);
        Assert.False(model.RawData.ContainsKey("workspace"));
        Assert.Null(model.WorkspaceID);
        Assert.False(model.RawData.ContainsKey("workspace_id"));
        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Folder
        {
            ParentFolder = "parent_folder",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CreatedAt = null,
            CreatedBy = null,
            FolderNo = null,
            IsActive = null,
            IsDelete = null,
            Name = null,
            Path = null,
            Source = null,
            UpdatedAt = null,
            Workspace = null,
            WorkspaceID = null,
            WorkspaceNo = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FolderNo = "folder_no",
            IsActive = true,
            IsDelete = true,
            Name = "name",
            Path = "path",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspace = new() { WorkspaceNo = "workspace_no" },
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        Assert.Null(model.ParentFolder);
        Assert.False(model.RawData.ContainsKey("parent_folder"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FolderNo = "folder_no",
            IsActive = true,
            IsDelete = true,
            Name = "name",
            Path = "path",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspace = new() { WorkspaceNo = "workspace_no" },
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FolderNo = "folder_no",
            IsActive = true,
            IsDelete = true,
            Name = "name",
            Path = "path",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspace = new() { WorkspaceNo = "workspace_no" },
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",

            ParentFolder = null,
        };

        Assert.Null(model.ParentFolder);
        Assert.True(model.RawData.ContainsKey("parent_folder"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FolderNo = "folder_no",
            IsActive = true,
            IsDelete = true,
            Name = "name",
            Path = "path",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspace = new() { WorkspaceNo = "workspace_no" },
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",

            ParentFolder = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedBy = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FolderNo = "folder_no",
            IsActive = true,
            IsDelete = true,
            Name = "name",
            ParentFolder = "parent_folder",
            Path = "path",
            Source = "source",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Workspace = new() { WorkspaceNo = "workspace_no" },
            WorkspaceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WorkspaceNo = "workspace_no",
        };

        Folder copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorkspaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Workspace { WorkspaceNo = "workspace_no" };

        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedWorkspaceNo, model.WorkspaceNo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Workspace { WorkspaceNo = "workspace_no" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Workspace>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Workspace { WorkspaceNo = "workspace_no" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Workspace>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedWorkspaceNo = "workspace_no";

        Assert.Equal(expectedWorkspaceNo, deserialized.WorkspaceNo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Workspace { WorkspaceNo = "workspace_no" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Workspace { };

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
            WorkspaceNo = null,
        };

        Assert.Null(model.WorkspaceNo);
        Assert.False(model.RawData.ContainsKey("workspace_no"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Workspace
        {
            // Null should be interpreted as omitted for these properties
            WorkspaceNo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Workspace { WorkspaceNo = "workspace_no" };

        Workspace copied = new(model);

        Assert.Equal(model, copied);
    }
}
