using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class ModelBuilderSeed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            DeafaultEstadoProyecto.SeedDeafaultEstadoProyecto(modelBuilder);
            DefaultEstadoTarea.SeedDefaultEstadoTarea(modelBuilder);
            DefaultProyecto.SeedDefaultProyecto(modelBuilder);
            DafaultTarea.SeedDafaultTarea(modelBuilder);
            DefaultBasicUser.SeedDefaultBasicUser(modelBuilder);
            DefaultBasicUsuarios.SeedDefaultBasicUsuarios(modelBuilder);
        }
    }
}