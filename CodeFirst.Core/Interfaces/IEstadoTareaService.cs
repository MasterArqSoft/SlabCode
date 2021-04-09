using CodeFirst.Domain.Entities;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces
{
    public interface IEstadoTareaService
    {
        Task<EstadoTarea> GetEstadoTarea(int id);

        Task<EstadoTarea> GetByNombre(string nombreEstadoTarea);

        Task InsertEstadoTarea(EstadoTarea estadoPoryecto);

        Task<bool> UpdateEstadoTarea(EstadoTarea estadoPoryecto);

        Task<bool> DeleteTarea(int id);
    }
}