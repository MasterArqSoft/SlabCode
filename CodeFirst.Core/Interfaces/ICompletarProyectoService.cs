using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces
{
    public interface ICompletarProyectoService
    {
        Task<bool> UpdateCambioEstadoProyecto(int idProyecto);
    }
}