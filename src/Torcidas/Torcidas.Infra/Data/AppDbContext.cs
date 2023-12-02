using Microsoft.EntityFrameworkCore;
using System.Reflection;

using Torcidas.Domain.Entities;
using Torcidas.Infra.Repositories.Interfaces;

namespace Torcidas.Infra.Data
{
    public class AppDbContext : DbContext, IDbContext
    {

        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seeding Database

            SeedDatabaseContext.Seed(modelBuilder);

            #endregion

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        #region Override to DateTime
        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is BaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            entity.UpdatedAt = now;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedAt = now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        #endregion

    }
}
