using EnocaCase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Repositories
{
    public interface IGenericRepository<T> where T:BaseEntity,new()
    {

        public Task AddAsync(T entity);

        public Task AddAllAsync(List<T> entities);


        public Task<T> GetByIdAsync(int id);




        public IQueryable<T> GetAll();    //use orderby etc func when used getallasync()


        public IQueryable Where(Expression<Func<T, bool>> expression);

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression);


        public void Update(T entity);

        public void UpdateAll(List<T> entities);


        public void DeleteAll(List<T> entities);

        public void Delete(T entity);

    }
}
