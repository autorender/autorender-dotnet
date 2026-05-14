using System;
using Autorender.Models.MultipartUploads;

namespace Autorender.Tests.Models.MultipartUploads;

public class MultipartUploadCompleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MultipartUploadCompleteParams { SessionID = "x", Uuid = "uuid" };

        string expectedSessionID = "x";
        string expectedUuid = "uuid";

        Assert.Equal(expectedSessionID, parameters.SessionID);
        Assert.Equal(expectedUuid, parameters.Uuid);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MultipartUploadCompleteParams { SessionID = "x" };

        Assert.Null(parameters.Uuid);
        Assert.False(parameters.RawBodyData.ContainsKey("uuid"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MultipartUploadCompleteParams
        {
            SessionID = "x",

            // Null should be interpreted as omitted for these properties
            Uuid = null,
        };

        Assert.Null(parameters.Uuid);
        Assert.False(parameters.RawBodyData.ContainsKey("uuid"));
    }

    [Fact]
    public void Url_Works()
    {
        MultipartUploadCompleteParams parameters = new() { SessionID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://upload.autorender.io/api/v1/multipart/complete"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MultipartUploadCompleteParams { SessionID = "x", Uuid = "uuid" };

        MultipartUploadCompleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
