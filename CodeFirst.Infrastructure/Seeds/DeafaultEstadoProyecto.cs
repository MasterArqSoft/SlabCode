using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DeafaultEstadoProyecto
    {
        public static void SeedDeafaultEstadoProyecto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoProyecto>().HasData(
                new EstadoProyecto()
                {
                    Id = 1,
                    Nombre = "En Proceso",
                },
                new EstadoProyecto()
                {
                    Id = 2,
                    Nombre = "Finalizado",
                }
            );
        }
    }
}