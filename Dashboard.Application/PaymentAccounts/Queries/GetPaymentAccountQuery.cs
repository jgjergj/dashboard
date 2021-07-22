using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.PaymentAccounts.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.PaymentAccounts.Queries
{
    public class GetPaymentAccountQuery : IRequest<PaymentAccountVM>
    {
        public int Id { get; set; }

        public GetPaymentAccountQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPaymentAccountQueryHandler : IRequestHandler<GetPaymentAccountQuery, PaymentAccountVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetPaymentAccountQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<PaymentAccountVM> Handle(GetPaymentAccountQuery request, CancellationToken cancellationToken)
        {
            var result = new PaymentAccountVM();
            var PaymentAccount = await _context.PaymentAccounts
                .Include(m => m.Company)
                .Include(m => m.State)
                .Include(m => m.Status)
                .FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (PaymentAccount != null)
            {
                result = _mapper.Map<PaymentAccountVM>(PaymentAccount);
            }

            return result;
        }
    }
}
