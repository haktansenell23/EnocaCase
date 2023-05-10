using EnocaCase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Services
{
    public interface IGenericService<T> where T : BaseEntity,new()
    {
        public Task<T> AddAsync(T entity);

        public Task AddAllAsync(List<T> entities);


        public Task<T> GetByIdAsync(int id);




        public Task<List<T>> GetAllAsync();    //use orderby etc func when used getallasync()


        public IQueryable Where(Expression<Func<T, bool>> expression);

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression);


        public Task UpdateAsync(T entity);

        public Task UpdateAllAsync(List<T> entities);


        public Task DeleteAllAsync(List<T> entities);

        public Task DeleteAsync(T entity);

    }
}
