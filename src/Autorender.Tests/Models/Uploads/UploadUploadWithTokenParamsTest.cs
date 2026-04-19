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
        BinaryContent body = Encoding.UTF8.GetBytes("Example data");

        var parameters = new UploadUploadWithTokenParams { Token = "token", Body = body };

        string expectedToken = "token";
        BinaryContent expectedBody = body;

        Assert.Equal(expectedToken, parameters.Token);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        UploadUploadWithTokenParams parameters = new()
        {
            Token = "token",
            Body = Encoding.UTF8.GetBytes("Example data"),
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
            Body = Encoding.UTF8.GetBytes("Example data"),
        };

        UploadUploadWithTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
