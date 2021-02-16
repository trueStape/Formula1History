using AutoMapper;
using BLL.Models;
using DAL.Entities.Peoples;

namespace Formula1History.Options
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<DriverEntity, DriverModel>();
            CreateMap<DriverModel, DriverEntity>();
        }
    }
}