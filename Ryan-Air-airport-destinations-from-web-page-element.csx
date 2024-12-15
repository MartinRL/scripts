#r "nuget: HtmlAgilityPack"

using System;
using System.IO;
using HtmlAgilityPack;

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

var htmlDoc = new HtmlDocument();
htmlDoc.Load(filePath);

var airportNodes = htmlDoc.DocumentNode.SelectNodes("//span[@class='airport' and @ng-if='::!vm.optionsMap.route']");

if (airportNodes == null || airportNodes.Count == 0)
{
    Console.WriteLine("No airport elements found.");
    return;
}

foreach (var node in airportNodes)
{
    Console.WriteLine(node.InnerText);
}
