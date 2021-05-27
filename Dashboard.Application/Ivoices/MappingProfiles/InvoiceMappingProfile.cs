using AutoMapper;
using Dashboard.Application.Ivoices.Commands;
using Dashboard.Application.Ivoices.ViewModels;
using Dashboard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Application.Ivoices.MappingProfiles
{
    class InvoiceMappingProfile: Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceVM>();
            CreateMap<InvoiceItem, InvoiceItemVM>();

            CreateMap<InvoiceVM, Invoice> ();
            CreateMap<InvoiceItemVM, InvoiceItem>();

            CreateMap<CreateInvoiceCommand, Invoice>();
        }
    }
}
