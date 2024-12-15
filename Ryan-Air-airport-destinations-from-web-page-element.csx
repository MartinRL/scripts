using System;
using System.IO;
using System.Text.RegularExpressions;

var args = Environment.GetCommandLineArgs();

if (args.Length < 2)
{
    Console.WriteLine("Please provide the HTML file path as an argument.");
    return;
}

string filePath = args[1];

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

foreach (Match match in matches)
{
    Console.WriteLine(match.Groups[1].Value);
}