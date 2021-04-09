using CodeFirst.Core.DTOs;
using CodeFirst.Domain.Entities;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces
{
    public interface ISeguridadService
    {
        Task<Seguridad> GetLoginByCredentials(Login userLogin);
        Task RegisterUser(SeguridadDto seguridadDto);
        Task UpdateUser(UserDto user);
    }
}