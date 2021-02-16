using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities.Peoples;

namespace DAL.Interfaces
{
    public interface IDriverRepository : IGenericRepository<DriverEntity>
    {
        Task<DriverEntity> GetDriverAsync(Guid id);
        Task<List<DriverEntity>> GetAllDriversAsync();
    }
}