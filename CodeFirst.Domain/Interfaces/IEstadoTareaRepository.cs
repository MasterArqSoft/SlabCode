using CodeFirst.Domain.Entities;
using System.Threading.Tasks;

namespace CodeFirst.Domain.Interfaces
{
    public interface IEstadoTareaRepository : IRepository<EstadoTarea>
    {
        Task<EstadoTarea> GetByNombre(string nombreEstadoTara);
    }
}