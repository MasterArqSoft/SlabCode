using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class TareaConfig : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.ToTable("Tarea");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                   .HasColumnName("IdTarea");

            builder.Property(i => i.IdProyecto)
                  .HasColumnName("IdProyecto");

            builder.Property(i => i.IdEstadoTarea)
                   .HasColumnName("IdEstadoTarea");

            builder.Property(i => i.Nombre)
                   .HasColumnName("Nombre")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(i => i.Descripcion)
                   .HasColumnName("Descripcion")
                   .HasColumnType("nvarchar(200)")
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(i => i.FechaEjecucion)
                   .HasColumnName("FechaEjecucion")
                   .HasColumnType("date");

            builder.HasOne(i => i.Proyecto)
                   .WithMany(p => p.Tareas)
                   .HasForeignKey(d => d.IdProyecto)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_Tareas_Proyectos");

            builder.HasOne(d => d.Estado)
                   .WithMany(p => p.Tareas)
                   .HasForeignKey(d => d.IdEstadoTarea)
                   .HasConstraintName("FK_Tareas_Estados");
        }
    }
}