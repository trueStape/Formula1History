using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDriverService
    {
        Task CreateDriverAsync(DriverModel driver);
        Task<DriverModel> GetDriverAsync(Guid driverId);
        Task<List<DriverModel>> GetAllDriversAsync();
        Task<string> DeleteDriverAsync(Guid driverId);
        Task<string> UpdateDriverAsync(Guid driverId, DriverModel driverModel);
    }
}