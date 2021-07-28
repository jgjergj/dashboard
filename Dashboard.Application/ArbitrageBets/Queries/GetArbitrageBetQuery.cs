using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.ArbitrageBets.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageBets.Queries
{
    public class GetArbitrageBetQuery : IRequest<ArbitrageBetVM>
    {
        public int Id { get; set; }

        public GetArbitrageBetQuery(int id)
        {
            Id = id;
        }
    }

    public class GetArbitrageBetQueryHandler : IRequestHandler<GetArbitrageBetQuery, ArbitrageBetVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetArbitrageBetQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<ArbitrageBetVM> Handle(GetArbitrageBetQuery request, CancellationToken cancellationToken)
        {
            var result = new ArbitrageBetVM();
            var arbitrageBet = await _context.ArbitrageBets
                .Include(a => a.Company)
                .Include(a => a.Account)
                .Include(a => a.Status)
                .Include(a => a.Type)
                .FirstAsync(s => s.Id == request.Id, cancellationToken); // ToListAsync(cancellationToken);

            if (arbitrageBet != null)
            {
                result = _mapper.Map<ArbitrageBetVM>(arbitrageBet);
            }

            return result;
        }
    }
}
