using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Repositories
{
    public class EstadoTareaRepository : BaseRepository<EstadoTarea>, IEstadoTareaRepository
    {
        public EstadoTareaRepository(CodeFirstContext context) : base(context)
        {
        }

        public async Task<EstadoTarea> GetByNombre(string nombreEstadoTarea)
        {
            return await _entities.Where(x => x.Nombre == nombreEstadoTarea).FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}