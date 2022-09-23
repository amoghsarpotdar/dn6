// Original Code - https://stackoverflow.com/questions/69984766/to-global-using-directive-refactoring

/* 
 * File scoped namespaces
 * This type of declaration uses less verbose format for the typical case of
 * files containing only one namespace. The file scoped namespace format is
 * <namespace X.Y.Z;>
 * 
 * Intention behind this change is to reduce the number of lines that are spent
 * in code in following 'rituals' - the repetitive process that can be skipped.
 * Also, using the older namespace statements forces user to indent the code.
 * With new format, you can start from where the IDE begins instead of having
 * to indent the code.
 * Reference : https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces
 * 
*/
using System.Text;

if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
    throw new ArgumentException("You must specify directory");
var directoryForScan = args[0];
if (!Directory.Exists(directoryForScan))
{
    throw new ArgumentException($"{directoryForScan} not exist");
}

var filesEnumeration = Directory.EnumerateFiles(directoryForScan, "*.cs", SearchOption.AllDirectories);
var directorySeparator = Path.DirectorySeparatorChar;
var usingSet = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var filePath in filesEnumeration.Where(it => !it.Contains($"{directorySeparator}bin{directorySeparator}")
                                                  && !it.Contains($"{directorySeparator}obj{directorySeparator}")))
{
    await ProcessUsingAsync(filePath, usingSet);
}

var resultFilePath = Path.Combine(directoryForScan, "GlobalUsings.cs");

await using var resultStream = new FileStream(resultFilePath, FileMode.Create, FileAccess.Write, FileShare.Write);
await using var writer = new StreamWriter(resultStream, Encoding.UTF8);
foreach (var item in usingSet)
{
    Console.WriteLine(item);
    await writer.WriteAsync("global ");
    await writer.WriteLineAsync(item);
}

await resultStream.FlushAsync();

static async Task ProcessUsingAsync(string filePath, ISet<string> usingSet)
{
    await using var fileStream = File.OpenRead(filePath);
    using var reader = new StreamReader(fileStream);
    string? currentLine;
    do
    {
        currentLine = await reader.ReadLineAsync();
        if (currentLine is not null
            && currentLine.StartsWith("using")
            && currentLine.EndsWith(";")
            && !currentLine.Contains(" static ")
            && !currentLine.Contains("="))
        {
            usingSet.Add(currentLine);
        }
    } while (currentLine != null);
}
