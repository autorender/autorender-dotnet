var example = args.Length > 0 ? args[0] : "FilesExample";
switch (example)
{
    case "FilesExample":
        await FilesExample.Main(args[1..]);
        break;
    case "FoldersExample":
        await FoldersExample.Main(args[1..]);
        break;
    case "MultipartExample":
        await MultipartExample.Main(args[1..]);
        break;
    default:
        Console.Error.WriteLine($"Unknown example: {example}");
        Console.Error.WriteLine("Usage: dotnet run -- [FilesExample|FoldersExample]");
        Environment.Exit(1);
        break;
}
