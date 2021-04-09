using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DefaultBasicUsuarios
    {
        public static void SeedDefaultBasicUsuarios(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombres = "Erwing ",
                    Apellidos = "Candelario Restrepo",
                    Email = "******************@gmail.com",
                    IsActive = true

                },
                new Usuario
                {
                    Id = 2,
                    Nombres = "Pepito ",
                    Apellidos = "Perez",
                    Email = "************@gmail.com",
                    IsActive = true

                }
                );
        }
    }
}
