using System.Text;
using System.Threading.Tasks;

namespace Autorender.Tests.Services;

public class UploadServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var upload = await this.client.Uploads.Create(
            new() { File = Encoding.UTF8.GetBytes("Example data"), FileName = "product.jpg" },
            TestContext.Current.CancellationToken
        );
        upload.Validate();
    }

    [Fact]
    public async Task CreateFromUrl_Works()
    {
        var response = await this.client.Uploads.CreateFromUrl(
            new() { RemoteUrl = "https://example.com" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
