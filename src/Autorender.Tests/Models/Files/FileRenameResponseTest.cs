using System;
using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Exceptions;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileRenameResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileRenameResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FileNo = "file_no",
                FolderName = "folder_name",
                FolderNo = "folder_no",
                Format = "format",
                Height = -9007199254740991,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MimeType = "mime_type",
                Name = "name",
                Path = "path",
                Size = -9007199254740991,
                Source = "source",
                Tags = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "url",
                Width = -9007199254740991,
            },
            Success = FileRenameResponseSuccess.True,
        };

        FileRenameResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileNo = "file_no",
            FolderName = "folder_name",
            FolderNo = "folder_no",
            Format = "format",
            Height = -9007199254740991,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Source = "source",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = -9007199254740991,
        };
        ApiEnum<bool, FileRenameResponseSuccess> expectedSuccess = FileRenameResponseSuccess.True;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedSuccess, model.Success);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileRenameResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FileNo = "file_no",
                FolderName = "folder_name",
                FolderNo = "folder_no",
                Format = "format",
                Height = -9007199254740991,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MimeType = "mime_type",
                Name = "name",
                Path = "path",
                Size = -9007199254740991,
                Source = "source",
                Tags = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "url",
                Width = -9007199254740991,
            },
            Success = FileRenameResponseSuccess.True,
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
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FileNo = "file_no",
                FolderName = "folder_name",
                FolderNo = "folder_no",
                Format = "format",
                Height = -9007199254740991,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MimeType = "mime_type",
                Name = "name",
                Path = "path",
                Size = -9007199254740991,
                Source = "source",
                Tags = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "url",
                Width = -9007199254740991,
            },
            Success = FileRenameResponseSuccess.True,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRenameResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FileRenameResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileNo = "file_no",
            FolderName = "folder_name",
            FolderNo = "folder_no",
            Format = "format",
            Height = -9007199254740991,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Source = "source",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = -9007199254740991,
        };
        ApiEnum<bool, FileRenameResponseSuccess> expectedSuccess = FileRenameResponseSuccess.True;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedSuccess, deserialized.Success);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileRenameResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FileNo = "file_no",
                FolderName = "folder_name",
                FolderNo = "folder_no",
                Format = "format",
                Height = -9007199254740991,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MimeType = "mime_type",
                Name = "name",
                Path = "path",
                Size = -9007199254740991,
                Source = "source",
                Tags = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "url",
                Width = -9007199254740991,
            },
            Success = FileRenameResponseSuccess.True,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileRenameResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FileNo = "file_no",
                FolderName = "folder_name",
                FolderNo = "folder_no",
                Format = "format",
                Height = -9007199254740991,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                MimeType = "mime_type",
                Name = "name",
                Path = "path",
                Size = -9007199254740991,
                Source = "source",
                Tags = ["string"],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "url",
                Width = -9007199254740991,
            },
            Success = FileRenameResponseSuccess.True,
        };

        FileRenameResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileRenameResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileRenameResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileNo = "file_no",
            FolderName = "folder_name",
            FolderNo = "folder_no",
            Format = "format",
            Height = -9007199254740991,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Source = "source",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = -9007199254740991,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFileNo = "file_no";
        string expectedFolderName = "folder_name";
        string expectedFolderNo = "folder_no";
        string expectedFormat = "format";
        long expectedHeight = -9007199254740991;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMimeType = "mime_type";
        string expectedName = "name";
        string expectedPath = "path";
        long expectedSize = -9007199254740991;
        string expectedSource = "source";
        List<string> expectedTags = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "url";
        long expectedWidth = -9007199254740991;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFileNo, model.FileNo);
        Assert.Equal(expectedFolderName, model.FolderName);
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
        var model = new FileRenameResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileNo = "file_no",
            FolderName = "folder_name",
            FolderNo = "folder_no",
            Format = "format",
            Height = -9007199254740991,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Source = "source",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = -9007199254740991,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRenameResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileRenameResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileNo = "file_no",
            FolderName = "folder_name",
            FolderNo = "folder_no",
            Format = "format",
            Height = -9007199254740991,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Source = "source",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = -9007199254740991,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileRenameResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFileNo = "file_no";
        string expectedFolderName = "folder_name";
        string expectedFolderNo = "folder_no";
        string expectedFormat = "format";
        long expectedHeight = -9007199254740991;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMimeType = "mime_type";
        string expectedName = "name";
        string expectedPath = "path";
        long expectedSize = -9007199254740991;
        string expectedSource = "source";
        List<string> expectedTags = ["string"];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "url";
        long expectedWidth = -9007199254740991;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFileNo, deserialized.FileNo);
        Assert.Equal(expectedFolderName, deserialized.FolderName);
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
        var model = new FileRenameResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileNo = "file_no",
            FolderName = "folder_name",
            FolderNo = "folder_no",
            Format = "format",
            Height = -9007199254740991,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Source = "source",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = -9007199254740991,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileRenameResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileNo = "file_no",
            FolderName = "folder_name",
            FolderNo = "folder_no",
            Format = "format",
            Height = -9007199254740991,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            MimeType = "mime_type",
            Name = "name",
            Path = "path",
            Size = -9007199254740991,
            Source = "source",
            Tags = ["string"],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "url",
            Width = -9007199254740991,
        };

        FileRenameResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileRenameResponseSuccessTest : TestBase
{
    [Theory]
    [InlineData(FileRenameResponseSuccess.True)]
    public void Validation_Works(FileRenameResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, FileRenameResponseSuccess> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, FileRenameResponseSuccess>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AutorenderInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FileRenameResponseSuccess.True)]
    public void SerializationRoundtrip_Works(FileRenameResponseSuccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, FileRenameResponseSuccess> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, FileRenameResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, FileRenameResponseSuccess>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, FileRenameResponseSuccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
