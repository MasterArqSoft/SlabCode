using CodeFirst.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirst.Domain.Interfaces
{
    public interface ITareaRepository : IRepository<Tarea>
    {
        Task<bool> QueryMayorbyFechaEjecucion(DateTime fecha);

        Task<IEnumerable<Tarea>> SearchIdProyecto(int idProyecto);
    }
}