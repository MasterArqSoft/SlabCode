using CodeFirst.Domain.Entities;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces
{
    public interface IEstadoProyectoService
    {
        Task<EstadoProyecto> GetEstadoProyecto(int id);

        Task<EstadoProyecto> GetByNombre(string nombreEstadoProyecto);

        Task InsertEstadoProyecto(EstadoProyecto estadoPoryecto);

        Task<bool> UpdateEstadoProyecto(EstadoProyecto estadoPoryecto);

        Task<bool> DeleteProyecto(int id);
    }
}