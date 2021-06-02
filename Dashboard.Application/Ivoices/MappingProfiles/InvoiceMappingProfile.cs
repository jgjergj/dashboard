using AutoMapper;
using Dashboard.Application.Ivoices.Commands;
using Dashboard.Application.Ivoices.ViewModels;
using Dashboard.Domain.Entities;

namespace Dashboard.Application.Ivoices.MappingProfiles
{
    class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceVM>();
            CreateMap<InvoiceItem, InvoiceItemVM>();

            CreateMap<InvoiceVM, Invoice>();
            CreateMap<InvoiceItemVM, InvoiceItem>();

            CreateMap<CreateInvoiceCommand, Invoice>();
        }
    }
}
