using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DefaultEstadoTarea
    {
        public static void SeedDefaultEstadoTarea(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoTarea>().HasData(
                new EstadoTarea()
                {
                    Id = 1,
                    Nombre = "En Proceso",
                },
                new EstadoTarea()
                {
                    Id = 2,
                    Nombre = "Finalizado",
                }
            );
        }
    }
}