using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Teams.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Teams.Queries
{
    public class GetTeamQuery : IRequest<TeamVM>
    {
        public int Id { get; set; }

        public GetTeamQuery(int id)
        {
            Id = id;
        }
    }

    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, TeamVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetTeamQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<TeamVM> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var result = new TeamVM();
            var Team = await _context.Teams.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (Team != null)
            {
                result = _mapper.Map<TeamVM>(Team);
            }

            return result;
        }
    }
}
