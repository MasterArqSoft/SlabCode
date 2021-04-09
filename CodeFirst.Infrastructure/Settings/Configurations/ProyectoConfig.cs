using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class ProyectoConfig : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.ToTable("Proyecto");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                   .HasColumnName("IdProyecto");

            builder.Property(i => i.IdEstadoProyecto)
                   .HasColumnName("IdEstadoProyecto");

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

            builder.Property(i => i.FechaInicio)
                   .HasColumnName("FechaInicio")
                   .HasColumnType("date");

            builder.Property(i => i.FechaFinalizacion)
                   .HasColumnName("FechaFinalizacion")
                   .HasColumnType("date");

            builder.HasOne(i => i.Estado)
                   .WithMany(p => p.Proyectos)
                   .HasForeignKey(d => d.IdEstadoProyecto)
                   .HasConstraintName("FK_Proyectos_Estados");

            builder.HasMany(i => i.Tareas)
                   .WithOne(p => p.Proyecto);
        }
    }
}