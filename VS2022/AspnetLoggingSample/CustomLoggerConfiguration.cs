namespace AspnetLoggingSample
{
    public class CustomLoggerConfiguration
    {
        /// <summary>
        /// LogLevel enum defines different type of log levels. It can be
        /// Trace, Debug, Warning, Information, Error or Critical.
        /// If you right click on it and pull up the definition, it will
        /// navigate to Microsoft.Extensions.Logging namespace.
        /// Depending on purpose of information being logged, appropriate log
        /// level can be assigned with every logged message.
        /// </summary>
        public LogLevel LogLevel { get; set; }
        public int EventId { get; set; } = 0;
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
    }
}
