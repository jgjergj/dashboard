using AutoMapper;
using Dashboard.Application.Currencies.Commands;
using Dashboard.Application.Currencies.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Currencies.MappingProfiles
{
    class CurrencyMappingProfile : Profile
    {
        public CurrencyMappingProfile()
        {
            CreateMap<Currency, CurrencyVM>();

            CreateMap<CurrencyVM, Currency>();

            CreateMap<CreateCurrencyCommand, Currency>();
        }
    }
}
