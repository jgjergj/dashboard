using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.PaymentAccounts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.PaymentAccounts.Queries
{
    public class GetPaymentAccountsQuery : IRequest<IList<PaymentAccountVM>>
    {
    }

    public class GetPaymentAccountsQueryHandler : IRequestHandler<GetPaymentAccountsQuery, IList<PaymentAccountVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetPaymentAccountsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<PaymentAccountVM>> Handle(GetPaymentAccountsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<PaymentAccountVM>();
            var PaymentAccounts = await _context.PaymentAccounts
                .Include(m => m.Company)
                .Include(m => m.State)
                .Include(m => m.Status)
                .ToListAsync(cancellationToken);

            if (PaymentAccounts != null)
            {
                result = _mapper.Map<List<PaymentAccountVM>>(PaymentAccounts);
            }

            return result;
        }
    }
}
