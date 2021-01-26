using CleanApp.Application.Common.Interfaces;
using CleanApp.Application.Ivoices.Queries;
using CleanApp.Application.Ivoices.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApp.Application.Ivoices.Handlers
{
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, IList<InvoiceVM>>
    {
        private readonly IAppDbContext _context;

        public GetUserInvoicesQueryHandler(IAppDbContext context)
        {
            this._context = context;
        }
        public async Task<IList<InvoiceVM>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceVM>();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.User).ToListAsync();

            if(invoices != null)
            {
                result = invoices.Select(i => new InvoiceVM
                {
                    AmountPaid = i.AmountPaid,
                    Date = i.Date,
                    Discount = i.Discount,
                    DiscountType = i.DiscountType,
                    DueDate = i.DueDate,
                    From = i.From,
                    InvoiceNumber = i.InvoiceNumber,
                    Logo = i.Logo,
                    PaymentTerms = i.PaymentTerms,
                    Tax = i.Tax,
                    TaxType = i.TaxType,
                    To = i.To,
                    InvoiceItems = i.InvoiceItems.Select(item => new InvoiceItemVM
                    {
                        Item = item.Item,
                        Quantity = item.Quantity,
                        Rate = item.Rate
                    }).ToList()
                }).ToList();
            }

            return result;
        }
    }
}
