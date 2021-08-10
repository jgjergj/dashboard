using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.ArbitrageMatches.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Dashboard.Application.ArbitrageMatches.Queries
{
    public class GetArbitrageMatchQuery : IRequest<ArbitrageMatchVM>
    {
        public Guid Id { get; set; }

        public GetArbitrageMatchQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetArbitrageMatchQueryHandler : IRequestHandler<GetArbitrageMatchQuery, ArbitrageMatchVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetArbitrageMatchQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<ArbitrageMatchVM> Handle(GetArbitrageMatchQuery request, CancellationToken cancellationToken)
        {
            var result = new ArbitrageMatchVM();
            var arbitrageMatch = await _context.ArbitrageMatches
                .Include(a => a.Sport)
                .Include(a => a.League)
                .Include(a => a.HomeTeam)
                .Include(a => a.AwayTeam)
                .FirstAsync(s => s.Id == request.Id, cancellationToken);

            if (arbitrageMatch != null)
            {
                result = _mapper.Map<ArbitrageMatchVM>(arbitrageMatch);
            }

            return result;
        }
    }
}
