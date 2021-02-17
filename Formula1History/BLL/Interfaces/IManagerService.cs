using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IManagerService
    {
        Task CreateManagerAsync(ManagerModel manager);
        Task<ManagerModel> GetManagerAsync(Guid managerId);
        Task<List<ManagerModel>> GetAllManagersAsync();
        Task<string> DeleteManagerAsync(Guid managerId);
        Task<string> UpdateManagerAsync(Guid managerId, ManagerModel managerModel);
    }
}