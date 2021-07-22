using AutoMapper;
using Dashboard.Application.Departments.Commands;
using Dashboard.Application.Departments.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Departments.MappingProfiles
{
    class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentVM>();

            CreateMap<DepartmentVM, Department>();

            CreateMap<CreateDepartmentCommand, Department>();
        }
    }
}
