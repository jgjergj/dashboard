using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Clients.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Clients.Queries
{
    public class GetClientsQuery : IRequest<IList<ClientVM>>
    {
    }

    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, IList<ClientVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetClientsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<ClientVM>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<ClientVM>();
            var Clients = await _context.Clients.ToListAsync(cancellationToken);

            if (Clients != null)
            {
                result = _mapper.Map<List<ClientVM>>(Clients);
            }

            return result;
        }
    }
}
