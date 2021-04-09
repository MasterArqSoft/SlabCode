using CodeFirst.Domain.Entities;
using System.Threading.Tasks;

namespace CodeFirst.Domain.Interfaces
{
    public interface IEstadoProyectoRepository : IRepository<EstadoProyecto>
    {
        Task<EstadoProyecto> GetByNombre(string nombreEstadoProyecto);
    }
}