using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class SeguridadConfig : IEntityTypeConfiguration<Seguridad>
    {
        public void Configure(EntityTypeBuilder<Seguridad> builder)
        {
            builder.ToTable("Seguridad");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("IdSeguridad");

            builder.Property(e => e.User)
                   .HasColumnName("Usuario")
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(e => e.UserName)
                   .HasColumnName("NombreUsuario")
                   .IsRequired()
                   .HasMaxLength(100)
                   .IsUnicode(false);

            builder.Property(e => e.Password)
                   .HasColumnName("Contrasena")
                   .IsRequired()
                   .HasMaxLength(200)
                   .IsUnicode(false);

            builder.Property(i => i.Email)
                   .HasColumnName("Email")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.Activo)
                   .HasColumnName("Activo")
                   .HasMaxLength(20)
                   .IsRequired()
                   .HasConversion(
                                    x => x.ToString(),
                                    x => (Estado)Enum.Parse(typeof(Estado), x)
                                 );

            builder.Property(e => e.Role)
                   .HasColumnName("Rol")
                   .HasMaxLength(15)
                   .IsRequired()
                   .HasConversion(
                                    x => x.ToString(),
                                    x => (RoleType)Enum.Parse(typeof(RoleType), x)
                                 );
        }
    }
}