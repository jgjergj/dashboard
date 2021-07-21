using AutoMapper;
using Dashboard.Application.Companies.Commands;
using Dashboard.Application.Companies.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Companies.MappingProfiles
{
    class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyVM>();

            CreateMap<CompanyVM, Company>();

            CreateMap<CreateCompanyCommand, Company>();
        }
    }
}
