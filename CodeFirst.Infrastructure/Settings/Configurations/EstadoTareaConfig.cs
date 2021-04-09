using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class EstadoTareaConfig : IEntityTypeConfiguration<EstadoTarea>
    {
        public void Configure(EntityTypeBuilder<EstadoTarea> builder)
        {
            builder.ToTable("EstatoTarea");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("IdEstadoTarea");

            builder.Property(c => c.Nombre)
                   .HasColumnName("Nombre")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired()
                   .HasMaxLength(50);
            
        }
    }
}