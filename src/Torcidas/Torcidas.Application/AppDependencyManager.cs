using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Torcidas.Infra.Data;
using Torcidas.Infra.Repositories;
using Torcidas.Infra.Repositories.Interfaces;

namespace Torcidas.Application
{
    public class AppDependencyManager
    {
        #region Public Methods
        public static void Configure(IServiceCollection services, string databaseConnection)
        {

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<IDbContext, AppDbContext>(options => options
                    .UseNpgsql(databaseConnection)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                 )
                .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                .AddScoped(typeof(IUserRepository), typeof(UserRepository));
        }

        #endregion
    }
}
