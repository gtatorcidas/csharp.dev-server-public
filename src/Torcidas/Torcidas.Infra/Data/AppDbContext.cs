using Microsoft.EntityFrameworkCore;

namespace Torcidas.Infra.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
       {

       }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
