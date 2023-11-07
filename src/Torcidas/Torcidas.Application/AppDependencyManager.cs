using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Torcidas.Infra.Data;
using Torcidas.Infra.Repositories;
using Torcidas.Infra.Repositories.Interfaces;

namespace Torcidas.Application
{
    public class AppDependencyManager
    {
        public static void Configure(IServiceCollection services, string databaseConnection)
        {
            services
                .AddDbContext<AppDbContext>(options => options.UseNpgsql(databaseConnection))
                .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
