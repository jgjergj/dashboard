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
    public class GetStateQuery: IRequest<StateVM>
    {
        public int Id { get; set; }

        public GetStateQuery(int id)
        {
            Id = id;
        }
    }

    public class GetStateQueryHandler : IRequestHandler<GetStateQuery, StateVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetStateQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<StateVM> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            var result = new StateVM();
            var state = await _context.States.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (state != null)
            {
                result = _mapper.Map<StateVM>(state);
            }

            return result;
        }
    }
}
