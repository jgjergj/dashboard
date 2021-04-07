using AutoMapper;
using CleanApp.Application.Common.Interfaces;
using CleanApp.Application.Ivoices.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApp.Application.Ivoices.Queries
{
    public class GetUserInvoicesQuery: IRequest<IList<InvoiceVM>>
    {
        public string User { get; set; }
    }

    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, IList<InvoiceVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetUserInvoicesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<InvoiceVM>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceVM>();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.User).ToListAsync();

            if (invoices != null)
            {
                result = _mapper.Map<List<InvoiceVM>>(invoices);
            }

            return result;
        }
    }
}
