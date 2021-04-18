using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entities.Peoples;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PeopleRepository<T> : GenericRepository<T>, IPeople<T>
        where T : class
    {
       
        private readonly DatabaseContext _context;
        public PeopleRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;
        }

        public Task<T> GetPeopleAsync(Guid id, Expression<Func<T, bool>> predicate)
        {
            return Query()
                .Where(predicate)
                .SingleOrDefaultAsync();
        }
        public virtual Task<List<T>> GetAllPeopleAsync(Expression<Func<T, string>> predicate)
        {
            return Query()
                .OrderBy(predicate)
                .ToListAsync();
        }
    }
}