using System.Threading.Tasks;

namespace Autorender.Tests.Services;

public class MultipartUploadServiceTest : TestBase
{
    [Fact]
    public async Task Complete_Works()
    {
        var response = await this.client.MultipartUploads.Complete(
            new() { SessionID = "x" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Start_Works()
    {
        var response = await this.client.MultipartUploads.Start(
            new()
            {
                FileName = "x",
                Format = "x",
                Size = 1,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
