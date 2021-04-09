using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                   .HasColumnName("IdUsuario");

            builder.Property(i => i.Nombres)
                   .HasColumnName("Nombres")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(i => i.Apellidos)
                   .HasColumnName("Apellidos")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired()
                   .HasMaxLength(50);

             builder.Property(i => i.Email)
                   .HasColumnName("Email")
                  .HasColumnType("nvarchar(50)")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.IsActive)
                .HasColumnName("Activo");
        }
    }
}