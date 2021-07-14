using AutoMapper;
using Dashboard.Application.Leagues.Commands;
using Dashboard.Application.Leagues.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Leagues.MappingProfiles
{
    class LeagueMappingProfile : Profile
    {
        public LeagueMappingProfile()
        {
            CreateMap<League, LeagueVM>();

            CreateMap<LeagueVM, League>();

            CreateMap<CreateLeagueCommand, League>();
        }
    }
}
