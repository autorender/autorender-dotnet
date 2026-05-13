using System;
using System.Text;
using System.Threading.Tasks;
using Autorender;
using Autorender.Models.Files;
using Autorender.Models.Uploads;

public class FilesExample
{
    public static async Task Main(string[] args = default!)
    {
        var client = new AutorenderClient
        {
            BaseUrl = Environment.GetEnvironmentVariable("AUTORENDER_BASE_URL") ?? "https://upload.autorender.io",
            ApiKey = Environment.GetEnvironmentVariable("AUTORENDER_API_KEY"),
        };

        // Upload
        Console.WriteLine("--- Uploading test file ---");
        var content = Encoding.UTF8.GetBytes("Hello from the Autorender Stainless C# SDK!");
        var upload = await client.Uploads.Create(new UploadCreateParams
        {
            File = content,
            FileName = "sdk-example.txt",
        });
        var fileNo = upload.FileNo;
        Console.WriteLine($"  file_no : {fileNo}");
        Console.WriteLine($"  url     : {upload.Url}");
        Console.WriteLine($"  size    : {upload.Size} bytes");

        // List
        Console.WriteLine("\n--- Listing files (page 1) ---");
        var list = await client.Files.List(new());
        Console.WriteLine($"  count      : {list.Files.Count}");
        Console.WriteLine($"  has_next   : {list.Meta.HasNext}");
        Console.WriteLine($"  total      : {list.Meta.Total}");
        foreach (var f in list.Files)
            Console.WriteLine($"  {f.FileNo}  {f.Name}  ({f.Size} bytes)");

        // Retrieve
        Console.WriteLine("\n--- Retrieving file ---");
        var retrieved = await client.Files.Retrieve(fileNo, new());
        Console.WriteLine($"  name    : {retrieved.Data.Name}");
        Console.WriteLine($"  mime    : {retrieved.Data.MimeType}");
        Console.WriteLine($"  size    : {retrieved.Data.Size} bytes");

        // Rename
        Console.WriteLine("\n--- Renaming file ---");
        var renamed = await client.Files.Rename(fileNo, new FileRenameParams { Name = $"sdk-renamed-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}" });
        Console.WriteLine($"  new name : {renamed.Data.Name}");

        // Delete
        Console.WriteLine("\n--- Deleting file ---");
        await client.Files.Delete(new FileDeleteParams { FileNo = fileNo });
        Console.WriteLine("  Deleted");

        // Upload from remote URL
        Console.WriteLine("\n--- Uploading from remote URL ---");
        var remote = await client.Uploads.CreateFromUrl(new UploadCreateFromUrlParams
        {
            RemoteUrl = "https://www.w3.org/WAI/WCAG21/Techniques/pdf/img/table-word.jpg",
        });
        Console.WriteLine($"  file_no : {remote.FileNo}");
        Console.WriteLine($"  size    : {remote.Size} bytes");
        await client.Files.Delete(new FileDeleteParams { FileNo = remote.FileNo });
        Console.WriteLine("  Deleted");
    }
}
