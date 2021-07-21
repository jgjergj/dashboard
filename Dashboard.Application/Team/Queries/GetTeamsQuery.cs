using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Teams.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Teams.Queries
{
    public class GetTeamsQuery : IRequest<IList<TeamVM>>
    {
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
            var Teams = await _context.Teams.Include(m => m.Sport).Include(m => m.State).Include(m => m.League).ToListAsync(cancellationToken);

            if (Teams != null)
            {
                result = _mapper.Map<List<TeamVM>>(Teams);
            }

            return result;
        }
    }
}
