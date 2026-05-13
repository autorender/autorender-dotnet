using System;
using System.Threading.Tasks;
using Autorender;
using Autorender.Models.Folders;

public class FoldersExample
{
    public static async Task Main(string[] args = default!)
    {
        var client = new AutorenderClient
        {
            BaseUrl = Environment.GetEnvironmentVariable("AUTORENDER_BASE_URL") ?? "https://upload.autorender.io",
            ApiKey = Environment.GetEnvironmentVariable("AUTORENDER_API_KEY"),
        };

        // List existing folders
        Console.WriteLine("--- Listing folders ---");
        var list = await client.Folders.List(new());
        Console.WriteLine($"  count : {list.Folders.Count}");
        foreach (var f in list.Folders)
            Console.WriteLine($"  {f.FolderNo}  {f.Name}  {f.Path}");

        // Create root folder
        Console.WriteLine("\n--- Creating root folder ---");
        var root = await client.Folders.Create(new FolderCreateParams { Name = "sdk-test-root" });
        root.Validate();
        Console.WriteLine($"  folder_no : {root.FolderNo}");
        Console.WriteLine($"  name      : {root.Name}");
        Console.WriteLine($"  path      : {root.Path}");

        // Create child folder
        Console.WriteLine("\n--- Creating child folder ---");
        var child = await client.Folders.Create(new FolderCreateParams
        {
            Name = "sdk-test-child",
            ParentFolderNo = root.FolderNo,
        });
        child.Validate();
        Console.WriteLine($"  folder_no : {child.FolderNo}");
        Console.WriteLine($"  path      : {child.Path}");

        // Rename root folder
        Console.WriteLine("\n--- Renaming root folder ---");
        var renamed = await client.Folders.Rename(root.FolderNo, new FolderRenameParams { Name = $"sdk-renamed-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}" });
        renamed.Validate();
        Console.WriteLine($"  new name : {renamed.Name}");

        // Delete child then root
        Console.WriteLine("\n--- Deleting folders ---");
        await client.Folders.Delete(child.FolderNo);
        Console.WriteLine($"  Deleted child: {child.FolderNo}");
        await client.Folders.Delete(root.FolderNo);
        Console.WriteLine($"  Deleted root:  {root.FolderNo}");
    }
}
