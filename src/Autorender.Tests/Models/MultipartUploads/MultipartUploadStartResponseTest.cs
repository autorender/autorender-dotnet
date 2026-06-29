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
            ExpireAt = -9007199254740991,
            MinPartSize = -9007199254740991,
            PartSize = -9007199254740991,
            Parts = ["string"],
            Policy = new()
            {
                Folder = "folder",
                Format = "format",
                Size = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            SessionID = "session_id",
            Uuid = "uuid",
            WorkspaceID = "workspace_id",
        };

        long expectedExpireAt = -9007199254740991;
        long expectedMinPartSize = -9007199254740991;
        long expectedPartSize = -9007199254740991;
        List<string> expectedParts = ["string"];
        Policy expectedPolicy = new()
        {
            Folder = "folder",
            Format = "format",
            Size = -9007199254740991,
            Tags = ["string"],
        };
        string expectedPublicKey = "public_key";
        string expectedSessionID = "session_id";
        string expectedUuid = "uuid";
        string expectedWorkspaceID = "workspace_id";

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
            ExpireAt = -9007199254740991,
            MinPartSize = -9007199254740991,
            PartSize = -9007199254740991,
            Parts = ["string"],
            Policy = new()
            {
                Folder = "folder",
                Format = "format",
                Size = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            SessionID = "session_id",
            Uuid = "uuid",
            WorkspaceID = "workspace_id",
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
            ExpireAt = -9007199254740991,
            MinPartSize = -9007199254740991,
            PartSize = -9007199254740991,
            Parts = ["string"],
            Policy = new()
            {
                Folder = "folder",
                Format = "format",
                Size = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            SessionID = "session_id",
            Uuid = "uuid",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultipartUploadStartResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedExpireAt = -9007199254740991;
        long expectedMinPartSize = -9007199254740991;
        long expectedPartSize = -9007199254740991;
        List<string> expectedParts = ["string"];
        Policy expectedPolicy = new()
        {
            Folder = "folder",
            Format = "format",
            Size = -9007199254740991,
            Tags = ["string"],
        };
        string expectedPublicKey = "public_key";
        string expectedSessionID = "session_id";
        string expectedUuid = "uuid";
        string expectedWorkspaceID = "workspace_id";

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
            ExpireAt = -9007199254740991,
            MinPartSize = -9007199254740991,
            PartSize = -9007199254740991,
            Parts = ["string"],
            Policy = new()
            {
                Folder = "folder",
                Format = "format",
                Size = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            SessionID = "session_id",
            Uuid = "uuid",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MultipartUploadStartResponse
        {
            ExpireAt = -9007199254740991,
            MinPartSize = -9007199254740991,
            PartSize = -9007199254740991,
            Parts = ["string"],
            Policy = new()
            {
                Folder = "folder",
                Format = "format",
                Size = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            SessionID = "session_id",
            Uuid = "uuid",
            WorkspaceID = "workspace_id",
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
            Folder = "folder",
            Format = "format",
            Size = -9007199254740991,
            Tags = ["string"],
        };

        string expectedFolder = "folder";
        string expectedFormat = "format";
        long expectedSize = -9007199254740991;
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
            Folder = "folder",
            Format = "format",
            Size = -9007199254740991,
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
            Folder = "folder",
            Format = "format",
            Size = -9007199254740991,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Policy>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFolder = "folder";
        string expectedFormat = "format";
        long expectedSize = -9007199254740991;
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
            Folder = "folder",
            Format = "format",
            Size = -9007199254740991,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Policy
        {
            Folder = "folder",
            Format = "format",
            Size = -9007199254740991,
            Tags = ["string"],
        };

        Policy copied = new(model);

        Assert.Equal(model, copied);
    }
}
