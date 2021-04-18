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
    public class DriverRepository : PeopleRepository<DriverEntity>, IDriverRepository
    {
        private readonly DatabaseContext _context;
        public DriverRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<List<DriverEntity>> GetAllPeopleAsync(Expression<Func<DriverEntity, string>> predicate)
        {
            return await _context.Driver
                .Include(x => x.Team)
                .OrderBy(predicate)
                .ToListAsync();
        }
    }
}