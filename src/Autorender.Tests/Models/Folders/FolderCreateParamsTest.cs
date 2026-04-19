using System;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderCreateParams { FolderName = "folder_name", Path = "path" };

        string expectedFolderName = "folder_name";
        string expectedPath = "path";

        Assert.Equal(expectedFolderName, parameters.FolderName);
        Assert.Equal(expectedPath, parameters.Path);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FolderCreateParams { FolderName = "folder_name" };

        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FolderCreateParams
        {
            FolderName = "folder_name",

            // Null should be interpreted as omitted for these properties
            Path = null,
        };

        Assert.Null(parameters.Path);
        Assert.False(parameters.RawBodyData.ContainsKey("path"));
    }

    [Fact]
    public void Url_Works()
    {
        FolderCreateParams parameters = new() { FolderName = "folder_name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/folders"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderCreateParams { FolderName = "folder_name", Path = "path" };

        FolderCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
