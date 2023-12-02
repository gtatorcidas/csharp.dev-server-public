using Microsoft.Extensions.Logging;

using Torcidas.Application.Services.Interfaces;

namespace Torcidas.Application.Services
{
    public class LoggerService : ILoggerService
    {

        #region Properties
        private readonly ILogger<LoggerService> _logger;
        #endregion

        #region Constructor

        public LoggerService(ILogger<LoggerService> logger)
        {
           _logger = logger;
        }

        #endregion

        public void LogParciais(string message)
        {
            _logger.LogInformation("{@LogType} - {Message}", "[Parciais]", message);
        }

        public void LogCadastros(string prefix, string message)
        {
            _logger.LogInformation("{@LogType} {@LogPrefixCadastros} - {Message}", "[Cadastros]", prefix, message);
        }
    }
}
