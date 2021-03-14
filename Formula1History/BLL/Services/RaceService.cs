using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities.Race;
using DAL.Interfaces;

namespace BLL.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository<RaceWeekendEntity> _raceWeekendRepository;
        private readonly IRaceRepository<RaceYearEntity> _raceYearRepository;
        private readonly IMapper _mapper;

        public RaceService(IRaceRepository<RaceWeekendEntity> raceWeekendRepository, 
                           IRaceRepository<RaceYearEntity> raceYearRepository, 
                           IMapper mapper)
        {
            _raceWeekendRepository = raceWeekendRepository;
            _raceYearRepository = raceYearRepository;
            _mapper = mapper;
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
                catch (Exception)
                {
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
                catch (Exception)
                {
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
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }

            return racesModel;
        }

        public async Task<string> DeleteRaceWeekendAsync(Guid raceId)
        {
            var race = new RaceWeekendEntity();
            await using (var transaction = await _raceWeekendRepository.AddTransactionAsync())
            {
                try
                {
                    race = await _raceWeekendRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    if (race == null) return "Race is not found";

                    await _raceWeekendRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
            //TODO 7 add correct return value
            return $"Race: {race.RaceName}  deleted";
        }

        public async Task<string> UpdateRaceWeekendAsync(Guid raceId, RaceWeekendModel raceModel)
        {
            await using (var transaction = await _raceWeekendRepository.AddTransactionAsync())
            {
                try
                {
                    var race = await _raceWeekendRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    if (race == null) return "Race is not found";

                    //TODO Add model attributes for update driver
                    race.RaceName = raceModel.RaceName;
                    //....

                    await _raceWeekendRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
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
                catch (Exception)
                {
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
                catch (Exception)
                {
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
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
           
            return racesModel;
        }

        public async Task<string> DeleteRaceYearAsync(Guid raceId)
        {
            var raceYear = new RaceYearEntity();
            await using (var transaction = await _raceYearRepository.AddTransactionAsync())
            {
                try
                {
                    raceYear = await _raceYearRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    if (raceYear == null) return "Race is not found";

                    await _raceYearRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
            
            //TODO 7 add correct return value
            return $"Race: {raceYear.Year}  deleted";
        }

        public async Task<string> UpdateRaceYearAsync(Guid raceId, RaceYearModel raceModel)
        {
            await using (var transaction = await _raceYearRepository.AddTransactionAsync())
            {
                try
                {
                    var raceYear = await _raceYearRepository.GetRaceAsync(raceId, x => x.Id == raceId);
                    if (raceYear == null) return "Race is not found";

                    //TODO Add model attributes for update driver
                    raceYear.Year = raceModel.Year;
                    //....
                    await _raceYearRepository.SaveAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
            
            return "Race Information Updated";
        }
    }
}