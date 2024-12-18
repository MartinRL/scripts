using System;
using System.IO;
using System.Text.RegularExpressions;

var args = Environment.GetCommandLineArgs();

string filePath = null;

for (int i = 0; i < args.Length; i++)
{
    if (args[i] == "-f" && i + 1 < args.Length)
    {
        filePath = args[i + 1];
        break;
    }
}

if (filePath == null)
{
    Console.WriteLine("Please provide the HTML file path using the -f argument.");
    return;
}

if (!File.Exists(filePath))
{
    Console.WriteLine($"File not found: {filePath}");
    return;
}

Console.WriteLine($"Reading file: {filePath}");

string htmlContent = File.ReadAllText(filePath);

string pattern = @"<span class=""airport"" ng-if=""::!vm\.optionsMap\.route"">(.+?)<\/span>";
var matches = Regex.Matches(htmlContent, pattern);

Console.WriteLine($"Number of matches found: {matches.Count}");

if (matches.Count == 0)
{
    Console.WriteLine("No airport elements found.");
    return;
}

var airportNames = matches.Cast<Match>().Select(m => m.Groups[1].Value).OrderBy(name => name);

foreach (var name in airportNames)
{
    Console.WriteLine(name);
}
