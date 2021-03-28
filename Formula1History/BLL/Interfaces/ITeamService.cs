using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ITeamService
    {
        Task CreateTeamAsync(TeamModel team);
        Task<TeamModel> GetTeamAsync(Guid teamId);
        Task<List<TeamModel>> GetAllTeamsAsync();
        Task<string> DeleteTeamAsync(Guid teamId);
        Task<string> UpdateTeamAsync(Guid teamId, TeamModel teamModel);
    }
}