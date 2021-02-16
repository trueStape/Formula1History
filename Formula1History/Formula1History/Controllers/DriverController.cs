using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;

namespace Formula1History.Controllers
{
    [Route("api/driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverAsync(Guid id)
        {
            var driver = await _driverService.GetDriverAsync(id);
            return Ok(driver);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDriversAsync()
        {
            var allDrivers = await _driverService.GetAllDriversAsync();
            return Ok(allDrivers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriverAsync(DriverModel driver)
        {
            await _driverService.CreateDriverAsync(driver);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<OkObjectResult> DeleteDriverAsync(Guid id)
        {
            var result = await _driverService.DeleteDriverAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<OkObjectResult> UpdateUserAsync(Guid id, DriverModel driver)
        {
            var result = await _driverService.UpdateDriverAsync(id, driver);
            return Ok(result);
        }
    }
}
