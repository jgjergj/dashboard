using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Sports.ViewModels;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Sports.Queries
{
    public class GetStateSportsQuery : IRequest<IList<SportVM>>
    {
        public int StateId { get; set; }

        public GetStateSportsQuery(int stateId)
        {
            StateId = stateId;
        }
    }

    public class GetStateSportsQueryHandler : IRequestHandler<GetStateSportsQuery, IList<SportVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetStateSportsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<SportVM>> Handle(GetStateSportsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<SportVM>();
            var sports = await _context.Sports
                .Where(sp => sp.StatesSports.Any(ss => ss.StateId == request.StateId))
                .ToListAsync(cancellationToken);

            if (sports != null)
            {
                result = _mapper.Map<List<SportVM>>(sports);
            }

            return result;
        }
    }
}
