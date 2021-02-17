using DAL.Entities.Peoples;

namespace DAL.Interfaces
{
    public interface IManagerRepository : IGenericRepository<ManagerEntity>, IPeople<ManagerEntity>
    {
       
    }
}