using System.Threading.Tasks;

namespace Autorender.Tests.Services;

public class FolderServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var folder = await this.client.Folders.Create(
            new() { Name = "demo2" },
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
        var folder = await this.client.Folders.Delete(
            "my8JeLg4tr",
            new(),
            TestContext.Current.CancellationToken
        );
        folder.Validate();
    }

    [Fact]
    public async Task Rename_Works()
    {
        var folder = await this.client.Folders.Rename(
            "53855hxPoq",
            new() { Name = "demo2" },
            TestContext.Current.CancellationToken
        );
        folder.Validate();
    }
}
