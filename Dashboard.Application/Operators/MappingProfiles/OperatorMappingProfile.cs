using AutoMapper;
using Dashboard.Application.Operators.Commands;
using Dashboard.Application.Operators.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Operators.MappingProfiles
{
    class OperatorMappingProfile : Profile
    {
        public OperatorMappingProfile()
        {
            CreateMap<Operator, OperatorVM>();

            CreateMap<OperatorVM, Operator>();

            CreateMap<CreateOperatorCommand, Operator>();
        }
    }
}
