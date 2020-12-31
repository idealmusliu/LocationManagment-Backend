using ABCTask.Data;
using ABCTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCTask.Services.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
  where TEntity : class
    {
        private readonly ABCTaskDbContext _context;

        public GenericRepository(ABCTaskDbContext dbContext)
        {
            _context = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }
        public async virtual Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }
        public void Update(int id, TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
