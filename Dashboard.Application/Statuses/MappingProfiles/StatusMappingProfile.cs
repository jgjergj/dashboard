using AutoMapper;
using Dashboard.Application.Statuses.Commands;
using Dashboard.Application.Statuses.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Statuses.MappingProfiles
{
    class StatusMappingProfile : Profile
    {
        public StatusMappingProfile()
        {
            CreateMap<Status, StatusVM>();

            CreateMap<StatusVM, Status>();

            CreateMap<CreateStatusCommand, Status>();
        }
    }
}
