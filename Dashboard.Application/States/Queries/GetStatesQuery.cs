using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.States.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.States.Queries
{
    public class GetStatesQuery : IRequest<IList<StateVM>>
    {
    }

    public class GetStatesQueryHandler : IRequestHandler<GetStatesQuery, IList<StateVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetStatesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<StateVM>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<StateVM>();
            var states = await _context.States.ToListAsync(cancellationToken);

            if (states != null)
            {
                result = _mapper.Map<List<StateVM>>(states);
            }

            return result;
        }
    }
}
