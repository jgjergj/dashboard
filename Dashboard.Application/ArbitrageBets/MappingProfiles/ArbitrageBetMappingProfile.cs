using AutoMapper;
using Dashboard.Application.ArbitrageBets.Commands;
using Dashboard.Application.ArbitrageBets.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.ArbitrageBets.MappingProfiles
{
    class ArbitrageBetMappingProfile : Profile
    {
        public ArbitrageBetMappingProfile()
        {
            CreateMap<ArbitrageBet, ArbitrageBetVM>();

            CreateMap<ArbitrageBetVM, ArbitrageBet>();

            CreateMap<CreateArbitrageBetCommand, ArbitrageBet>();
            CreateMap<UpdateArbitrageBetCommand, ArbitrageBet>();
        }
    }
}
