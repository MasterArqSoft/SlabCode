using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Repositories
{
    public class ProyectoRepository : BaseRepository<Proyecto>, IProyectoRepository
    {
        public ProyectoRepository(CodeFirstContext context) : base(context)
        {
        }

        public async Task<bool> RagonFecha(DateTime fecha)
        {
            return await _entities.FirstOrDefaultAsync(x => x.FechaInicio >= fecha && x.FechaFinalizacion <= fecha).ConfigureAwait(false) != null;
        }
    }
}