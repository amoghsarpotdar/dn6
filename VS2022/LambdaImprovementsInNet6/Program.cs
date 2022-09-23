// See https://aka.ms/new-console-template for more information
using LambdaImprovementsInNet6;

Console.WriteLine("Hello, World!");

Func<string, int> parse = [ExampleAttribute("TestParam")] (s) => int.Parse(s);


var result = parse("55");

Console.WriteLine(result.ToString());
Console.ReadKey();
