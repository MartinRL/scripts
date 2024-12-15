#r "nuget: HtmlAgilityPack"

using System;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

if (args.Length == 0)
{
    Console.WriteLine("Please provide the HTML file path as an argument.");
    return;
}

string filePath = args[0];

if (!File.Exists(filePath))
{
    Console.WriteLine($"File not found: {filePath}");
    return;
}

var htmlDoc = new HtmlDocument();
htmlDoc.Load(filePath);

var airportNodes = htmlDoc.DocumentNode.SelectNodes("//span[@class='airport' and @ng-if='::!vm.optionsMap.route']");

if (airportNodes == null || !airportNodes.Any())
{
    Console.WriteLine("No airport elements found.");
    return;
}

foreach (var node in airportNodes)
{
    Console.WriteLine(node.InnerText);
}
