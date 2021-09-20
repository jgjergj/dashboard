using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Common.Utils;
using Dashboard.Application.Teams.ViewModels;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Teams.Queries
{
    public class GetTeamsQuery : IRequest<IList<TeamVM>>
    {
        public string FilterBy { get; set; }
        public string Value { get; set; }

        public GetTeamsQuery(string FilterBy, string Value)
        {
            this.FilterBy = FilterBy;
            this.Value = Value;
        }
    }

    public class GetTeamsQueryHandler : IRequestHandler<GetTeamsQuery, IList<TeamVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetTeamsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<TeamVM>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<TeamVM>();
            IQueryable<Team> teamsQuery = _context.Teams.Include(m => m.Sport).Include(m => m.State).Include(m => m.League).AsQueryable();

            if (!string.IsNullOrEmpty(request.FilterBy))
            {
                var predicate = Utils.CreatePredicate<Team>(request.FilterBy, request.Value);
                teamsQuery = teamsQuery.Where(predicate);
            } 

            var teams = await teamsQuery.ToListAsync(cancellationToken);

            if (teams != null)
            {
                result = _mapper.Map<List<TeamVM>>(teams);
            }

            return result;
        }

        
    }
}
