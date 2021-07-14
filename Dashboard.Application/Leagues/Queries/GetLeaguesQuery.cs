using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Leagues.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Leagues.Queries
{
    public class GetLeaguesQuery : IRequest<IList<LeagueVM>>
    {
    }

    public class GetLeaguesQueryHandler : IRequestHandler<GetLeaguesQuery, IList<LeagueVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetLeaguesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<LeagueVM>> Handle(GetLeaguesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<LeagueVM>();
            var Leagues = await _context.Leagues.ToListAsync(cancellationToken);

            if (Leagues != null)
            {
                result = _mapper.Map<List<LeagueVM>>(Leagues);
            }

            return result;
        }
    }
}
