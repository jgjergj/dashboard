using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Accounts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Accounts.Queries
{
    public class GetAccountQuery : IRequest<AccountVM>
    {
        public int Id { get; set; }

        public GetAccountQuery(int id)
        {
            Id = id;
        }
    }

    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<AccountVM> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var result = new AccountVM();
            var Account = await _context.Accounts.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (Account != null)
            {
                result = _mapper.Map<AccountVM>(Account);
            }

            return result;
        }
    }
}
