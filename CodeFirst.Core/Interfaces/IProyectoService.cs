using CodeFirst.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces
{
    public interface IProyectoService
    {
        Task<Proyecto> GetProyecto(int id);

        Task InsertProyecto(Proyecto proyecto);

        Task<bool> UpdateProyecto(Proyecto proyecto);

        Task<bool> DeleteProyecto(int id);

        Task<bool> RagonFecha(DateTime fecha);
    }
}