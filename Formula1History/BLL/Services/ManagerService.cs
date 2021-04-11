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
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ManagerService> _logger;

        public ManagerService(IManagerRepository managerRepository,
            IMapper mapper,
            ILogger<ManagerService> logger)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task CreateManagerAsync(ManagerModel manager)
        {
            await using (var transaction = await _managerRepository.AddTransactionAsync())
            {
                try
                {
                    var managerEntity = _mapper.Map<ManagerEntity>(manager);
                    managerEntity.Id = Guid.NewGuid();

                    await _managerRepository.CreateAsync(managerEntity);
                    await _managerRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Create Manager Async. ManagerModel {manager}");
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task<ManagerModel> GetManagerAsync(Guid managerId)
        {
            var managerModel = new ManagerModel();
            await using (var transaction = await _managerRepository.AddTransactionAsync())
            {
                try
                {
                    var managerEntity = await _managerRepository.GetPeopleAsync(managerId, x => x.Id == managerId);
                    managerModel = _mapper.Map<ManagerModel>(managerEntity);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during  Get Manager id: {managerId} Async.");
                    await transaction.RollbackAsync();
                }
            }
            
            return managerModel;
        }

        public async Task<List<ManagerModel>> GetAllManagersAsync()
        {
            var managerModels = new List<ManagerModel>();
            await using (var transaction = await _managerRepository.AddTransactionAsync())
            {
                try
                {
                    var managers = await _managerRepository.GetAllPeopleAsync(x => x.LastName);
                    managerModels = _mapper.Map<List<ManagerEntity>, List<ManagerModel>>(managers);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during  Get All Managers Async.");
                    await transaction.RollbackAsync();
                }
            }
           
            return managerModels;
        }

        public async Task<string> DeleteManagerAsync(Guid managerId)
        {
            var manager = new ManagerEntity();
            await using (var transaction = await _managerRepository.AddTransactionAsync())
            {
                try
                {
                    manager = await _managerRepository.GetPeopleAsync(managerId, x => x.Id == managerId);
                    if (manager == null) return "Driver is not found";

                    await _managerRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Delete Manager id: {managerId} Async.");
                    await transaction.RollbackAsync();
                }
            }
            //TODO 7 add correct return value
            return $"Driver: {manager.LastName} {manager.Name} deleted";
        }

        public async Task<string> UpdateManagerAsync(Guid managerId, ManagerModel managerModel)
        {
            await using (var transaction = await _managerRepository.AddTransactionAsync())
            {
                try
                {
                    var manager = await _managerRepository.GetPeopleAsync(managerId, x => x.Id == managerId);
                    if (manager == null) return "Driver is not found";

                    //TODO Add model attributes for update manager
                    manager.LastName = managerModel.LastName;
                    manager.Name = managerModel.Name;

                    //manager.Patronymic
                    //manager.CarNumber
                    //....

                    //
                    await _managerRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Update Manager Async id: {managerId} Async. DriverModel {managerModel}");
                    await transaction.RollbackAsync();
                }
            }
            
            return "Driver Information Updated";
        }
    }
}