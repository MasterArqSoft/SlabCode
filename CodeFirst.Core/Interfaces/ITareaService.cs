using CodeFirst.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces
{
    public interface ITareaService
    {
        Task<Tarea> GetTarea(int id);

        Task InsertTarea(Tarea tarea);

        Task<bool> UpdateTarea(Tarea tarea);

        Task<bool> DeleteTarea(int id);

        Task<bool> QueryMayorbyFechaEjecucion(DateTime fecha);

        Task<IEnumerable<Tarea>> SearchIdProyecto(int idProyecto);
    }
}