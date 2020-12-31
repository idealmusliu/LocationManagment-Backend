using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCTask.Services.Interfaces
{
    public interface IGenericRepository<TEntity>
      where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        void Update(int id, TEntity entity);
        Task Delete(int id);
        Task Commit();
    }
}
