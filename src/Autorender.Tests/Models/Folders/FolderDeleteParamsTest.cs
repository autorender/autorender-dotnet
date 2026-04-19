using System;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderDeleteParams { FolderNo = "folderNo" };

        string expectedFolderNo = "folderNo";

        Assert.Equal(expectedFolderNo, parameters.FolderNo);
    }

    [Fact]
    public void Url_Works()
    {
        FolderDeleteParams parameters = new() { FolderNo = "folderNo" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/folders/folderNo"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderDeleteParams { FolderNo = "folderNo" };

        FolderDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
