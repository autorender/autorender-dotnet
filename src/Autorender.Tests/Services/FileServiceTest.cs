using System.Threading.Tasks;

namespace Autorender.Tests.Services;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var file = await this.client.Files.Retrieve(
            "fileNo",
            new(),
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var file = await this.client.Files.Update(
            "fileNo",
            new(),
            TestContext.Current.CancellationToken
        );
        file.Validate();
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
        await this.client.Files.Delete("fileNo", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Rename_Works()
    {
        var response = await this.client.Files.Rename(
            "fileNo",
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
