using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomID = "custom_id",
            Extension = "extension",
            FileNo = "file_no",
            FolderNo = "folder_no",
            Height = -9007199254740991,
            IsDuplicate = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Tags = ["string"],
            Thumbnail = "thumbnail",
            UploadSource = "upload_source",
            Url = "url",
            Width = -9007199254740991,
            WorkspaceID = "workspace_id",
            Format = "format",
            Hash = "hash",
            IsPrivate = true,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomID = "custom_id";
        string expectedExtension = "extension";
        string expectedFileNo = "file_no";
        string expectedFolderNo = "folder_no";
        long expectedHeight = -9007199254740991;
        bool expectedIsDuplicate = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMimeType = "mime_type";
        string expectedName = "name";
        string expectedPath = "path";
        long expectedSize = -9007199254740991;
        List<string> expectedTags = ["string"];
        string expectedThumbnail = "thumbnail";
        string expectedUploadSource = "upload_source";
        string expectedUrl = "url";
        long expectedWidth = -9007199254740991;
        string expectedWorkspaceID = "workspace_id";
        string expectedFormat = "format";
        string expectedHash = "hash";
        bool expectedIsPrivate = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomID, model.CustomID);
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
        var model = new UploadCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomID = "custom_id",
            Extension = "extension",
            FileNo = "file_no",
            FolderNo = "folder_no",
            Height = -9007199254740991,
            IsDuplicate = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Tags = ["string"],
            Thumbnail = "thumbnail",
            UploadSource = "upload_source",
            Url = "url",
            Width = -9007199254740991,
            WorkspaceID = "workspace_id",
            Format = "format",
            Hash = "hash",
            IsPrivate = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomID = "custom_id",
            Extension = "extension",
            FileNo = "file_no",
            FolderNo = "folder_no",
            Height = -9007199254740991,
            IsDuplicate = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Tags = ["string"],
            Thumbnail = "thumbnail",
            UploadSource = "upload_source",
            Url = "url",
            Width = -9007199254740991,
            WorkspaceID = "workspace_id",
            Format = "format",
            Hash = "hash",
            IsPrivate = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomID = "custom_id";
        string expectedExtension = "extension";
        string expectedFileNo = "file_no";
        string expectedFolderNo = "folder_no";
        long expectedHeight = -9007199254740991;
        bool expectedIsDuplicate = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMimeType = "mime_type";
        string expectedName = "name";
        string expectedPath = "path";
        long expectedSize = -9007199254740991;
        List<string> expectedTags = ["string"];
        string expectedThumbnail = "thumbnail";
        string expectedUploadSource = "upload_source";
        string expectedUrl = "url";
        long expectedWidth = -9007199254740991;
        string expectedWorkspaceID = "workspace_id";
        string expectedFormat = "format";
        string expectedHash = "hash";
        bool expectedIsPrivate = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomID, deserialized.CustomID);
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
        var model = new UploadCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomID = "custom_id",
            Extension = "extension",
            FileNo = "file_no",
            FolderNo = "folder_no",
            Height = -9007199254740991,
            IsDuplicate = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Tags = ["string"],
            Thumbnail = "thumbnail",
            UploadSource = "upload_source",
            Url = "url",
            Width = -9007199254740991,
            WorkspaceID = "workspace_id",
            Format = "format",
            Hash = "hash",
            IsPrivate = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UploadCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomID = "custom_id",
            Extension = "extension",
            FileNo = "file_no",
            FolderNo = "folder_no",
            Height = -9007199254740991,
            IsDuplicate = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Tags = ["string"],
            Thumbnail = "thumbnail",
            UploadSource = "upload_source",
            Url = "url",
            Width = -9007199254740991,
            WorkspaceID = "workspace_id",
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
        var model = new UploadCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomID = "custom_id",
            Extension = "extension",
            FileNo = "file_no",
            FolderNo = "folder_no",
            Height = -9007199254740991,
            IsDuplicate = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Tags = ["string"],
            Thumbnail = "thumbnail",
            UploadSource = "upload_source",
            Url = "url",
            Width = -9007199254740991,
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UploadCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomID = "custom_id",
            Extension = "extension",
            FileNo = "file_no",
            FolderNo = "folder_no",
            Height = -9007199254740991,
            IsDuplicate = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Tags = ["string"],
            Thumbnail = "thumbnail",
            UploadSource = "upload_source",
            Url = "url",
            Width = -9007199254740991,
            WorkspaceID = "workspace_id",

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
        var model = new UploadCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomID = "custom_id",
            Extension = "extension",
            FileNo = "file_no",
            FolderNo = "folder_no",
            Height = -9007199254740991,
            IsDuplicate = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Tags = ["string"],
            Thumbnail = "thumbnail",
            UploadSource = "upload_source",
            Url = "url",
            Width = -9007199254740991,
            WorkspaceID = "workspace_id",

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
        var model = new UploadCreateResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomID = "custom_id",
            Extension = "extension",
            FileNo = "file_no",
            FolderNo = "folder_no",
            Height = -9007199254740991,
            IsDuplicate = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Tags = ["string"],
            Thumbnail = "thumbnail",
            UploadSource = "upload_source",
            Url = "url",
            Width = -9007199254740991,
            WorkspaceID = "workspace_id",
            Format = "format",
            Hash = "hash",
            IsPrivate = true,
        };

        UploadCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
