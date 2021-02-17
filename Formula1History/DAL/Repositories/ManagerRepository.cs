using DAL.Entities.Peoples;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ManagerRepository : PeopleRepository<ManagerEntity>, IManagerRepository
    {
        private readonly DatabaseContext _context;
        public ManagerRepository(DatabaseContext context)
            : base(context)
        {
            _context = context;
        }

    }
}