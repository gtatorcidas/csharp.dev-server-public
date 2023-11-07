using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.UI.Systems;
using Torcidas.Application;
using Torcidas.Application.Services;
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

            // Application Layer Dependency Injection Manager
            AppDependencyManager.Configure(services, configuration.GetConnectionString("Default"));

            // Services
            services
                .AddTransient<IServerConfigService, ServerConfigService>()
                .AddTransient<IFpsService, FpsService>()
                .AddSystemsInAssembly();

            // Systems
            services
                .AddSystem<ServerConfigSystem>()
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