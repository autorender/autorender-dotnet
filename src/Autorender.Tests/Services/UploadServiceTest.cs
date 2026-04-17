using System.Text;
using System.Threading.Tasks;

namespace Autorender.Tests.Services;

public class UploadServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var upload = await this.client.Uploads.Create(
            new() { File = Encoding.UTF8.GetBytes("Example data"), FileName = "file_name" },
            TestContext.Current.CancellationToken
        );
        upload.Validate();
    }
}
