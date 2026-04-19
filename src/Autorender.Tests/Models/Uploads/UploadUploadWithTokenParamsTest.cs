using System;
using System.Text;
using Autorender.Core;
using Autorender.Models.Uploads;

namespace Autorender.Tests.Models.Uploads;

public class UploadUploadWithTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new UploadUploadWithTokenParams { Token = "token", File = file };

        string expectedToken = "token";
        BinaryContent expectedFile = file;

        Assert.Equal(expectedToken, parameters.Token);
        Assert.Equal(expectedFile, parameters.File);
    }

    [Fact]
    public void Url_Works()
    {
        UploadUploadWithTokenParams parameters = new()
        {
            Token = "token",
            File = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://upload.autorender.io/api/v1/uploads/token"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UploadUploadWithTokenParams
        {
            Token = "token",
            File = Encoding.UTF8.GetBytes("Example data"),
        };

        UploadUploadWithTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
