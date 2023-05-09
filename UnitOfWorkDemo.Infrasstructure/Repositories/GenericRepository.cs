using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkDemo.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContextClass _dbContext;
        protected GenericRepository(DbContextClass dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task Add(T entity)
        {
             await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
             _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
             _dbContext.Set<T>().Update(entity);
        }
    }
}
