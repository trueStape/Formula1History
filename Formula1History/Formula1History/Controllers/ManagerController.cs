using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;

namespace Formula1History.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {

        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverAsync(Guid id)
        {
            var manager = await _managerService.GetManagerAsync(id);
            return Ok(manager);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDriversAsync()
        {
            var allDrivers = await _managerService.GetAllManagersAsync();
            return Ok(allDrivers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriverAsync(ManagerModel manager)
        {
            await _managerService.CreateManagerAsync(manager);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<OkObjectResult> DeleteDriverAsync(Guid id)
        {
            var result = await _managerService.DeleteManagerAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<OkObjectResult> UpdateUserAsync(Guid id, ManagerModel manager)
        {
            var result = await _managerService.UpdateManagerAsync(id, manager);
            return Ok(result);
        }
    }
}
