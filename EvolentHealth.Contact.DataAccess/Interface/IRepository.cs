using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EvolentHealth.Contact.DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get<T>(Expression<Func<T, bool>> predicate)
     where T : class;
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<List<T>> Gets();
    }
}
