using System.Web.Http.ExceptionHandling;
using NLog;

namespace UnityPoc.Infrastructure
{
    public class NLogExceptionLogger : ExceptionLogger
    {
        private readonly ILogger _logger;

        public NLogExceptionLogger(ILogger logger)
        {
            _logger = logger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _logger.Log(LogLevel.Error, context.Exception);
        }
    }
}