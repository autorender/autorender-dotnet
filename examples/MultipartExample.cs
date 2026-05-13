using System;
using System.Net.Http;
using System.Threading.Tasks;
using Autorender;
using Autorender.Models.Files;
using Autorender.Models.MultipartUploads;

public class MultipartExample
{
    public static async Task Main(string[] args = default!)
    {
        var client = new AutorenderClient
        {
            BaseUrl = Environment.GetEnvironmentVariable("AUTORENDER_BASE_URL") ?? "https://upload.autorender.io",
            ApiKey = Environment.GetEnvironmentVariable("AUTORENDER_API_KEY"),
        };

        // Fetch test image
        Console.WriteLine("--- Fetching test file ---");
        using var http = new HttpClient();
        var fileBytes = await http.GetByteArrayAsync("https://www.w3.org/WAI/WCAG21/Techniques/pdf/img/table-word.jpg");
        Console.WriteLine($"  size : {fileBytes.Length} bytes");

        // Start multipart session
        Console.WriteLine("\n--- Starting multipart session ---");
        var session = await client.MultipartUploads.Start(new MultipartUploadStartParams
        {
            FileName = "multipart-test.jpg",
            Size = fileBytes.Length,
            Format = "jpg",
        });
        Console.WriteLine($"  session_id : {session.SessionID}");
        Console.WriteLine($"  parts      : {session.Parts.Count}");
        Console.WriteLine($"  part_size  : {session.PartSize}");

        // Upload parts via pre-signed URLs
        Console.WriteLine("\n--- Uploading parts ---");
        var parts = session.Parts;
        for (int i = 0; i < parts.Count; i++)
        {
            int start = (int)(i * session.PartSize);
            int length = (int)Math.Min(session.PartSize, fileBytes.Length - start);
            var chunk = new ReadOnlyMemory<byte>(fileBytes, start, length);

            using var req = new HttpRequestMessage(HttpMethod.Put, parts[i]);
            req.Content = new ByteArrayContent(chunk.ToArray());
            req.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
            var resp = await http.SendAsync(req);
            resp.EnsureSuccessStatusCode();
            Console.WriteLine($"  part {i + 1}/{parts.Count} uploaded");
        }

        // Complete
        Console.WriteLine("\n--- Completing multipart upload ---");
        var result = await client.MultipartUploads.Complete(new MultipartUploadCompleteParams
        {
            SessionID = session.SessionID,
        });
        Console.WriteLine($"  file_no : {result.FileNo}");
        Console.WriteLine($"  name    : {result.Name}");
        Console.WriteLine($"  size    : {result.Size} bytes");

        // Clean up
        Console.WriteLine("\n--- Deleting uploaded file ---");
        await client.Files.Delete(new FileDeleteParams { FileNo = result.FileNo });
        Console.WriteLine("  Deleted");
    }
}
