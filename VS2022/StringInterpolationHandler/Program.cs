// Original Source - https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/interpolated-string-handler

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


/*
 C# 10 adds support for a custom interpolated string handler. 
An interpolated string handler is a type that processes the placeholder 
expression in an interpolated string. Without a custom handler, 
placeholders are processed similar to String.Format. Each placeholder 
is formatted as text, and then the components are concatenated to form 
the resulting string.

You can write a handler for any scenario where you use information 
about the resulting string. Will it be used? What constraints are on 
the format? Some examples include:

You may require none of the resulting strings are greater than 
some limit, such as 80 characters. You can process the interpolated 
strings to fill a fixed-length buffer, and stop processing once that 
buffer length is reached.
You may have a tabular format, and each placeholder must have a fixed 
length. A custom handler can enforce that, rather than forcing all client
code to conform.

This project creates a string interpolation handler for one of the core
performance scenarios : logging libraries.

Depending on the configured log leve, the work to construct a log message
isn't needed. If logging is off, the work to construct a string from an
interpolated string expression isn't needed. The message is never printed,
so any string concatenation can be skipped. In addition, any expressions
used in the placeholders, including generating stack traces, doesn't need
to be done.

An interpolated string handler can determine if the formatted string
will be used, and only perform the necessary work if needed.
 */

using StringInterpolationHandler;

var logger = new Logger() { EnabledLevel = LogLevel.Warning };
var time = DateTime.Now;

logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. This is an error. It will be printed.");
logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time}. This won't be printed.");
logger.LogMessage(LogLevel.Warning, "Warning Level. This warning is a string, not an interpolated string expression.");

Console.WriteLine("Done!");
