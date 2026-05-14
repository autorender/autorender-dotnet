using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Exceptions;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileRetrieveResponse
        {
            Data = new()
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
            Success = Success.True,
        };

        Data expectedData = new()
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
        };
        ApiEnum<bool, Success> expectedSuccess = Success.True;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileRetrieveResponse
        {
            Data = new()
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
            Success = Success.True,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileRetrieveResponse
        {
            Data = new()
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
            Success = Success.True,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
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
        };
        ApiEnum<bool, Success> expectedSuccess = Success.True;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileRetrieveResponse
        {
            Data = new()
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
            Success = Success.True,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileRetrieveResponse
        {
            Data = new()
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
            Success = Success.True,
        };

        FileRetrieveResponse copied = new(model);

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
        };

        string expectedID = "id_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedFileNo = "file_abc123";
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
        string expectedUrl = "https://cdn.autorender.io/example.jpg";
        long expectedWidth = 1920;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFileNo, model.FileNo);
        Assert.Null(model.FolderName);
        Assert.Null(model.FolderNo);
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
        Assert.Null(model.UpdatedAt);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id_abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-01-01T00:00:00Z");
        string expectedFileNo = "file_abc123";
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
        string expectedUrl = "https://cdn.autorender.io/example.jpg";
        long expectedWidth = 1920;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFileNo, deserialized.FileNo);
        Assert.Null(deserialized.FolderName);
        Assert.Null(deserialized.FolderNo);
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
        Assert.Null(deserialized.UpdatedAt);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
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
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SuccessTest : TestBase
{
    [Theory]
    [InlineData(Success.True)]
    public void Validation_Works(Success rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, Success> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AutorenderInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Success.True)]
    public void SerializationRoundtrip_Works(Success rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, Success> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, Success>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
