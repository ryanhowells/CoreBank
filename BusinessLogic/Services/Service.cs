using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        
        public virtual List<T> GetAll(Expression<Func<T, bool>> query)
        {
            return _repository.GetAll(query);
        }

        public virtual T Get(Expression<Func<T, bool>> query)
        {
            return _repository.Get(query);
        }

        public virtual List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }
        
        public virtual void AddRange(List<T> entities)
        {
            _repository.AddRange(entities);
        }

        public virtual void Remove(T entity)
        {
            _repository.Remove(entity);
        }

        public virtual void RemoveRange(List<T> entities)
        {
            _repository.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
