using AutoMapper;
using Dashboard.Application.Types.Commands;
using Dashboard.Application.Types.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Types.MappingProfiles
{
    class TypeMappingProfile : Profile
    {
        public TypeMappingProfile()
        {
            CreateMap<Type, TypeVM>();

            CreateMap<TypeVM, Type>();

            CreateMap<CreateTypeCommand, Type>();
        }
    }
}
