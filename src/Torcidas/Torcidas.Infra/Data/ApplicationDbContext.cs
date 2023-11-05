using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Torcidas.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {


       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       {

       }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
