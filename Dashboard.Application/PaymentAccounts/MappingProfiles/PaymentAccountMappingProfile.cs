using AutoMapper;
using Dashboard.Application.PaymentAccounts.Commands;
using Dashboard.Application.PaymentAccounts.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.PaymentAccounts.MappingProfiles
{
    class PaymentAccountMappingProfile : Profile
    {
        public PaymentAccountMappingProfile()
        {
            CreateMap<PaymentAccount, PaymentAccountVM>();

            CreateMap<PaymentAccountVM, PaymentAccount>();

            CreateMap<CreatePaymentAccountCommand, PaymentAccount>();
        }
    }
}
