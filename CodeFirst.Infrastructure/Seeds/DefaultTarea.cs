using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DafaultTarea
    {
        public static void SeedDafaultTarea(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().HasData(
                new Tarea()
                {
                    Id = 1,
                    Nombre = "Tarea No. 1",
                    Descripcion = "Descripcion Tarea No. 1",
                    FechaEjecucion = new DateTime(2021, 3, 29, 15, 0, 0),
                    IdProyecto = 1,
                    IdEstadoTarea = 1,
                },
                new Tarea()
                {
                    Id = 2,
                    Nombre = "Tarea No. 2",
                    Descripcion = "Descripcion Tarea No. 2",
                    FechaEjecucion = new DateTime(2021, 3, 29, 15, 0, 0),
                    IdProyecto = 2,
                    IdEstadoTarea = 1,
                },
                new Tarea()
                {
                    Id = 3,
                    Nombre = "Tarea No. 3",
                    Descripcion = "Descripcion Tarea No. 3",
                    FechaEjecucion = new DateTime(2021, 3, 29, 15, 0, 0),
                    IdProyecto = 2,
                    IdEstadoTarea = 1,
                },
                new Tarea()
                {
                    Id = 4,
                    Nombre = "Tarea No. 4",
                    Descripcion = "Descripcion Tarea No. 4",
                    FechaEjecucion = new DateTime(2021, 3, 29, 15, 0, 0),
                    IdProyecto = 3,
                    IdEstadoTarea = 1,
                },
                new Tarea()
                {
                    Id = 5,
                    Nombre = "Tarea No. 5",
                    Descripcion = "Descripcion Tarea No. 5",
                    FechaEjecucion = new DateTime(2021, 3, 29, 15, 0, 0),
                    IdProyecto = 5,
                    IdEstadoTarea = 1,
                },
                new Tarea()
                {
                    Id = 6,
                    Nombre = "Tarea No. 6",
                    Descripcion = "Descripcion Tarea No. 6",
                    FechaEjecucion = new DateTime(2021, 3, 29, 15, 0, 0),
                    IdProyecto = 4,
                    IdEstadoTarea = 1,
                }

            );
        }
    }
}