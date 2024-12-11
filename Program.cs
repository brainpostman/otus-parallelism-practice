using ParallelPractice;
using System.Diagnostics;
var sw = Stopwatch.StartNew();
var threeFiles = await FileProcessor.CountSpacesInDirectoryFiles("../../../Test");
sw.Stop();
foreach (var file in threeFiles)
{
    Console.WriteLine($"File: {file.Key}; Spaces: {file.Value}");
}
Console.WriteLine($"Elapsed time in ms: {sw.ElapsedMilliseconds}");

sw.Restart();
var buildFiles = await FileProcessor.CountSpacesInDirectoryFiles("./");
sw.Stop();
foreach (var file in buildFiles)
{
    Console.WriteLine($"File: {file.Key}; Spaces: {file.Value}");
}
Console.WriteLine($"Elapsed time in ms: {sw.ElapsedMilliseconds}");
