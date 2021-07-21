using AutoMapper;
using Dashboard.Application.Teams.Commands;
using Dashboard.Application.Teams.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Teams.MappingProfiles
{
    class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<Team, TeamVM>();

            CreateMap<TeamVM, Team>();

            CreateMap<CreateTeamCommand, Team>();
        }
    }
}
