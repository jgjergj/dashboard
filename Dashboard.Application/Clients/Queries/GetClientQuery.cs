using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Clients.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Clients.Queries
{
    public class GetClientQuery : IRequest<ClientVM>
    {
        public int Id { get; set; }

        public GetClientQuery(int id)
        {
            Id = id;
        }
    }

    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetClientQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<ClientVM> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var result = new ClientVM();
            var Client = await _context.Clients.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (Client != null)
            {
                result = _mapper.Map<ClientVM>(Client);
            }

            return result;
        }
    }
}
