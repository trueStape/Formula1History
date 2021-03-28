using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TeamRepository<T> : GenericRepository<T>, ITeamRepository<T>
        where T : class

    {
        private readonly DatabaseContext _context;
        public TeamRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public Task<T> GetTeamAsync(Guid id, Expression<Func<T, bool>> predicate)
        {
            return Query()
                .Where(predicate)
                .SingleOrDefaultAsync();
        }

        public Task<List<T>> GetAllTeamsAsync(Expression<Func<T, string>> predicate)
        {
            return Query()
                .OrderBy(predicate)
                .ToListAsync();
        }
    }
}