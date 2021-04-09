using CodeFirst.Domain.Entities;
using System.Threading.Tasks;

namespace CodeFirst.Domain.Interfaces
{
    public interface ISeguridadRepository : IRepository<Seguridad>
    {
        Task<Seguridad> GetLoginByCredentials(Login login);
    }
}