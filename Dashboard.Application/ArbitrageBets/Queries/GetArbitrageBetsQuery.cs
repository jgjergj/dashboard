using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.ArbitrageBets.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageBets.Queries
{
    public class GetArbitrageBetsQuery : IRequest<IList<ArbitrageBetVM>>
    {
    }

    public class GetArbitrageBetsQueryHandler : IRequestHandler<GetArbitrageBetsQuery, IList<ArbitrageBetVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetArbitrageBetsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<ArbitrageBetVM>> Handle(GetArbitrageBetsQuery request, CancellationToken cancellationToken)
        {

            var result = new List<ArbitrageBetVM>();
            var arbitrageBets = await _context.ArbitrageBets
                .Include(a => a.Company)
                .Include(a => a.Account)
                .Include(a => a.Status)
                .Include(a => a.Type)
                .ToListAsync(cancellationToken);

            if (arbitrageBets != null)
            {
                result = _mapper.Map<List<ArbitrageBetVM>>(arbitrageBets);
            }

            return result;
        }
    }
}
