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
            var driverEntity = _mapper.Map<DriverEntity>(driver);
            driverEntity.Id = Guid.NewGuid();

            await _driverRepository.CreateAsync(driverEntity);
            await _driverRepository.SaveAsync();
        }

        public async Task<DriverModel> GetDriverAsync(Guid driverId)
        {
            var driverEntity = await _driverRepository.GetDriverAsync(driverId);
            var driverModel = _mapper.Map<DriverModel>(driverEntity);

            return driverModel;
        }

        public async Task<List<DriverModel>> GetAllDriversAsync()
        {
            var drivers = await _driverRepository.GetAllDriversAsync();
            var driverModels = _mapper.Map<List<DriverEntity>, List<DriverModel>>(drivers);

            return driverModels;
        }

        public async Task<string> DeleteDriverAsync(Guid driverId)
        {
            var driver = await _driverRepository.GetDriverAsync(driverId);
            if (driver == null) return "Driver is not found";

            await _driverRepository.SaveAsync();

            return $"Driver: {driver.LastName} {driver.Name} deleted";
        }

        public async Task<string> UpdateDriverAsync(Guid driverId, DriverModel driverModel)
        {
            var driver = await _driverRepository.GetDriverAsync(driverId);
            if (driver == null) return "Driver is not found";

            //TODO Add model attributes for update driver
            driver.LastName = driverModel.LastName;
            driver.Name = driverModel.Name;

            //driver.Patronymic
            //driver.CarNumber
            //....

            //
            

            await _driverRepository.SaveAsync();

            return "Driver Information Updated";
        }
    }
}