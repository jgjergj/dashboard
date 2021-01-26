using CleanApp.Application.Ivoices.ViewModels;
using CleanApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace CleanApp.Application.Ivoices.Commands
{
    public class CreateInvoiceCommand: IRequest<int>
    {
        public CreateInvoiceCommand()
        {
            this.InvoiceItems = new List<InvoiceItemVM>();
        }
        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime DueDate { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Tax { get; set; }
        public TaxType TaxType { get; set; }
        public double Amount { get; set; }
        public double AmountPaid { get; set; }
        public List<InvoiceItemVM> InvoiceItems { get; set; }
    }
}
