using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities.Team;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository<TeamEntity> _teamRepository;
        private readonly IMapper _mapper;
        public TeamService(ITeamRepository<TeamEntity> teamRepository,
                           IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
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
                catch (Exception)
                {
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
                catch (Exception)
                {
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
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }

            return teamsModel;
        }

        public async Task<string> DeleteTeamAsync(Guid teamId)
        {
            var team = new TeamEntity();
            await using (var transaction = await _teamRepository.AddTransactionAsync())
            {
                try
                {
                    team = await _teamRepository.GetTeamAsync(teamId, x => x.Id == teamId);
                    if (team == null) return "Team is not found";

                    //TODO 8 add delete method for each services
                    await _teamRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
            //TODO 7 add correct return value
            return $"Team: {team.Name}  deleted";
        }

        public async Task<string> UpdateTeamAsync(Guid teamId, TeamModel teamModel)
        {
            await using (var transaction = await _teamRepository.AddTransactionAsync())
            {
                try
                {
                    var team = await _teamRepository.GetTeamAsync(teamId, x => x.Id == teamId);
                    if (team == null) return "Team is not found";

                    //TODO Add model attributes for update driver
                    team.Name = teamModel.Name;
                    //....

                    await _teamRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }

            return "Team Information Updated";
        }
    }
}