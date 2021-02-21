using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IRaceService
    {
        //Race Weekend
        Task CreateRaceWeekendAsync(RaceWeekendModel race);
        Task<RaceWeekendModel> GetRaceWeekendAsync(Guid raceId);
        Task<List<RaceWeekendModel>> GetAllRacesWeekendAsync();
        Task<string> DeleteRaceWeekendAsync(Guid raceId);
        Task<string> UpdateRaceWeekendAsync(Guid raceId, RaceWeekendModel raceModel);

        //Race Year
        Task CreateRaceYearAsync(RaceYearModel race);
        Task<RaceYearModel> GetRaceYearAsync(Guid raceId);
        Task<List<RaceYearModel>> GetAllRacesYearAsync();
        Task<string> DeleteRaceYearAsync(Guid raceId);
        Task<string> UpdateRaceYearAsync(Guid raceId, RaceYearModel raceModel);
    }
}