using System;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderRenameParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderRenameParams { FolderNo = "folderNo", Name = "name" };

        string expectedFolderNo = "folderNo";
        string expectedName = "name";

        Assert.Equal(expectedFolderNo, parameters.FolderNo);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        FolderRenameParams parameters = new() { FolderNo = "folderNo", Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://upload.autorender.io/api/v1/folders/rename/folderNo"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderRenameParams { FolderNo = "folderNo", Name = "name" };

        FolderRenameParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
