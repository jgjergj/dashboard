using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.ArbitrageMatches.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageMatches.Queries
{
    public class GetArbitrageMatchesQuery : IRequest<IList<ArbitrageMatchVM>>
    {
    }

    public class GetArbitrageMatchesQueryHandler : IRequestHandler<GetArbitrageMatchesQuery, IList<ArbitrageMatchVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetArbitrageMatchesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<ArbitrageMatchVM>> Handle(GetArbitrageMatchesQuery request, CancellationToken cancellationToken)
        {

            var result = new List<ArbitrageMatchVM>();
            var arbitrageMatches = await _context.ArbitrageMatches
                .Include(a => a.State)
                .Include(a => a.Sport)
                .Include(a => a.League)
                .Include(a => a.HomeTeam)
                .Include(a => a.AwayTeam)
                .ToListAsync(cancellationToken);

            if (arbitrageMatches != null)
            {
                result = _mapper.Map<List<ArbitrageMatchVM>>(arbitrageMatches);
            }

            return result;
        }
    }
}
