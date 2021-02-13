
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> EntitySet;

        public GenericRepository(DbContext context)
        {
            Context = context;
            EntitySet = context.Set<T>();
        }
        public IQueryable<T> Query()
        {
            return EntitySet.AsQueryable();
        }

        public T Get(Guid id)
        {
            return EntitySet.Find(id);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await EntitySet.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return EntitySet.AsEnumerable();
        }

        public IAsyncEnumerable<T> GetAllAsync()
        {
            return EntitySet.AsAsyncEnumerable();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return EntitySet.Where(predicate).AsEnumerable();
        }

        public IAsyncEnumerable<T> FilterAsync(Expression<Func<T, bool>> predicate)
        {
            return EntitySet.Where(predicate).AsAsyncEnumerable();
        }

        public void Create(T entity)
        {
            EntitySet.Add(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await EntitySet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            EntitySet.Update(entity);
        }

        public void Delete(T entity)
        {
            EntitySet.Remove(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}