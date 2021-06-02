using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Ivoices.ViewModels;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Ivoices.Commands
{
    public class CreateInvoiceCommand : IRequest<int>
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

    public class CreateInvoiceComandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateInvoiceComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Invoice>(request);

            //_context.Invoices.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
