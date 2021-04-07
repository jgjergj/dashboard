using AutoMapper;
using CleanApp.Application.Ivoices.Commands;
using CleanApp.Application.Ivoices.ViewModels;
using CleanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanApp.Application.Ivoices.MappingProfiles
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
