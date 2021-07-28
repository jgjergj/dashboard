using AutoMapper;
using Dashboard.Application.ArbitrageMatches.Commands;
using Dashboard.Application.ArbitrageMatches.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.ArbitrageMatches.MappingProfiles
{
    class ArbitrageMatchMappingProfile : Profile
    {
        public ArbitrageMatchMappingProfile()
        {
            CreateMap<ArbitrageMatch, ArbitrageMatchVM>();

            CreateMap<ArbitrageMatchVM, ArbitrageMatch>();

            CreateMap<CreateArbitrageMatchCommand, ArbitrageMatch>();
            CreateMap<UpdateArbitrageMatchCommand, ArbitrageMatch>();
        }
    }
}
