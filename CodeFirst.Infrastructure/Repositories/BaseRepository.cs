using CodeFirst.Domain.BaseEntities;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _entities;

        public BaseRepository(CodeFirstContext context)
        {
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id).ConfigureAwait(false);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity).ConfigureAwait(false);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id).ConfigureAwait(false);
            _entities.Remove(entity);
        }
    }
}