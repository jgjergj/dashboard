using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Accounts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Dashboard.Domain.Entities;
using Dashboard.Application.Common.Utils;

namespace Dashboard.Application.Accounts.Queries
{
    public class GetAccountsQuery : IRequest<IList<AccountVM>>
    {
        public string FilterBy { get; set; }
        public string Value { get; set; }

        public GetAccountsQuery(string FilterBy, string Value)
        {
            this.FilterBy = FilterBy;
            this.Value = Value;
        }
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

            IQueryable<Account> accountsQuery = _context.Accounts
                .Include(a => a.Company)
                .Include(a => a.Currency)
                .Include(a => a.Status)
                .Include(a => a.Type)
                .Include(a => a.State)
                .Include(a => a.Operator)
                .Include(a => a.PaymentAccount)
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.FilterBy))
            {
                var predicate = Utils.CreatePredicate<Account>(request.FilterBy, request.Value);
                accountsQuery = accountsQuery.Where(predicate);
            }

            var accounts = await accountsQuery.ToListAsync(cancellationToken);

            if (accounts != null)
            {
                result = _mapper.Map<List<AccountVM>>(accounts);
            }

            return result;
        }
    }
}
