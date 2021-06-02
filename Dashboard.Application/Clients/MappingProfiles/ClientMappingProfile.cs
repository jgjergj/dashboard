using AutoMapper;
using Dashboard.Application.Clients.Commands;
using Dashboard.Application.Clients.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Clients.MappingProfiles
{
    class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Client, ClientVM>();

            CreateMap<ClientVM, Client>();

            CreateMap<CreateClientCommand, Client>();
        }
    }
}
