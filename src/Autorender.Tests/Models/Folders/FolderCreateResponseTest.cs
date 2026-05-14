using System;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderCreateResponse
        {
            ID = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FolderNo = "folder_abc123",
            Name = "example.jpg",
            ParentFolderNo = null,
            Path = "/example.jpg",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
        };

        string expectedID = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedFolderNo = "folder_abc123";
        string expectedName = "example.jpg";
        string expectedPath = "/example.jpg";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFolderNo, model.FolderNo);
        Assert.Equal(expectedName, model.Name);
        Assert.Null(model.ParentFolderNo);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderCreateResponse
        {
            ID = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FolderNo = "folder_abc123",
            Name = "example.jpg",
            ParentFolderNo = null,
            Path = "/example.jpg",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderCreateResponse
        {
            ID = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FolderNo = "folder_abc123",
            Name = "example.jpg",
            ParentFolderNo = null,
            Path = "/example.jpg",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedFolderNo = "folder_abc123";
        string expectedName = "example.jpg";
        string expectedPath = "/example.jpg";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFolderNo, deserialized.FolderNo);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Null(deserialized.ParentFolderNo);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderCreateResponse
        {
            ID = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FolderNo = "folder_abc123",
            Name = "example.jpg",
            ParentFolderNo = null,
            Path = "/example.jpg",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderCreateResponse
        {
            ID = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FolderNo = "folder_abc123",
            Name = "example.jpg",
            ParentFolderNo = null,
            Path = "/example.jpg",
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
        };

        FolderCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
