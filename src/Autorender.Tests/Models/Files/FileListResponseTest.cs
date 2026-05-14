using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileListResponse
        {
            Files =
            [
                new()
                {
                    ID = "id_abc123",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    FileNo = "file_abc123",
                    FolderName = null,
                    FolderNo = null,
                    Format = "jpg",
                    Height = 1080,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MimeType = "image/jpeg",
                    Name = "example.jpg",
                    Path = "/example.jpg",
                    Size = 12345,
                    Source = "direct",
                    Tags = ["string"],
                    UpdatedAt = null,
                    Url = "https://cdn.autorender.io/example.jpg",
                    Width = 1920,
                },
            ],
            Meta = new()
            {
                HasNext = false,
                HasPrev = false,
                Limit = 20,
                Page = 1,
                Total = 100,
            },
        };

        List<File> expectedFiles =
        [
            new()
            {
                ID = "id_abc123",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                FileNo = "file_abc123",
                FolderName = null,
                FolderNo = null,
                Format = "jpg",
                Height = 1080,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MimeType = "image/jpeg",
                Name = "example.jpg",
                Path = "/example.jpg",
                Size = 12345,
                Source = "direct",
                Tags = ["string"],
                UpdatedAt = null,
                Url = "https://cdn.autorender.io/example.jpg",
                Width = 1920,
            },
        ];
        Meta expectedMeta = new()
        {
            HasNext = false,
            HasPrev = false,
            Limit = 20,
            Page = 1,
            Total = 100,
        };

        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedMeta, model.Meta);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileListResponse
        {
            Files =
            [
                new()
                {
                    ID = "id_abc123",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    FileNo = "file_abc123",
                    FolderName = null,
                    FolderNo = null,
                    Format = "jpg",
                    Height = 1080,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MimeType = "image/jpeg",
                    Name = "example.jpg",
                    Path = "/example.jpg",
                    Size = 12345,
                    Source = "direct",
                    Tags = ["string"],
                    UpdatedAt = null,
                    Url = "https://cdn.autorender.io/example.jpg",
                    Width = 1920,
                },
            ],
            Meta = new()
            {
                HasNext = false,
                HasPrev = false,
                Limit = 20,
                Page = 1,
                Total = 100,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileListResponse
        {
            Files =
            [
                new()
                {
                    ID = "id_abc123",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    FileNo = "file_abc123",
                    FolderName = null,
                    FolderNo = null,
                    Format = "jpg",
                    Height = 1080,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MimeType = "image/jpeg",
                    Name = "example.jpg",
                    Path = "/example.jpg",
                    Size = 12345,
                    Source = "direct",
                    Tags = ["string"],
                    UpdatedAt = null,
                    Url = "https://cdn.autorender.io/example.jpg",
                    Width = 1920,
                },
            ],
            Meta = new()
            {
                HasNext = false,
                HasPrev = false,
                Limit = 20,
                Page = 1,
                Total = 100,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<File> expectedFiles =
        [
            new()
            {
                ID = "id_abc123",
                CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                FileNo = "file_abc123",
                FolderName = null,
                FolderNo = null,
                Format = "jpg",
                Height = 1080,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MimeType = "image/jpeg",
                Name = "example.jpg",
                Path = "/example.jpg",
                Size = 12345,
                Source = "direct",
                Tags = ["string"],
                UpdatedAt = null,
                Url = "https://cdn.autorender.io/example.jpg",
                Width = 1920,
            },
        ];
        Meta expectedMeta = new()
        {
            HasNext = false,
            HasPrev = false,
            Limit = 20,
            Page = 1,
            Total = 100,
        };

        Assert.Equal(expectedFiles.Count, deserialized.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], deserialized.Files[i]);
        }
        Assert.Equal(expectedMeta, deserialized.Meta);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileListResponse
        {
            Files =
            [
                new()
                {
                    ID = "id_abc123",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    FileNo = "file_abc123",
                    FolderName = null,
                    FolderNo = null,
                    Format = "jpg",
                    Height = 1080,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MimeType = "image/jpeg",
                    Name = "example.jpg",
                    Path = "/example.jpg",
                    Size = 12345,
                    Source = "direct",
                    Tags = ["string"],
                    UpdatedAt = null,
                    Url = "https://cdn.autorender.io/example.jpg",
                    Width = 1920,
                },
            ],
            Meta = new()
            {
                HasNext = false,
                HasPrev = false,
                Limit = 20,
                Page = 1,
                Total = 100,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileListResponse
        {
            Files =
            [
                new()
                {
                    ID = "id_abc123",
                    CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
                    FileNo = "file_abc123",
                    FolderName = null,
                    FolderNo = null,
                    Format = "jpg",
                    Height = 1080,
                    Metadata = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    MimeType = "image/jpeg",
                    Name = "example.jpg",
                    Path = "/example.jpg",
                    Size = 12345,
                    Source = "direct",
                    Tags = ["string"],
                    UpdatedAt = null,
                    Url = "https://cdn.autorender.io/example.jpg",
                    Width = 1920,
                },
            ],
            Meta = new()
            {
                HasNext = false,
                HasPrev = false,
                Limit = 20,
                Page = 1,
                Total = 100,
            },
        };

        FileListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new File
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FileNo = "file_abc123",
            FolderName = null,
            FolderNo = "folder_abc123",
            Format = "jpg",
            Height = 1080,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Source = "direct",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
        };

        string expectedID = "id_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedFileNo = "file_abc123";
        string expectedFolderNo = "folder_abc123";
        string expectedFormat = "jpg";
        long expectedHeight = 1080;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMimeType = "image/jpeg";
        string expectedName = "example.jpg";
        string expectedPath = "/example.jpg";
        long expectedSize = 12345;
        string expectedSource = "direct";
        List<string> expectedTags = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedUrl = "https://cdn.autorender.io/example.jpg";
        long expectedWidth = 1920;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFileNo, model.FileNo);
        Assert.Null(model.FolderName);
        Assert.Equal(expectedFolderNo, model.FolderNo);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedHeight, model.Height);
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
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new File
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FileNo = "file_abc123",
            FolderName = null,
            FolderNo = "folder_abc123",
            Format = "jpg",
            Height = 1080,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Source = "direct",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new File
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FileNo = "file_abc123",
            FolderName = null,
            FolderNo = "folder_abc123",
            Format = "jpg",
            Height = 1080,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Source = "direct",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedFileNo = "file_abc123";
        string expectedFolderNo = "folder_abc123";
        string expectedFormat = "jpg";
        long expectedHeight = 1080;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMimeType = "image/jpeg";
        string expectedName = "example.jpg";
        string expectedPath = "/example.jpg";
        long expectedSize = 12345;
        string expectedSource = "direct";
        List<string> expectedTags = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedUrl = "https://cdn.autorender.io/example.jpg";
        long expectedWidth = 1920;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFileNo, deserialized.FileNo);
        Assert.Null(deserialized.FolderName);
        Assert.Equal(expectedFolderNo, deserialized.FolderNo);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedHeight, deserialized.Height);
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
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new File
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FileNo = "file_abc123",
            FolderName = null,
            FolderNo = "folder_abc123",
            Format = "jpg",
            Height = 1080,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Source = "direct",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new File
        {
            ID = "id_abc123",
            CreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            FileNo = "file_abc123",
            FolderName = null,
            FolderNo = "folder_abc123",
            Format = "jpg",
            Height = 1080,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "image/jpeg",
            Name = "example.jpg",
            Path = "/example.jpg",
            Size = 12345,
            Source = "direct",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
            Url = "https://cdn.autorender.io/example.jpg",
            Width = 1920,
        };

        File copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MetaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Meta
        {
            HasNext = false,
            HasPrev = false,
            Limit = 20,
            Page = 1,
            Total = 100,
        };

        bool expectedHasNext = false;
        bool expectedHasPrev = false;
        long expectedLimit = 20;
        long expectedPage = 1;
        long expectedTotal = 100;

        Assert.Equal(expectedHasNext, model.HasNext);
        Assert.Equal(expectedHasPrev, model.HasPrev);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Meta
        {
            HasNext = false,
            HasPrev = false,
            Limit = 20,
            Page = 1,
            Total = 100,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meta>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Meta
        {
            HasNext = false,
            HasPrev = false,
            Limit = 20,
            Page = 1,
            Total = 100,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meta>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedHasNext = false;
        bool expectedHasPrev = false;
        long expectedLimit = 20;
        long expectedPage = 1;
        long expectedTotal = 100;

        Assert.Equal(expectedHasNext, deserialized.HasNext);
        Assert.Equal(expectedHasPrev, deserialized.HasPrev);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Meta
        {
            HasNext = false,
            HasPrev = false,
            Limit = 20,
            Page = 1,
            Total = 100,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Meta
        {
            HasNext = false,
            HasPrev = false,
            Limit = 20,
            Page = 1,
            Total = 100,
        };

        Meta copied = new(model);

        Assert.Equal(model, copied);
    }
}
