using System.Threading.Tasks;

namespace Autorender.Tests.Services;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var fileObject = await this.client.Files.Retrieve(
            "2353377462",
            new(),
            TestContext.Current.CancellationToken
        );
        fileObject.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var files = await this.client.Files.List(new(), TestContext.Current.CancellationToken);
        files.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        var file = await this.client.Files.Delete(
            "2338056701",
            new(),
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact]
    public async Task Rename_Works()
    {
        var response = await this.client.Files.Rename(
            "2338045312",
            new() { Name = "demo" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
