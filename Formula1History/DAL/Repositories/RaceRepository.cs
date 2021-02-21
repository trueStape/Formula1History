using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entities.Race;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RaceRepository<T> : GenericRepository<T>, IRaceRepository<T>
        where T : class
    {
        private readonly DatabaseContext _context;

        public RaceRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;
        }

        public Task<T> GetRaceAsync(Guid id, Expression<Func<T, bool>> predicate)
        {
            return Query()
                .Where(predicate)
                .SingleOrDefaultAsync();
        }

        public Task<List<T>> GetAllRaceAsync(Expression<Func<T, string>> predicate)
        {
            return Query()
                .OrderBy(predicate)
                .ToListAsync();
        }
        
    }
}