using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Infrastructure.Settings;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CodeFirstContext _context;

        public UnitOfWork(CodeFirstContext context)
        {
            _context = context;

            UsuarioRepository = new BaseRepository<Usuario>(_context);

            ProyectoRepository = new ProyectoRepository(_context);

            TareaRepository = new TareaRepository(_context);

            SeguridadRepository = new SeguridadRepository(_context);

            EstadoProyectoRepository = new EstadoProyectoRepository(_context);

            EstadoTareaRepository = new EstadoTareaRepository(_context);
        }

        public IRepository<Usuario> UsuarioRepository { get; }

        public IProyectoRepository ProyectoRepository { get; }

        public ITareaRepository TareaRepository { get; }

        public ISeguridadRepository SeguridadRepository { get; }

        public IEstadoProyectoRepository EstadoProyectoRepository { get; }

        public IEstadoTareaRepository EstadoTareaRepository { get; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}