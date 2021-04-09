using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class EstadoProyectoConfig : IEntityTypeConfiguration<EstadoProyecto>
    {
        public void Configure(EntityTypeBuilder<EstadoProyecto> builder)
        {
            builder.ToTable("EstadoProyecto");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("IdEstadoProyecto");

            builder.Property(a => a.Nombre)
                   .HasColumnName("Nombre")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}