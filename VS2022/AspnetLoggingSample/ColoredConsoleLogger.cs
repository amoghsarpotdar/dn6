namespace AspnetLoggingSample
{
    public class ColoredConsoleLogger : ILogger
    {
        private static object _lock = new object();
        private readonly string _name;
        private readonly CustomLoggerConfiguration _configuration;

        public ColoredConsoleLogger(string name, CustomLoggerConfiguration configuration)
        {
            _name = name;
            _configuration = configuration;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == LogLevel.Information;
        }

        public void Log<TState>(LogLevel logLevel,EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            lock (_lock)
            {
                if(_configuration.EventId == 0 || _configuration.EventId == eventId.Id)
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = _configuration.Color;
                    Console.Write($"{logLevel} - ");
                    Console.Write($"{eventId.Id} - {_name} - " );
                    Console.Write($"{formatter(state, exception)}\n");
                    Console.ForegroundColor = color;
                }
            }
        }
    }
}
