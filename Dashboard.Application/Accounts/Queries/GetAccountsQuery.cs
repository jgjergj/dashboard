using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Accounts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Accounts.Queries
{
    public class GetAccountsQuery : IRequest<IList<AccountVM>>
    {
    }

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, IList<AccountVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<AccountVM>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<AccountVM>();
            var Accounts = await _context.Accounts
                .Include(a => a.Company)
                .Include(a => a.Currency)
                .Include(a => a.Status)
                .Include(a => a.Type)
                .Include(a => a.State)
                .Include(a => a.Operator)
                .Include(a => a.PaymentAccount)
                .ToListAsync(cancellationToken);

            if (Accounts != null)
            {
                result = _mapper.Map<List<AccountVM>>(Accounts);
            }

            return result;
        }
    }
}
