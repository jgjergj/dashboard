using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Common.Utils;
using Dashboard.Application.Leagues.ViewModels;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Leagues.Queries
{
    public class GetLeaguesQuery : IRequest<IList<LeagueVM>>
    {
        public string FilterBy { get; set; }
        public string Value { get; set; }

        public GetLeaguesQuery(string FilterBy, string Value)            
        {
            this.FilterBy = FilterBy;
            this.Value = Value;
        }
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
            IQueryable<League> leaguesQuery = _context.Leagues.Include(m => m.Sport).Include(m => m.State).AsQueryable();

            if (!string.IsNullOrEmpty(request.FilterBy))
            {
                var predicate = Utils.CreatePredicate<League>(request.FilterBy, request.Value);
                leaguesQuery = leaguesQuery.Where(predicate);
            }

            var leagues = await leaguesQuery.ToListAsync(cancellationToken);


            if (leagues != null)
            {
                result = _mapper.Map<List<LeagueVM>>(leagues);
            }

            return result;
        }
    }
}
