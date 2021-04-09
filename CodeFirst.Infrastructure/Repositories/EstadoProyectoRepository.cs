using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Repositories
{
    public class EstadoProyectoRepository : BaseRepository<EstadoProyecto>, IEstadoProyectoRepository
    {
        public EstadoProyectoRepository(CodeFirstContext context) : base(context)
        {
        }

        public async Task<EstadoProyecto> GetByNombre(string nombreEstadoProyecto)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Nombre == nombreEstadoProyecto).ConfigureAwait(false);
        }
    }
}