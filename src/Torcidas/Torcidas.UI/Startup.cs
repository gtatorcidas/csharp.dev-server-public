using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SampSharp.Entities;
using SampSharp.Entities.SAMP;

using Torcidas.Application.Services;
using Torcidas.Core.Interfaces.Repositories;
using Torcidas.Core.Interfaces.Services;
using Torcidas.Core.Systems;
using Torcidas.Infra.Data;
using Torcidas.Infra.Repositories;
using Torcidas.UI.Systems;

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

            // Database
            services
                .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Default")))
                .AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

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