using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.MultipartUploads;

namespace Autorender.Tests.Models.MultipartUploads;

public class MultipartUploadStartResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MultipartUploadStartResponse
        {
            ExpireAt = 1704067200,
            MinPartSize = 5242880,
            PartSize = 5242880,
            Parts = ["https://s3.amazonaws.com/bucket/part1?signed=true"],
            Policy = new()
            {
                Folder = "/uploads",
                Format = "jpg",
                Size = 104857600,
                Tags = ["string"],
            },
            PublicKey = "pk_abc123",
            SessionID = "sess_abc123",
            Uuid = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            WorkspaceID = "ws_abc123",
        };

        long expectedExpireAt = 1704067200;
        long expectedMinPartSize = 5242880;
        long expectedPartSize = 5242880;
        List<string> expectedParts = ["https://s3.amazonaws.com/bucket/part1?signed=true"];
        Policy expectedPolicy = new()
        {
            Folder = "/uploads",
            Format = "jpg",
            Size = 104857600,
            Tags = ["string"],
        };
        string expectedPublicKey = "pk_abc123";
        string expectedSessionID = "sess_abc123";
        string expectedUuid = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a";
        string expectedWorkspaceID = "ws_abc123";

        Assert.Equal(expectedExpireAt, model.ExpireAt);
        Assert.Equal(expectedMinPartSize, model.MinPartSize);
        Assert.Equal(expectedPartSize, model.PartSize);
        Assert.Equal(expectedParts.Count, model.Parts.Count);
        for (int i = 0; i < expectedParts.Count; i++)
        {
            Assert.Equal(expectedParts[i], model.Parts[i]);
        }
        Assert.Equal(expectedPolicy, model.Policy);
        Assert.Equal(expectedPublicKey, model.PublicKey);
        Assert.Equal(expectedSessionID, model.SessionID);
        Assert.Equal(expectedUuid, model.Uuid);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MultipartUploadStartResponse
        {
            ExpireAt = 1704067200,
            MinPartSize = 5242880,
            PartSize = 5242880,
            Parts = ["https://s3.amazonaws.com/bucket/part1?signed=true"],
            Policy = new()
            {
                Folder = "/uploads",
                Format = "jpg",
                Size = 104857600,
                Tags = ["string"],
            },
            PublicKey = "pk_abc123",
            SessionID = "sess_abc123",
            Uuid = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            WorkspaceID = "ws_abc123",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipartUploadStartResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MultipartUploadStartResponse
        {
            ExpireAt = 1704067200,
            MinPartSize = 5242880,
            PartSize = 5242880,
            Parts = ["https://s3.amazonaws.com/bucket/part1?signed=true"],
            Policy = new()
            {
                Folder = "/uploads",
                Format = "jpg",
                Size = 104857600,
                Tags = ["string"],
            },
            PublicKey = "pk_abc123",
            SessionID = "sess_abc123",
            Uuid = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            WorkspaceID = "ws_abc123",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipartUploadStartResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedExpireAt = 1704067200;
        long expectedMinPartSize = 5242880;
        long expectedPartSize = 5242880;
        List<string> expectedParts = ["https://s3.amazonaws.com/bucket/part1?signed=true"];
        Policy expectedPolicy = new()
        {
            Folder = "/uploads",
            Format = "jpg",
            Size = 104857600,
            Tags = ["string"],
        };
        string expectedPublicKey = "pk_abc123";
        string expectedSessionID = "sess_abc123";
        string expectedUuid = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a";
        string expectedWorkspaceID = "ws_abc123";

        Assert.Equal(expectedExpireAt, deserialized.ExpireAt);
        Assert.Equal(expectedMinPartSize, deserialized.MinPartSize);
        Assert.Equal(expectedPartSize, deserialized.PartSize);
        Assert.Equal(expectedParts.Count, deserialized.Parts.Count);
        for (int i = 0; i < expectedParts.Count; i++)
        {
            Assert.Equal(expectedParts[i], deserialized.Parts[i]);
        }
        Assert.Equal(expectedPolicy, deserialized.Policy);
        Assert.Equal(expectedPublicKey, deserialized.PublicKey);
        Assert.Equal(expectedSessionID, deserialized.SessionID);
        Assert.Equal(expectedUuid, deserialized.Uuid);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MultipartUploadStartResponse
        {
            ExpireAt = 1704067200,
            MinPartSize = 5242880,
            PartSize = 5242880,
            Parts = ["https://s3.amazonaws.com/bucket/part1?signed=true"],
            Policy = new()
            {
                Folder = "/uploads",
                Format = "jpg",
                Size = 104857600,
                Tags = ["string"],
            },
            PublicKey = "pk_abc123",
            SessionID = "sess_abc123",
            Uuid = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            WorkspaceID = "ws_abc123",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MultipartUploadStartResponse
        {
            ExpireAt = 1704067200,
            MinPartSize = 5242880,
            PartSize = 5242880,
            Parts = ["https://s3.amazonaws.com/bucket/part1?signed=true"],
            Policy = new()
            {
                Folder = "/uploads",
                Format = "jpg",
                Size = 104857600,
                Tags = ["string"],
            },
            PublicKey = "pk_abc123",
            SessionID = "sess_abc123",
            Uuid = "3e4666bf-d5e5-4aa7-b8ce-cefe41c7568a",
            WorkspaceID = "ws_abc123",
        };

        MultipartUploadStartResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PolicyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Policy
        {
            Folder = "/uploads",
            Format = "jpg",
            Size = 104857600,
            Tags = ["string"],
        };

        string expectedFolder = "/uploads";
        string expectedFormat = "jpg";
        long expectedSize = 104857600;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFolder, model.Folder);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedSize, model.Size);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Policy
        {
            Folder = "/uploads",
            Format = "jpg",
            Size = 104857600,
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Policy>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Policy
        {
            Folder = "/uploads",
            Format = "jpg",
            Size = 104857600,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Policy>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFolder = "/uploads";
        string expectedFormat = "jpg";
        long expectedSize = 104857600;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedFolder, deserialized.Folder);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedSize, deserialized.Size);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Policy
        {
            Folder = "/uploads",
            Format = "jpg",
            Size = 104857600,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Policy
        {
            Folder = "/uploads",
            Format = "jpg",
            Size = 104857600,
            Tags = ["string"],
        };

        Policy copied = new(model);

        Assert.Equal(model, copied);
    }
}
