using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DefaultProyecto
    {
        public static void SeedDefaultProyecto(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto()
                {
                    Id = 1,
                    Nombre = "Proyecto A",
                    Descripcion = "Descripcion Proyecto A",
                    FechaInicio = new DateTime(2021, 3, 29, 15, 0, 0),
                    FechaFinalizacion = new DateTime(2021, 3, 30, 15, 0, 0),
                    IdEstadoProyecto = 1,
                },
                new Proyecto()
                {
                    Id = 2,
                    Nombre = "Proyecto B",
                    Descripcion = "Descripcion Proyecto B",
                    FechaInicio = new DateTime(2021, 3, 29, 15, 0, 0),
                    FechaFinalizacion = new DateTime(2021, 3, 30, 15, 0, 0),
                    IdEstadoProyecto = 1,
                },
                new Proyecto()
                {
                    Id = 3,
                    Nombre = "Proyecto C",
                    Descripcion = "Descripcion Proyecto C",
                    FechaInicio = new DateTime(2021, 3, 29, 15, 0, 0),
                    FechaFinalizacion = new DateTime(2021, 3, 30, 15, 0, 0),
                    IdEstadoProyecto = 1,
                },
                new Proyecto()
                {
                    Id = 4,
                    Nombre = "Proyecto D",
                    Descripcion = "Descripcion Proyecto D",
                    FechaInicio = new DateTime(2021, 3, 29, 15, 0, 0),
                    FechaFinalizacion = new DateTime(2021, 3, 30, 15, 0, 0),
                    IdEstadoProyecto = 1,
                },
                new Proyecto()
                {
                    Id = 5,
                    Nombre = "Proyecto E",
                    Descripcion = "Descripcion Proyecto E",
                    FechaInicio = new DateTime(2021, 3, 29, 15, 0, 0),
                    FechaFinalizacion = new DateTime(2021, 3, 30, 15, 0, 0),
                    IdEstadoProyecto = 1,
                },
                new Proyecto()
                {
                    Id = 6,
                    Nombre = "Proyecto F",
                    Descripcion = "Descripcion Proyecto F",
                    FechaInicio = new DateTime(2021, 3, 29, 15, 0, 0),
                    FechaFinalizacion = new DateTime(2021, 3, 30, 15, 0, 0),
                    IdEstadoProyecto = 1,
                }

            );
        }
    }
}