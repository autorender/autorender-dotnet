using System.Collections.Generic;
using System.Text.Json;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadGenerateTokenResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "token",
            ExpireAt = -9007199254740991,
            Policy = new()
            {
                AllowOverride = new() { Folder = true, Tags = true },
                Folder = "folder",
                MaxFileSize = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        string expectedToken = "token";
        long expectedExpireAt = -9007199254740991;
        Policy expectedPolicy = new()
        {
            AllowOverride = new() { Folder = true, Tags = true },
            Folder = "folder",
            MaxFileSize = -9007199254740991,
            Tags = ["string"],
        };
        string expectedPublicKey = "public_key";
        string expectedSignature = "signature";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedToken, model.Token);
        Assert.Equal(expectedExpireAt, model.ExpireAt);
        Assert.Equal(expectedPolicy, model.Policy);
        Assert.Equal(expectedPublicKey, model.PublicKey);
        Assert.Equal(expectedSignature, model.Signature);
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "token",
            ExpireAt = -9007199254740991,
            Policy = new()
            {
                AllowOverride = new() { Folder = true, Tags = true },
                Folder = "folder",
                MaxFileSize = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadGenerateTokenResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "token",
            ExpireAt = -9007199254740991,
            Policy = new()
            {
                AllowOverride = new() { Folder = true, Tags = true },
                Folder = "folder",
                MaxFileSize = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UploadGenerateTokenResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToken = "token";
        long expectedExpireAt = -9007199254740991;
        Policy expectedPolicy = new()
        {
            AllowOverride = new() { Folder = true, Tags = true },
            Folder = "folder",
            MaxFileSize = -9007199254740991,
            Tags = ["string"],
        };
        string expectedPublicKey = "public_key";
        string expectedSignature = "signature";
        string expectedWorkspaceID = "workspace_id";

        Assert.Equal(expectedToken, deserialized.Token);
        Assert.Equal(expectedExpireAt, deserialized.ExpireAt);
        Assert.Equal(expectedPolicy, deserialized.Policy);
        Assert.Equal(expectedPublicKey, deserialized.PublicKey);
        Assert.Equal(expectedSignature, deserialized.Signature);
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "token",
            ExpireAt = -9007199254740991,
            Policy = new()
            {
                AllowOverride = new() { Folder = true, Tags = true },
                Folder = "folder",
                MaxFileSize = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UploadGenerateTokenResponse
        {
            Token = "token",
            ExpireAt = -9007199254740991,
            Policy = new()
            {
                AllowOverride = new() { Folder = true, Tags = true },
                Folder = "folder",
                MaxFileSize = -9007199254740991,
                Tags = ["string"],
            },
            PublicKey = "public_key",
            Signature = "signature",
            WorkspaceID = "workspace_id",
        };

        UploadGenerateTokenResponse copied = new(model);

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
            AllowOverride = new() { Folder = true, Tags = true },
            Folder = "folder",
            MaxFileSize = -9007199254740991,
            Tags = ["string"],
        };

        PolicyAllowOverride expectedAllowOverride = new() { Folder = true, Tags = true };
        string expectedFolder = "folder";
        long expectedMaxFileSize = -9007199254740991;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedAllowOverride, model.AllowOverride);
        Assert.Equal(expectedFolder, model.Folder);
        Assert.Equal(expectedMaxFileSize, model.MaxFileSize);
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
            AllowOverride = new() { Folder = true, Tags = true },
            Folder = "folder",
            MaxFileSize = -9007199254740991,
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
            AllowOverride = new() { Folder = true, Tags = true },
            Folder = "folder",
            MaxFileSize = -9007199254740991,
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Policy>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        PolicyAllowOverride expectedAllowOverride = new() { Folder = true, Tags = true };
        string expectedFolder = "folder";
        long expectedMaxFileSize = -9007199254740991;
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedAllowOverride, deserialized.AllowOverride);
        Assert.Equal(expectedFolder, deserialized.Folder);
        Assert.Equal(expectedMaxFileSize, deserialized.MaxFileSize);
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
            AllowOverride = new() { Folder = true, Tags = true },
            Folder = "folder",
            MaxFileSize = -9007199254740991,
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Policy
        {
            AllowOverride = new() { Folder = true, Tags = true },
            Folder = "folder",
            MaxFileSize = -9007199254740991,
            Tags = ["string"],
        };

        Policy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PolicyAllowOverrideTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PolicyAllowOverride { Folder = true, Tags = true };

        bool expectedFolder = true;
        bool expectedTags = true;

        Assert.Equal(expectedFolder, model.Folder);
        Assert.Equal(expectedTags, model.Tags);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PolicyAllowOverride { Folder = true, Tags = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PolicyAllowOverride>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PolicyAllowOverride { Folder = true, Tags = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PolicyAllowOverride>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedFolder = true;
        bool expectedTags = true;

        Assert.Equal(expectedFolder, deserialized.Folder);
        Assert.Equal(expectedTags, deserialized.Tags);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PolicyAllowOverride { Folder = true, Tags = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PolicyAllowOverride { };

        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PolicyAllowOverride { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PolicyAllowOverride
        {
            // Null should be interpreted as omitted for these properties
            Folder = null,
            Tags = null,
        };

        Assert.Null(model.Folder);
        Assert.False(model.RawData.ContainsKey("folder"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PolicyAllowOverride
        {
            // Null should be interpreted as omitted for these properties
            Folder = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PolicyAllowOverride { Folder = true, Tags = true };

        PolicyAllowOverride copied = new(model);

        Assert.Equal(model, copied);
    }
}
