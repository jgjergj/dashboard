using AutoMapper;
using Dashboard.Application.Accounts.Commands;
using Dashboard.Application.Accounts.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Accounts.MappingProfiles
{
    class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Account, AccountVM>();

            CreateMap<AccountVM, Account>();

            CreateMap<CreateAccountCommand, Account>();
            CreateMap<UpdateAccountCommand, Account>();
        }
    }
}
