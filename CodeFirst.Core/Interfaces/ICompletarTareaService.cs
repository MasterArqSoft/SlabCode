using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces
{
    public interface ICompletarTareaService
    {
        Task<bool> UpdateCambioEstadoTarea(int idTarea);
    }
}