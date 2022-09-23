using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StringInterpolationHandler
{
    public enum LogLevel
    {
        off,
        Critical,
        Error,
        Warning,
        Information,
        Trace
    }

    /// <summary>
    /// This is the handler implementation.
    /// The builder creates a formatted string, and provides a member for the
    /// client to retrieve that string.
    /// </summary>
    [InterpolatedStringHandler]
    public ref struct LogInterpolatedStringHandler
    {
        // Storage for the built-up string
        StringBuilder builder;

        public LogInterpolatedStringHandler(int literalLength, int formattedCount)
        {
            builder = new StringBuilder(literalLength);
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
        }

        public void AppendLiteral(string s)
        {
            Console.WriteLine($"\tAppendLiteral called: {{{s}}}");

            builder.Append(s);
            Console.WriteLine($"\tAppended the literal string");
        }

        public void AppendFormatted<T>(T t)
        {
            Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");

            builder.Append(t?.ToString());
            Console.WriteLine($"\tAppended the formatted object");
        }

        internal string GetFormattedText() => builder.ToString();
    }

    internal class Logger
    {
        public LogLevel EnabledLevel { get; init; } = LogLevel.Error;

        /// <summary>
        /// This logger method supports six different levels. When the message
        /// wont pass the log level filter, no output is generated.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="msg"></param>
        public void LogMessage(LogLevel level, string msg)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(msg);
        }

        public void LogMessage(LogLevel level, LogInterpolatedStringHandler builder)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(builder.GetFormattedText());
        }
    }
}
