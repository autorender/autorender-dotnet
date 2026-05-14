using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.MultipartUploads;

namespace Autorender.Tests.Models.MultipartUploads;

public class MultipartUploadCompleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MultipartUploadCompleteResponse
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomID = null,
            Extension = "jpg",
            FileNo = "file_abc123",
            FolderNo = "folder_abc123",
            Height = 1080,
            IsDuplicate = false,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Tags = ["string"],
            Thumbnail = "https://cdn.autorender.io/thumb.jpg",
            UploadSource = "direct",
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
            WorkspaceID = "ws_abc123",
            Format = "jpg",
            Hash = "abc123def456",
            IsPrivate = false,
        };

        string expectedID = "id_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedExtension = "jpg";
        string expectedFileNo = "file_abc123";
        string expectedFolderNo = "folder_abc123";
        long expectedHeight = 1080;
        bool expectedIsDuplicate = false;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMimeType = "image/jpeg";
        string expectedName = "example.jpg";
        string expectedPath = "/example.jpg";
        long expectedSize = 12345;
        List<string> expectedTags = ["string"];
        string expectedThumbnail = "https://cdn.autorender.io/thumb.jpg";
        string expectedUploadSource = "direct";
        string expectedUrl = "https://cdn.autorender.io/example.jpg";
        long expectedWidth = 1920;
        string expectedWorkspaceID = "ws_abc123";
        string expectedFormat = "jpg";
        string expectedHash = "abc123def456";
        bool expectedIsPrivate = false;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.CustomID);
        Assert.Equal(expectedExtension, model.Extension);
        Assert.Equal(expectedFileNo, model.FileNo);
        Assert.Equal(expectedFolderNo, model.FolderNo);
        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedIsDuplicate, model.IsDuplicate);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedSize, model.Size);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedThumbnail, model.Thumbnail);
        Assert.Equal(expectedUploadSource, model.UploadSource);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedHash, model.Hash);
        Assert.Equal(expectedIsPrivate, model.IsPrivate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MultipartUploadCompleteResponse
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomID = null,
            Extension = "jpg",
            FileNo = "file_abc123",
            FolderNo = "folder_abc123",
            Height = 1080,
            IsDuplicate = false,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Tags = ["string"],
            Thumbnail = "https://cdn.autorender.io/thumb.jpg",
            UploadSource = "direct",
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
            WorkspaceID = "ws_abc123",
            Format = "jpg",
            Hash = "abc123def456",
            IsPrivate = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipartUploadCompleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MultipartUploadCompleteResponse
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomID = null,
            Extension = "jpg",
            FileNo = "file_abc123",
            FolderNo = "folder_abc123",
            Height = 1080,
            IsDuplicate = false,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Tags = ["string"],
            Thumbnail = "https://cdn.autorender.io/thumb.jpg",
            UploadSource = "direct",
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
            WorkspaceID = "ws_abc123",
            Format = "jpg",
            Hash = "abc123def456",
            IsPrivate = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipartUploadCompleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedExtension = "jpg";
        string expectedFileNo = "file_abc123";
        string expectedFolderNo = "folder_abc123";
        long expectedHeight = 1080;
        bool expectedIsDuplicate = false;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMimeType = "image/jpeg";
        string expectedName = "example.jpg";
        string expectedPath = "/example.jpg";
        long expectedSize = 12345;
        List<string> expectedTags = ["string"];
        string expectedThumbnail = "https://cdn.autorender.io/thumb.jpg";
        string expectedUploadSource = "direct";
        string expectedUrl = "https://cdn.autorender.io/example.jpg";
        long expectedWidth = 1920;
        string expectedWorkspaceID = "ws_abc123";
        string expectedFormat = "jpg";
        string expectedHash = "abc123def456";
        bool expectedIsPrivate = false;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.CustomID);
        Assert.Equal(expectedExtension, deserialized.Extension);
        Assert.Equal(expectedFileNo, deserialized.FileNo);
        Assert.Equal(expectedFolderNo, deserialized.FolderNo);
        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedIsDuplicate, deserialized.IsDuplicate);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedSize, deserialized.Size);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedThumbnail, deserialized.Thumbnail);
        Assert.Equal(expectedUploadSource, deserialized.UploadSource);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedHash, deserialized.Hash);
        Assert.Equal(expectedIsPrivate, deserialized.IsPrivate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MultipartUploadCompleteResponse
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomID = null,
            Extension = "jpg",
            FileNo = "file_abc123",
            FolderNo = "folder_abc123",
            Height = 1080,
            IsDuplicate = false,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Tags = ["string"],
            Thumbnail = "https://cdn.autorender.io/thumb.jpg",
            UploadSource = "direct",
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
            WorkspaceID = "ws_abc123",
            Format = "jpg",
            Hash = "abc123def456",
            IsPrivate = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MultipartUploadCompleteResponse
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomID = null,
            Extension = "jpg",
            FileNo = "file_abc123",
            FolderNo = "folder_abc123",
            Height = 1080,
            IsDuplicate = false,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Tags = ["string"],
            Thumbnail = "https://cdn.autorender.io/thumb.jpg",
            UploadSource = "direct",
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
            WorkspaceID = "ws_abc123",
        };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Hash);
        Assert.False(model.RawData.ContainsKey("hash"));
        Assert.Null(model.IsPrivate);
        Assert.False(model.RawData.ContainsKey("is_private"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MultipartUploadCompleteResponse
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomID = null,
            Extension = "jpg",
            FileNo = "file_abc123",
            FolderNo = "folder_abc123",
            Height = 1080,
            IsDuplicate = false,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Tags = ["string"],
            Thumbnail = "https://cdn.autorender.io/thumb.jpg",
            UploadSource = "direct",
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
            WorkspaceID = "ws_abc123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MultipartUploadCompleteResponse
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomID = null,
            Extension = "jpg",
            FileNo = "file_abc123",
            FolderNo = "folder_abc123",
            Height = 1080,
            IsDuplicate = false,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Tags = ["string"],
            Thumbnail = "https://cdn.autorender.io/thumb.jpg",
            UploadSource = "direct",
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
            WorkspaceID = "ws_abc123",

            // Null should be interpreted as omitted for these properties
            Format = null,
            Hash = null,
            IsPrivate = null,
        };

        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Hash);
        Assert.False(model.RawData.ContainsKey("hash"));
        Assert.Null(model.IsPrivate);
        Assert.False(model.RawData.ContainsKey("is_private"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MultipartUploadCompleteResponse
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomID = null,
            Extension = "jpg",
            FileNo = "file_abc123",
            FolderNo = "folder_abc123",
            Height = 1080,
            IsDuplicate = false,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Tags = ["string"],
            Thumbnail = "https://cdn.autorender.io/thumb.jpg",
            UploadSource = "direct",
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
            WorkspaceID = "ws_abc123",

            // Null should be interpreted as omitted for these properties
            Format = null,
            Hash = null,
            IsPrivate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MultipartUploadCompleteResponse
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            CustomID = null,
            Extension = "jpg",
            FileNo = "file_abc123",
            FolderNo = "folder_abc123",
            Height = 1080,
            IsDuplicate = false,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Tags = ["string"],
            Thumbnail = "https://cdn.autorender.io/thumb.jpg",
            UploadSource = "direct",
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
            WorkspaceID = "ws_abc123",
            Format = "jpg",
            Hash = "abc123def456",
            IsPrivate = false,
        };

        MultipartUploadCompleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
