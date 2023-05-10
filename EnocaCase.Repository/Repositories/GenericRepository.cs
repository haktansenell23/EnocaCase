using EnocaCase.Core.Entities;
using EnocaCase.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T :BaseEntity,new()
    {

        public AppDbContext _appDbContext;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<T>(); 
        }

        public async Task AddAllAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task AddAsync(T entity)
        {
             await _dbSet.AddAsync(entity); 
           

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
          return  await _dbSet.AnyAsync(expression);  
        }

        public  void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteAll(List<T> entities)
        {
             _dbSet.RemoveRange(entities);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateAll(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public IQueryable Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
