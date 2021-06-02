using AutoMapper;
using Dashboard.Application.States.Commands;
using Dashboard.Application.States.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.States.MappingProfiles
{
    class StateMappingProfile: Profile
    {
        public StateMappingProfile()
        {
            CreateMap<State, StateVM>();

            CreateMap<StateVM, State> ();

            CreateMap<CreateStateCommand, State>();
        }
    }
}
