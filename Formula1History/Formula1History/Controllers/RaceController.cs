using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;

namespace Formula1History.Controllers
{
    [Route("api/race/")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceService _raceService;

        public RaceController(IRaceService raceService)
        {
            _raceService = raceService;
        }
        
        //Race Weekend
        [HttpGet("weekend/{id}")]
        public async Task<IActionResult> GetRaceWeekendAsync(Guid id)
        {
            var race = await _raceService.GetRaceWeekendAsync(id);
            return Ok(race);
        }

        [HttpGet("weekend")]
        public async Task<IActionResult> GetAllRacesWeekendAsync()
        {
            var allRaces = await _raceService.GetAllRacesWeekendAsync();
            return Ok(allRaces);
        }

        [HttpPost("weekend")]
        public async Task<IActionResult> CreateRaceWeekendAsync(RaceWeekendModel driver)
        {
            await _raceService.CreateRaceWeekendAsync(driver);
            return Ok();
        }

        [HttpDelete("weekend/{id}")]
        public async Task<OkObjectResult> DeleteRaceWeekendAsync(Guid id)
        {
            var result = await _raceService.DeleteRaceWeekendAsync(id);
            return Ok(result);
        }

        [HttpPut("weekend/{id}")]
        public async Task<OkObjectResult> UpdateRaceWeekendAsync(Guid id, RaceWeekendModel race)
        {
            var result = await _raceService.UpdateRaceWeekendAsync(id, race);
            return Ok(result);
        }


        //Race Year
        [HttpGet("year/{id}")]
        public async Task<IActionResult> GetRaceYearAsync(Guid id)
        {
            var race = await _raceService.GetRaceYearAsync(id);
            return Ok(race);
        }

        [HttpGet("year")]
        public async Task<IActionResult> GetAllRaceYearsAsync()
        {
            var allRaces = await _raceService.GetAllRacesYearAsync();
            return Ok(allRaces);
        }

        [HttpPost("year")]
        public async Task<IActionResult> CreateRaceYearAsync(RaceYearModel race)
        {
            await _raceService.CreateRaceYearAsync(race);
            return Ok();
        }

        [HttpDelete("year/{id}")]
        public async Task<OkObjectResult> DeleteRaceYearAsync(Guid id)
        {
            var result = await _raceService.DeleteRaceYearAsync(id);
            return Ok(result);
        }

        [HttpPut("year/{id}")]
        public async Task<OkObjectResult> UpdateRaceYearAsync(Guid id, RaceYearModel race)
        {
            var result = await _raceService.UpdateRaceYearAsync(id, race);
            return Ok(result);
        }
    }
}
