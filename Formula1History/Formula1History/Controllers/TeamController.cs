using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;

namespace Formula1History.Controllers
{
    [Route("api/team/")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet("team/{id}")]
        public async Task<IActionResult> GetTeamWeekendAsync(Guid id)
        {
            var team = await _teamService.GetTeamAsync(id);
            return Ok(team);
        }

        [HttpGet("team")]
        public async Task<IActionResult> GetAllTeamsWeekendAsync()
        {
            var allTeams = await _teamService.GetAllTeamsAsync();
            return Ok(allTeams);
        }

        [HttpPost("team")]
        public async Task<IActionResult> CreateTeamWeekendAsync(TeamModel team)
        {
            await _teamService.CreateTeamAsync(team);
            return Ok();
        }

        [HttpDelete("team/{id}")]
        public async Task<OkObjectResult> DeleteTeamWeekendAsync(Guid id)
        {
            var result = await _teamService.DeleteTeamAsync(id);
            return Ok(result);
        }

        [HttpPut("team/{id}")]
        public async Task<OkObjectResult> UpdateTeamWeekendAsync(Guid id, TeamModel team)
        {
            var result = await _teamService.UpdateTeamAsync(id, team);
            return Ok(result);
        }
    }
    }
}
