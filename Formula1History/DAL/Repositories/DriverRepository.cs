using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities.Peoples;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DriverRepository : GenericRepository<DriverEntity>, IDriverRepository
    {
        private readonly DatabaseContext _context;
        public DriverRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;
        }
    }
}