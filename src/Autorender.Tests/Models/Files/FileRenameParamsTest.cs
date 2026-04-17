using System;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileRenameParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileRenameParams { FileNo = "2338045312", Name = "demo" };

        string expectedFileNo = "2338045312";
        string expectedName = "demo";

        Assert.Equal(expectedFileNo, parameters.FileNo);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        FileRenameParams parameters = new() { FileNo = "2338045312", Name = "demo" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://upload.autorender.io/api/v1/files/2338045312/rename"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileRenameParams { FileNo = "2338045312", Name = "demo" };

        FileRenameParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
