using EvolentHealth.Contact.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EvolentHealth.Contact.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ContactDBContext _contactDBContext;
        public Repository(ContactDBContext contactDBContext)
        {
            _contactDBContext = contactDBContext;
        }
        public async Task<int> Add(T model)
        {
            dynamic entity = model;
            entity.CreatedDate = DateTime.UtcNow;

            await _contactDBContext.AddAsync(model);
            await _contactDBContext.SaveChangesAsync(true);
            return entity.Id;
        }
        public async Task<int> Update(T model)
        {
            dynamic entity = (dynamic)model;
            entity.ModifiedDate = DateTime.UtcNow;

            _contactDBContext.Update(model);
            await _contactDBContext.SaveChangesAsync();
            return entity.Id;
        }
        public T GetById(int id)
        {
            return _contactDBContext.Set<T>().Find(id);
        }
        public async Task<int> Delete(T model)
        {
            dynamic entity = (dynamic)model;
            entity.Status = false;
            entity.ModifiedDate = DateTime.UtcNow;

            _contactDBContext.Update(model);
            await _contactDBContext.SaveChangesAsync();
            return entity.Id;
        }
        List<T> Get(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _contactDBContext.Set<T>();

            if (!(filter is null))
                query = query.Where(filter);

            if (!(orderBy is null))
                query = orderBy(query);

            return query.ToList();
        }
    }
}
