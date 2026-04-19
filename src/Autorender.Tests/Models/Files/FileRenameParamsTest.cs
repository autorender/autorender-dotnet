using System;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileRenameParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileRenameParams { FileNo = "fileNo", Name = "name" };

        string expectedFileNo = "fileNo";
        string expectedName = "name";

        Assert.Equal(expectedFileNo, parameters.FileNo);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        FileRenameParams parameters = new() { FileNo = "fileNo", Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://upload.autorender.io/api/v1/files/fileNo/rename"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileRenameParams { FileNo = "fileNo", Name = "name" };

        FileRenameParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
