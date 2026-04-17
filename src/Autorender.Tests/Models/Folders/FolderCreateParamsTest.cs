using System;
using Autorender.Models.Folders;

namespace Autorender.Tests.Models.Folders;

public class FolderCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderCreateParams { Name = "demo2", ParentFolderNo = "sD1LvqoDzG" };

        string expectedName = "demo2";
        string expectedParentFolderNo = "sD1LvqoDzG";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedParentFolderNo, parameters.ParentFolderNo);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FolderCreateParams { Name = "demo2" };

        Assert.Null(parameters.ParentFolderNo);
        Assert.False(parameters.RawBodyData.ContainsKey("parent_folder_no"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FolderCreateParams
        {
            Name = "demo2",

            // Null should be interpreted as omitted for these properties
            ParentFolderNo = null,
        };

        Assert.Null(parameters.ParentFolderNo);
        Assert.False(parameters.RawBodyData.ContainsKey("parent_folder_no"));
    }

    [Fact]
    public void Url_Works()
    {
        FolderCreateParams parameters = new() { Name = "demo2" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/folders"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderCreateParams { Name = "demo2", ParentFolderNo = "sD1LvqoDzG" };

        FolderCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
