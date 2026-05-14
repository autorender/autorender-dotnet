using System.Threading.Tasks;

namespace Autorender.Tests.Services;

public class FolderServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var folder = await this.client.Folders.Create(
            new() { Name = "x" },
            TestContext.Current.CancellationToken
        );
        folder.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var folders = await this.client.Folders.List(new(), TestContext.Current.CancellationToken);
        folders.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Folders.Delete("folderNo", new(), TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task Rename_Works()
    {
        var response = await this.client.Folders.Rename(
            "folderNo",
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
