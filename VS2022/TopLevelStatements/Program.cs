// See https://aka.ms/new-console-template for more information

//using Microsoft.NET.Sdk;
//using Microsoft.NET.Sdk.Web;
//using Microsoft.NET.Sdk.Worker;

/*
 * Top-level statements help you avoid unwanted rituals like Program class
 * and the main method etc. The itention is to simplify creating quick code
 * snippets. You can begin with sticking the code in to initial template
 * and then proceed to refactor as you go on.
 * 
 */


using TopLevelStatements;
Console.WriteLine();
foreach (var s in args)
{
    Console.Write(s);
    Console.Write(' ');
}
Console.WriteLine();
await Utilities.ShowConsoleAnimation();

string[] answers =
{
    "It is certain.",       "Reply hazy, try again.",     "Don’t count on it.",
    "It is decidedly so.",  "Ask again later.",           "My reply is no.",
    "Without a doubt.",     "Better not tell you now.",   "My sources say no.",
    "Yes – definitely.",    "Cannot predict now.",        "Outlook not so good.",
    "You may rely on it.",  "Concentrate and ask again.", "Very doubtful.",
    "As I see it, yes.",
    "Most likely.",
    "Outlook good.",
    "Yes.",
    "Signs point to yes.",
};

var index = new Random().Next(answers.Length - 1);
Console.WriteLine(answers[index]);
