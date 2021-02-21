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
            var raceWeekend = _mapper.Map<RaceWeekendEntity>(race);
            raceWeekend.Id = Guid.NewGuid();

            await _raceWeekendRepository.CreateAsync(raceWeekend);
            await _raceWeekendRepository.SaveAsync();
        }

        public async Task<RaceWeekendModel> GetRaceWeekendAsync(Guid raceId)
        {
            var raceEntity = await _raceWeekendRepository.GetRaceAsync(raceId, x => x.Id == raceId);
            var raceModel = _mapper.Map<RaceWeekendModel>(raceEntity);

            return raceModel;
        }

        public async Task<List<RaceWeekendModel>> GetAllRacesWeekendAsync()
        {
            var races = await _raceWeekendRepository.GetAllRaceAsync(x => x.RaceName);
            var racesModel = _mapper.Map<List<RaceWeekendEntity>, List<RaceWeekendModel>>(races);

            return racesModel;
        }

        public async Task<string> DeleteRaceWeekendAsync(Guid raceId)
        {
            var race = await _raceWeekendRepository.GetRaceAsync(raceId, x => x.Id == raceId);
            if (race == null) return "Race is not found";

            await _raceWeekendRepository.SaveAsync();

            return $"Race: {race.RaceName}  deleted";
        }

        public async Task<string> UpdateRaceWeekendAsync(Guid raceId, RaceWeekendModel raceModel)
        {
            var race = await _raceWeekendRepository.GetRaceAsync(raceId, x => x.Id == raceId);
            if (race == null) return "Race is not found";

            //TODO Add model attributes for update driver
            race.RaceName = raceModel.RaceName;
            //....
           
            await _raceWeekendRepository.SaveAsync();

            return "Race Information Updated";
        }


        //Race Year
        public async Task CreateRaceYearAsync(RaceYearModel race)
        {
            var raceYear = _mapper.Map<RaceYearEntity>(race);
            raceYear.Id = Guid.NewGuid();

            await _raceYearRepository.CreateAsync(raceYear);
            await _raceYearRepository.SaveAsync();
        }

        public async Task<RaceYearModel> GetRaceYearAsync(Guid raceId)
        {
            var raceEntity = await _raceYearRepository.GetRaceAsync(raceId, x => x.Id == raceId);
            var raceModel = _mapper.Map<RaceYearModel>(raceEntity);

            return raceModel;
        }

        public async Task<List<RaceYearModel>> GetAllRacesYearAsync()
        {
            var raceYears = await _raceYearRepository.GetAllRaceAsync(x => x.Year);
            var racesModel = _mapper.Map<List<RaceYearEntity>, List<RaceYearModel>>(raceYears);

            return racesModel;
        }

        public async Task<string> DeleteRaceYearAsync(Guid raceId)
        {
            var raceYear = await _raceYearRepository.GetRaceAsync(raceId, x => x.Id == raceId);
            if (raceYear == null) return "Race is not found";

            await _raceYearRepository.SaveAsync();

            return $"Race: {raceYear.Year}  deleted";
        }

        public async Task<string> UpdateRaceYearAsync(Guid raceId, RaceYearModel raceModel)
        {
            var raceYear = await _raceYearRepository.GetRaceAsync(raceId, x => x.Id == raceId);
            if (raceYear == null) return "Race is not found";

            //TODO Add model attributes for update driver
            raceYear.Year = raceModel.Year;
            //....

            await _raceYearRepository.SaveAsync();

            return "Race Information Updated";
        }
    }
}