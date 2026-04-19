using System;
using Autorender.Models.Files;

namespace Autorender.Tests.Models.Files;

public class FileDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileDeleteParams { FileNo = "fileNo" };

        string expectedFileNo = "fileNo";

        Assert.Equal(expectedFileNo, parameters.FileNo);
    }

    [Fact]
    public void Url_Works()
    {
        FileDeleteParams parameters = new() { FileNo = "fileNo" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/files/fileNo"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileDeleteParams { FileNo = "fileNo" };

        FileDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
