using AutoMapper;
using Dashboard.Application.Sports.Commands;
using Dashboard.Application.Sports.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Sports.MappingProfiles
{
    class SportMappingProfile : Profile
    {
        public SportMappingProfile()
        {
            CreateMap<Sport, SportVM>();

            CreateMap<SportVM, Sport>();

            CreateMap<CreateSportCommand, Sport>();
        }
    }
}
