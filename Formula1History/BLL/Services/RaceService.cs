using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities.Race;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository<RaceWeekendEntity> _raceWeekendRepository;
        private readonly IRaceRepository<RaceYearEntity> _raceYearRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RaceService> _logger;

        public RaceService(IRaceRepository<RaceWeekendEntity> raceWeekendRepository, 
                           IRaceRepository<RaceYearEntity> raceYearRepository, 
                           IMapper mapper,
                           ILogger<RaceService> logger)
        {
            _raceWeekendRepository = raceWeekendRepository;
            _raceYearRepository = raceYearRepository;
            _mapper = mapper;
            _logger = logger;
        }


        //Race Weekend
        public async Task CreateRaceWeekendAsync(RaceWeekendModel race)
        {
            await using (var transaction = await _raceWeekendRepository.AddTransactionAsync())
            {
                try
                {
                    var raceWeekend = _mapper.Map<RaceWeekendEntity>(race);
                    raceWeekend.Id = Guid.NewGuid();

                    await _raceWeekendRepository.CreateAsync(raceWeekend);
                    await _raceWeekendRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Race Weekend Async. RaceWeekendModel {race}");
                    await transaction.RollbackAsync();
                }
            }
           
        }

        public async Task<RaceWeekendModel> GetRaceWeekendAsync(Guid raceId)
        {
            var raceModel = new RaceWeekendModel();
            await using (var transaction = await _raceWeekendRepository.AddTransactionAsync())
            {
                try
                {
                    var raceEntity = await _raceWeekendRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    raceModel = _mapper.Map<RaceWeekendModel>(raceEntity);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during  Get Race Weekend id: {raceId} Async.");
                    await transaction.RollbackAsync();
                }
            }
            
            return raceModel;
        }

        public async Task<List<RaceWeekendModel>> GetAllRacesWeekendAsync()
        {
            var racesModel = new List<RaceWeekendModel>();
            await using (var transaction = await _raceWeekendRepository.AddTransactionAsync())
            {
                try
                {
                    var races = await _raceWeekendRepository.GetAllRaceAsync(x => x.RaceName);
                    racesModel = _mapper.Map<List<RaceWeekendEntity>, List<RaceWeekendModel>>(races);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during  Get All Races Weekend Async.");
                    await transaction.RollbackAsync();
                }
            }

            return racesModel;
        }

        public async Task<string> DeleteRaceWeekendAsync(Guid raceId)
        {
            RaceWeekendEntity race = null;
            await using (var transaction = await _raceWeekendRepository.AddTransactionAsync())
            {
                try
                {
                    race = await _raceWeekendRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    if (race == null) return "Race is not found";
                    _raceWeekendRepository.Delete(race);
                    await _raceWeekendRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Delete Manager id: {raceId} Async.");
                    await transaction.RollbackAsync();
                }
            }
            return race != null ? $"Race: {race.RaceName}  deleted" : "Race weekend not delete";
        }

        public async Task<string> UpdateRaceWeekendAsync(Guid raceId, RaceWeekendModel raceModel)
        {
            await using (var transaction = await _raceWeekendRepository.AddTransactionAsync())
            {
                try
                {
                    var race = await _raceWeekendRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    if (race == null) return "Race is not found";

                    race.RaceName = raceModel.RaceName;
                    race.Country = raceModel.Country;
                    race.Descriptions = raceModel.Descriptions;
                    race.StartWeekend = raceModel.StartWeekend;
                    race.FinishWeekend = raceModel.FinishWeekend;
                    race.RaceYearEntityId = raceModel.RaceYearEntityId;

                    await _raceWeekendRepository.SaveAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Update Race Weekend Async id: {raceId} Async. RaceWeekendModel {raceModel}");
                    await transaction.RollbackAsync();
                }
            }
            
            return "Race Information Updated";
        }


        //Race Year
        public async Task CreateRaceYearAsync(RaceYearModel race)
        {
            await using (var transaction = await _raceYearRepository.AddTransactionAsync())
            {
                try
                {
                    var raceYear = _mapper.Map<RaceYearEntity>(race);
                    raceYear.Id = Guid.NewGuid();

                    await _raceYearRepository.CreateAsync(raceYear);
                    await _raceYearRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Create Race Year Async. RaceYearModel {race}");
                    await transaction.RollbackAsync();
                }
            }
        }

        public async Task<RaceYearModel> GetRaceYearAsync(Guid raceId)
        {
            var raceModel = new RaceYearModel();
            await using (var transaction = await _raceYearRepository.AddTransactionAsync())
            {
                try
                {
                    var raceEntity = await _raceYearRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    raceModel = _mapper.Map<RaceYearModel>(raceEntity);
                    
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during  Get Race Year id: {raceId} Async.");
                    await transaction.RollbackAsync();
                }
            }
         
            return raceModel;
        }

        public async Task<List<RaceYearModel>> GetAllRacesYearAsync()
        {
            var racesModel = new List<RaceYearModel>();
            await using (var transaction = await _raceYearRepository.AddTransactionAsync())
            {
                try
                {
                    var raceYears = await _raceYearRepository.GetAllRaceAsync(x => x.Year);
                    racesModel = _mapper.Map<List<RaceYearEntity>, List<RaceYearModel>>(raceYears);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during  Get All Races Year Async.");
                    await transaction.RollbackAsync();
                }
            }
           
            return racesModel;
        }

        public async Task<string> DeleteRaceYearAsync(Guid raceId)
        {
            RaceYearEntity raceYear = null;
            await using (var transaction = await _raceYearRepository.AddTransactionAsync())
            {
                try
                {
                    raceYear = await _raceYearRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    if (raceYear == null) return "Race is not found";
                    _raceYearRepository.Delete(raceYear);
                    await _raceYearRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Delete Race Year id: {raceId} Async.");
                    await transaction.RollbackAsync();
                }
            }
            
            return raceYear != null ? $"Race: {raceYear.Year}  deleted" : "Race year not delete";
        }

        public async Task<string> UpdateRaceYearAsync(Guid raceId, RaceYearModel raceModel)
        {
            await using (var transaction = await _raceYearRepository.AddTransactionAsync())
            {
                try
                {
                    var raceYear = await _raceYearRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    if (raceYear == null) return "Race is not found";

                    raceYear.Year = raceModel.Year;

                    await _raceYearRepository.SaveAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error during Update RaceYear Async id: {raceId} Async. DriverModel {raceModel}");
                    await transaction.RollbackAsync();
                }
            }
            
            return "Race Information Updated";
        }
    }
}