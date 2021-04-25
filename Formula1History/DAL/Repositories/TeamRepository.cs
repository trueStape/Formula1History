using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entities.Team;
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

        public async Task<List<TeamEntity>> GetAllTeamsAsync(Expression<Func<TeamEntity, string>> predicate)
        {
            return await _context.Team
                .Include(x => x.Drivers)
                .Include(x =>x.Managers)
                .OrderBy(predicate)
                .ToListAsync();
        }
    }
}