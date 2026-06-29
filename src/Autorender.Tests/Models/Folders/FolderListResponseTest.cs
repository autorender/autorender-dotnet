using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    ParentFolderNo = "parent_folder_no",
                    Path = "path",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<Folder> expectedFolders =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FolderNo = "folder_no",
                Name = "name",
                ParentFolderNo = "parent_folder_no",
                Path = "path",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedFolders.Count, model.Folders.Count);
        for (int i = 0; i < expectedFolders.Count; i++)
        {
            Assert.Equal(expectedFolders[i], model.Folders[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    ParentFolderNo = "parent_folder_no",
                    Path = "path",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    ParentFolderNo = "parent_folder_no",
                    Path = "path",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Folder> expectedFolders =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FolderNo = "folder_no",
                Name = "name",
                ParentFolderNo = "parent_folder_no",
                Path = "path",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedFolders.Count, deserialized.Folders.Count);
        for (int i = 0; i < expectedFolders.Count; i++)
        {
            Assert.Equal(expectedFolders[i], deserialized.Folders[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    ParentFolderNo = "parent_folder_no",
                    Path = "path",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderListResponse
        {
            Folders =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FolderNo = "folder_no",
                    Name = "name",
                    ParentFolderNo = "parent_folder_no",
                    Path = "path",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        FolderListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FolderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FolderNo = "folder_no",
            Name = "name",
            ParentFolderNo = "parent_folder_no",
            Path = "path",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFolderNo = "folder_no";
        string expectedName = "name";
        string expectedParentFolderNo = "parent_folder_no";
        string expectedPath = "path";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFolderNo, model.FolderNo);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedParentFolderNo, model.ParentFolderNo);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FolderNo = "folder_no",
            Name = "name",
            ParentFolderNo = "parent_folder_no",
            Path = "path",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            FolderNo = "folder_no",
            Name = "name",
            ParentFolderNo = "parent_folder_no",
            Path = "path",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Folder>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFolderNo = "folder_no";
        string expectedName = "name";
        string expectedParentFolderNo = "parent_folder_no";
        string expectedPath = "path";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFolderNo, deserialized.FolderNo);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedParentFolderNo, deserialized.ParentFolderNo);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Folder
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FolderNo = "folder_no",
            Name = "name",
            ParentFolderNo = "parent_folder_no",
            Path = "path",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            FolderNo = "folder_no",
            Name = "name",
            ParentFolderNo = "parent_folder_no",
            Path = "path",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Folder copied = new(model);

        Assert.Equal(model, copied);
    }
}
