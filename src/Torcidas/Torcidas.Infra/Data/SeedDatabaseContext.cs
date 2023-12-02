using Microsoft.EntityFrameworkCore;

using Torcidas.Domain.Entities;

namespace Torcidas.Infra.Data
{
    public static class SeedDatabaseContext
    {

        public static void Seed(ModelBuilder modelBuilder)
        {

            var now = DateTime.UtcNow;

            var ownerUser = new User()
            {
                Id = 1,
                Name = "Owner",
                UserName = "[TJF]Owner",
                CreatedAt = now,
                UpdatedAt = now,

            };

            modelBuilder.Entity<User>()
                .HasData(ownerUser);

            var fulanoUser = new User()
            {
                Id = 2,
                Name = "Fulano",
                UserName = "[TJF]Fulano",
                CreatedAt = now,
                UpdatedAt = now,

            };

            modelBuilder.Entity<User>()
                .HasData(fulanoUser);

            var beltranoUser = new User()
            {
                Id = 3,
                Name = "Beltrano",
                UserName = "[TJF]Beltrano",
                CreatedAt = now,
                UpdatedAt = now,

            };

            modelBuilder.Entity<User>()
                .HasData(beltranoUser);

            var ciclanoUser = new User()
            {
                Id = 4,
                Name = "Ciclano",
                UserName = "[TJF]Ciclano",
                CreatedAt = now,
                UpdatedAt = now,

            };

            modelBuilder.Entity<User>()
                .HasData(ciclanoUser);

        }

    }
}
