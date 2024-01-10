using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;

using Torcidas.Application;
using Torcidas.UI.Systems.Users;
using Torcidas.UI.Systems.Server;
using Torcidas.Application.Services.Tools;
using Torcidas.Application.Services.Users;
using Torcidas.Application.Services.Server;
using Torcidas.Application.Services.Overrides;
using Torcidas.Application.Services.Interfaces;

namespace Torcidas.UI
{
    public class Startup : IStartup
    {
        public void Configure(IServiceCollection services)
        {

            // Configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            services.AddSingleton<IConfiguration>(configuration);

            // Logger
            AppLoggerManager.Configure(services);

            // Application Layer Dependency Injection Manager
            AppDependencyManager.Configure(services, configuration.GetConnectionString("Default"));

            // Services
            services
                .AddTransient<ILoggerService, LoggerService>()
                .AddTransient<IPlayerCommandService, AppPlayerCommandService>()
                .AddTransient<IServerConfigService, ServerConfigService>()
                .AddTransient<IGlobalManagerService, GlobalManagerService>()
                .AddTransient<IServerHudService, ServerHudService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IFpsService, FpsService>()
                .AddSystemsInAssembly();

            // Systems
            services
                .AddSystem<ServerConfigSystem>()
                .AddSystem<UserSystem>()
                .AddSystem<FpsSystem>();

        }

        public void Configure(IEcsBuilder builder)
        {
            // TODO: Enable desired ECS system features
            builder.EnableSampEvents()
                .EnablePlayerCommands()
                .EnableRconCommands();
        }
    }
}