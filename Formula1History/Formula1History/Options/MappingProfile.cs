using AutoMapper;
using BLL.Models;
using DAL.Entities.Peoples;
using DAL.Entities.Race;
using DAL.Entities.Team;

namespace Formula1History.Options
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<DriverEntity, DriverModel>();
            CreateMap<DriverModel, DriverEntity>();

            CreateMap<ManagerEntity, ManagerModel>();
            CreateMap<ManagerModel, ManagerEntity>();

            CreateMap<RaceWeekendEntity, RaceWeekendModel>();
            CreateMap<RaceWeekendModel, RaceWeekendEntity>();

            CreateMap<RaceYearEntity, RaceYearModel>();
            CreateMap<RaceYearModel, RaceYearEntity>();

            CreateMap<TeamEntity, TeamModel>();
            CreateMap<TeamModel, TeamEntity>();
            
            CreateMap<RacePlace, RacePlaceModel>();
            CreateMap<RacePlaceModel, RacePlace>();

        }
    }
}