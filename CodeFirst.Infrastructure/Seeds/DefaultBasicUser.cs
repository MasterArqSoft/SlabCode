using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DefaultBasicUser
    {
        public static void SeedDefaultBasicUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seguridad>().HasData(
                new Seguridad
                {
                    Id = 1,
                    UserName = "Erwing Candelario",
                    User = "ecandelario",
                    Password = "10000.0EQkXOOu4keKbVPrlNOnnQ==.pcSJniNK2hH79pdZdrA80opszrCkDuFONKP2ghttcks=",
                    Email = "******@gmail.com",
                    Activo = Domain.Enums.Estado.Habilitado,
                    Role = Domain.Enums.RoleType.Administrator,
                },
                new Seguridad
                {
                    Id = 2,
                    UserName = "Pepito Perez",
                    User = "UserOperador",
                    Password = "10000.0EQkXOOu4keKbVPrlNOnnQ==.pcSJniNK2hH79pdZdrA80opszrCkDuFONKP2ghttcks=",
                    Email = "***************@gmail.com",
                    Activo = Domain.Enums.Estado.Habilitado,
                    Role = Domain.Enums.RoleType.Operador,
                }
            );
        }
    }
}