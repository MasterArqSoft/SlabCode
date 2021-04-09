using CodeFirst.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Domain.Interfaces
{
    public interface IProyectoRepository : IRepository<Proyecto>
    {
        Task<bool> RagonFecha(DateTime fecha);
    }
}