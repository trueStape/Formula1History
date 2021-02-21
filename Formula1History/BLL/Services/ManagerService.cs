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
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public ManagerService(IManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }
        public async Task CreateManagerAsync(ManagerModel manager)
        {
            var managerEntity = _mapper.Map<ManagerEntity>(manager);
            managerEntity.Id = Guid.NewGuid();

            await _managerRepository.CreateAsync(managerEntity);
            await _managerRepository.SaveAsync();
        }

        public async Task<ManagerModel> GetManagerAsync(Guid managerId)
        {
            var managerEntity = await _managerRepository.GetPeopleAsync(managerId, x => x.Id == managerId);
            var managerModel = _mapper.Map<ManagerModel>(managerEntity);

            return managerModel;
        }

        public async Task<List<ManagerModel>> GetAllManagersAsync()
        {
            var managers = await _managerRepository.GetAllPeopleAsync(x => x.LastName);
            var managerModels = _mapper.Map<List<ManagerEntity>, List<ManagerModel>>(managers);

            return managerModels;
        }

        public async Task<string> DeleteManagerAsync(Guid managerId)
        {
            var manager = await _managerRepository.GetPeopleAsync(managerId, x => x.Id == managerId);
            if (manager == null) return "Driver is not found";

            await _managerRepository.SaveAsync();

            return $"Driver: {manager.LastName} {manager.Name} deleted";
        }

        public async Task<string> UpdateManagerAsync(Guid managerId, ManagerModel managerModel)
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

            return "Driver Information Updated";
        }
    }
}