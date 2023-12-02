using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Torcidas.Application
{
    public class AppLoggerManager
    {
        public static void Configure(IServiceCollection services)
        {
            static bool VerifyParciaisFilter(LogEvent evt) => evt.Properties.ContainsKey("LogType") && evt.Properties["LogType"].ToString().Contains("[Parciais]");
            static bool VerifyCadastrosFilter(LogEvent evt) => evt.Properties.ContainsKey("LogType") && evt.Properties["LogType"].ToString().Contains("[Cadastros]");

            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Logger(req => req
                    .Filter.ByExcluding(VerifyParciaisFilter)
                    .Filter.ByExcluding(VerifyCadastrosFilter)
                    .WriteTo.Async(configAsync => configAsync.File("logs/log.txt", rollingInterval: RollingInterval.Day))
                )
                .WriteTo.Logger(config => config
                     .Filter.ByExcluding(VerifyCadastrosFilter)
                     .Filter.ByIncludingOnly(VerifyParciaisFilter)
                     .WriteTo.Async(configAsync => configAsync.File("logs/torcidas/parciais.txt", rollingInterval: RollingInterval.Day))
                )
                .WriteTo.Logger(config => config
                     .Filter.ByExcluding(VerifyParciaisFilter)
                     .Filter.ByIncludingOnly(VerifyCadastrosFilter)
                     .WriteTo.Async(configAsync => configAsync.File("logs/torcidas/cadastros.txt", rollingInterval: RollingInterval.Day))
                )
                .CreateLogger();

            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug);
                builder.AddSerilog(logger, true);
                builder.AddConsole();
            });


        }
    }
}
