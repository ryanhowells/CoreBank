using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IService<T> where T : class
    {
        T Get(Expression<Func<T, bool>> query);
        List<T> GetAll(Expression<Func<T, bool>> query);
        List<T> GetAll();
        void Add(T entity);
        void AddRange(List<T> entities);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
        void Update(T entity);
    }
}
