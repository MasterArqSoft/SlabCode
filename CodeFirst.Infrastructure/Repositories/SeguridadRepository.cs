using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Repositories
{
    public class SeguridadRepository : BaseRepository<Seguridad>, ISeguridadRepository
    {
        public SeguridadRepository(CodeFirstContext context) : base(context)
        {
        }

        public async Task<Seguridad> GetLoginByCredentials(Login login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.Usuario).ConfigureAwait(false);
        }
    }
}