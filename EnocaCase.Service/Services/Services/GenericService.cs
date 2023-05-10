using EnocaCase.Core.Entities;
using EnocaCase.Core.Repositories;
using EnocaCase.Core.Services;
using EnocaCase.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Service.Services.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity, new()
    {
        private readonly IGenericRepository<T> _repository;  

        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
             _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAllAsync(List<T> entities)
        {
            await _repository.AddAllAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
        await _repository.AddAsync(entity); 
        await _unitOfWork.CommitAsync();
        return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);  
        }

        public async Task DeleteAsync(T entity)
        {
            _repository.Delete(entity);    
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAllAsync(List<T> entities)
        {
            _repository.DeleteAll(entities);
            await _unitOfWork.CommitAsync();    
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);  
        }

        public async Task UpdateAllAsync(List<T> entities)
        {
            _repository.UpdateAll(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);   
        }
    }
}
