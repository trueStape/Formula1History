using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities.Team;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository<TeamEntity> _teamRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TeamService> _logger;
        public TeamService(ITeamRepository<TeamEntity> teamRepository,
                           IMapper mapper,
                           ILogger<TeamService> logger)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateTeamAsync(TeamModel team)
        {
            await using (var transaction = await _teamRepository.AddTransactionAsync())
            {
                try
                {
                    var teamEntity = _mapper.Map<TeamEntity>(team);
                    teamEntity.Id = Guid.NewGuid();

                    await _teamRepository.CreateAsync(teamEntity);
                    await _teamRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during create Team Async.");
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task<TeamModel> GetTeamAsync(Guid teamId)
        {
            var teamModel = new TeamModel();
            await using (var transaction = await _teamRepository.AddTransactionAsync())
            {
                try
                {
                    var teamEntity = await _teamRepository.GetTeamAsync(teamId, x => x.Id == teamId);
                    teamModel = _mapper.Map<TeamModel>(teamEntity);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Get Team id : {teamId} Async.");
                    await transaction.RollbackAsync();
                }
            }

            return teamModel;
        }

        public async Task<List<TeamModel>> GetAllTeamsAsync()
        {
            var teamsModel = new List<TeamModel>();
            await using (var transaction = await _teamRepository.AddTransactionAsync())
            {
                try
                {
                    var teams = await _teamRepository.GetAllTeamsAsync(x => x.Name);
                    teamsModel = _mapper.Map<List<TeamEntity>, List<TeamModel>>(teams);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during Get All Teams Async.");
                    await transaction.RollbackAsync();
                }
            }

            return teamsModel;
        }

        public async Task<string> DeleteTeamAsync(Guid teamId)
        {
            TeamEntity team = null;
            await using (var transaction = await _teamRepository.AddTransactionAsync())
            {
                try
                {
                    team = await _teamRepository.GetTeamAsync(teamId, x => x.Id == teamId);
                    if (team == null) return "Team is not found";

                    _teamRepository.Delete(team);
                    await _teamRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Delete Team id : {teamId} Async.");
                    await transaction.RollbackAsync();
                }
            }
            return team != null ? $"Team: {team.Name}  deleted" : "Team not delete";
        }

        public async Task<string> UpdateTeamAsync(Guid teamId, TeamModel teamModel)
        {
            await using (var transaction = await _teamRepository.AddTransactionAsync())
            {
                try
                {
                    var team = await _teamRepository.GetTeamAsync(teamId, x => x.Id == teamId);
                    if (team == null) return "Team is not found";

                    team.Name = teamModel.Name;
                    team.Description = teamModel.Description;
                    team.NextTeamId = teamModel.NextTeamId;
                    team.YearClose = teamModel.YearClose;
                    team.YearFoundation = teamModel.YearFoundation;

                    await _teamRepository.SaveAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Delete Team id : {teamId} Async. TeamModel {teamModel}");
                    await transaction.RollbackAsync();
                }
            }

            return "Team Information Updated";
        }
    }
}