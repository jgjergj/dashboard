using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Ivoices.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Ivoices.Queries
{
    public class GetUserInvoicesQuery : IRequest<IList<InvoiceVM>>
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
            //var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
            //    .Where(i => i.CreatedBy == request.User).ToListAsync(cancellationToken);

            //if (invoices != null)
            //{
            //    result = _mapper.Map<List<InvoiceVM>>(invoices);
            //}

            return result;
        }
    }
}
