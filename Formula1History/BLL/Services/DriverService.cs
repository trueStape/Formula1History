using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities.Peoples;
using DAL.Interfaces;

namespace BLL.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }


        public async Task CreateDriverAsync(DriverModel driver)
        {
            await using (var transaction = await _driverRepository.AddTransactionAsync())
            {
                try
                {
                    var driverEntity = _mapper.Map<DriverEntity>(driver);
                    driverEntity.Id = Guid.NewGuid();

                    await _driverRepository.CreateAsync(driverEntity);
                    await _driverRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task<DriverModel> GetDriverAsync(Guid driverId)
        {
            var driverModel = new DriverModel();
            await using (var transaction = await _driverRepository.AddTransactionAsync())
            {
                try
                {
                    var driverEntity = await _driverRepository.GetPeopleAsync(driverId, x => x.Id == driverId);
                    driverModel = _mapper.Map<DriverModel>(driverEntity);
                    
                    await transaction.CommitAsync();
                    return driverModel;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }

            return driverModel;
        }

        public async Task<List<DriverModel>> GetAllDriversAsync()
        {
            var driverModels = new List<DriverModel>();
            await using (var transaction = await _driverRepository.AddTransactionAsync())
            {
                try
                {
                    var drivers = await _driverRepository.GetAllPeopleAsync(x => x.LastName);
                    driverModels = _mapper.Map<List<DriverEntity>, List<DriverModel>>(drivers);

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }

            return driverModels;
        }

        public async Task<string> DeleteDriverAsync(Guid driverId)
        {
            var driver = new DriverEntity();
            await using (var transaction = await _driverRepository.AddTransactionAsync())
            {
                try
                {
                    driver = await _driverRepository.GetPeopleAsync(driverId, x => x.Id == driverId);
                    if (driver == null) return "Driver is not found";

                    await _driverRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }

            //TODO 7 add correct return value
            return $"Driver: {driver.LastName} {driver.Name} deleted";
        }

        public async Task<string> UpdateDriverAsync(Guid driverId, DriverModel driverModel)
        {
            await using (var transaction = await _driverRepository.AddTransactionAsync())
            {
                try
                {
                    var driver = await _driverRepository.GetPeopleAsync(driverId, x => x.Id == driverId);
                    if (driver == null) return "Driver is not found";

                    //TODO Add model attributes for update driver
                    driver.LastName = driverModel.LastName;
                    driver.Name = driverModel.Name;

                    //driver.Patronymic
                    //driver.CarNumber
                    //....

                    //
                    
                    await _driverRepository.SaveAsync();
                    
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
            return "Driver Information Updated";
        }
    }
}