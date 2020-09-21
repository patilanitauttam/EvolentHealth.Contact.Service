using EvolentHealth.Contact.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EvolentHealth.Contact.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ContactDBContext _contactDBContext;
        private DbSet<T> _entities;

        public Repository(ContactDBContext contactDBContext)
        {
            _contactDBContext = contactDBContext;
            _entities = _contactDBContext.Set<T>();
        }
        public async Task Add(T model)
        {
            await _entities.AddAsync(model);
            await _contactDBContext.SaveChangesAsync(true);
        }
        public async Task Update(T model)
        {
            _entities.Update(model);
            await _contactDBContext.SaveChangesAsync();
        }
        public async Task<T> Get<T>(Expression<Func<T, bool>> predicate)
     where T : class
        {
            return await _contactDBContext.Set<T>().FirstOrDefaultAsync(predicate); 
        }

        public async Task Delete(T model)
        {
            _entities.Remove(model);
            await _contactDBContext.SaveChangesAsync();
        }
        public async Task<List<T>> Gets()
        {
            return await _contactDBContext.Set<T>().ToListAsync();
        }
    }
}
