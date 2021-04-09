using CodeFirst.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Usuario> UsuarioRepository { get; }
        IProyectoRepository ProyectoRepository { get; }
        ITareaRepository TareaRepository { get; }
        ISeguridadRepository SeguridadRepository { get; }
        IEstadoProyectoRepository EstadoProyectoRepository { get; }
        IEstadoTareaRepository EstadoTareaRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}