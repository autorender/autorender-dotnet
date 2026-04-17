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
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Extension = "extension",
                    FileNo = "file_no",
                    FileSize = 0,
                    Format = "format",
                    Height = 0,
                    Name = "name",
                    Path = "path",
                    Thumbanil = "thumbanil",
                    Url = "https://example.com",
                    Width = 0,
                    WorkspaceNo = "workspace_no",
                },
            ],
            Meta = new()
            {
                HasNext = true,
                HasPrev = true,
                Limit = 0,
                Page = 0,
                Total = 0,
            },
        };

        List<FileListItem> expectedFiles =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Extension = "extension",
                FileNo = "file_no",
                FileSize = 0,
                Format = "format",
                Height = 0,
                Name = "name",
                Path = "path",
                Thumbanil = "thumbanil",
                Url = "https://example.com",
                Width = 0,
                WorkspaceNo = "workspace_no",
            },
        ];
        Meta expectedMeta = new()
        {
            HasNext = true,
            HasPrev = true,
            Limit = 0,
            Page = 0,
            Total = 0,
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
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Extension = "extension",
                    FileNo = "file_no",
                    FileSize = 0,
                    Format = "format",
                    Height = 0,
                    Name = "name",
                    Path = "path",
                    Thumbanil = "thumbanil",
                    Url = "https://example.com",
                    Width = 0,
                    WorkspaceNo = "workspace_no",
                },
            ],
            Meta = new()
            {
                HasNext = true,
                HasPrev = true,
                Limit = 0,
                Page = 0,
                Total = 0,
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
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Extension = "extension",
                    FileNo = "file_no",
                    FileSize = 0,
                    Format = "format",
                    Height = 0,
                    Name = "name",
                    Path = "path",
                    Thumbanil = "thumbanil",
                    Url = "https://example.com",
                    Width = 0,
                    WorkspaceNo = "workspace_no",
                },
            ],
            Meta = new()
            {
                HasNext = true,
                HasPrev = true,
                Limit = 0,
                Page = 0,
                Total = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FileListItem> expectedFiles =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Extension = "extension",
                FileNo = "file_no",
                FileSize = 0,
                Format = "format",
                Height = 0,
                Name = "name",
                Path = "path",
                Thumbanil = "thumbanil",
                Url = "https://example.com",
                Width = 0,
                WorkspaceNo = "workspace_no",
            },
        ];
        Meta expectedMeta = new()
        {
            HasNext = true,
            HasPrev = true,
            Limit = 0,
            Page = 0,
            Total = 0,
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
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Extension = "extension",
                    FileNo = "file_no",
                    FileSize = 0,
                    Format = "format",
                    Height = 0,
                    Name = "name",
                    Path = "path",
                    Thumbanil = "thumbanil",
                    Url = "https://example.com",
                    Width = 0,
                    WorkspaceNo = "workspace_no",
                },
            ],
            Meta = new()
            {
                HasNext = true,
                HasPrev = true,
                Limit = 0,
                Page = 0,
                Total = 0,
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
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Extension = "extension",
                    FileNo = "file_no",
                    FileSize = 0,
                    Format = "format",
                    Height = 0,
                    Name = "name",
                    Path = "path",
                    Thumbanil = "thumbanil",
                    Url = "https://example.com",
                    Width = 0,
                    WorkspaceNo = "workspace_no",
                },
            ],
            Meta = new()
            {
                HasNext = true,
                HasPrev = true,
                Limit = 0,
                Page = 0,
                Total = 0,
            },
        };

        FileListResponse copied = new(model);

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
            HasNext = true,
            HasPrev = true,
            Limit = 0,
            Page = 0,
            Total = 0,
        };

        bool expectedHasNext = true;
        bool expectedHasPrev = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotal = 0;

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
            HasNext = true,
            HasPrev = true,
            Limit = 0,
            Page = 0,
            Total = 0,
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
            HasNext = true,
            HasPrev = true,
            Limit = 0,
            Page = 0,
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Meta>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedHasNext = true;
        bool expectedHasPrev = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedTotal = 0;

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
            HasNext = true,
            HasPrev = true,
            Limit = 0,
            Page = 0,
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Meta
        {
            HasNext = true,
            HasPrev = true,
            Limit = 0,
            Page = 0,
            Total = 0,
        };

        Meta copied = new(model);

        Assert.Equal(model, copied);
    }
}
