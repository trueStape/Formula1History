using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities.Peoples;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DriverService> _logger;

        public DriverService(IDriverRepository driverRepository,
            IMapper mapper,
            ILogger<DriverService> logger)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
            _logger = logger;
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
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Create Driver Async.DriverModel {driver}");
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
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during  Get Driver id: {driverId} Async.");
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
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during  Get All Drivers Async.");
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
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Delete Driver id: {driverId} Async.");
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
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Update Driver Async id: {driverId} Async. DriverModel {driverModel}");
                    await transaction.RollbackAsync();
                }
            }
            return "Driver Information Updated";
        }
    }
}