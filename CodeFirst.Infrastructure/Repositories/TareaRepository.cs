using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Repositories
{
    public class TareaRepository : BaseRepository<Tarea>, ITareaRepository
    {
        public TareaRepository(CodeFirstContext context) : base(context)
        {
        }

        public async Task<bool> QueryMayorbyFechaEjecucion(DateTime fecha)
        {
            return await _entities.FirstOrDefaultAsync(x => x.FechaEjecucion > fecha).ConfigureAwait(false) != null;
        }

        public async Task<IEnumerable<Tarea>> SearchIdProyecto(int idProyecto)
        {
            return await _entities.Where(x => x.IdProyecto == idProyecto).ToListAsync().ConfigureAwait(false);
        }
    }
}