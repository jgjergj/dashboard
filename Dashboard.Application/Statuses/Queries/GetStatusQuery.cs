using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Statuses.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Statuses.Queries
{
    public class GetStatusQuery : IRequest<StatusVM>
    {
        public int Id { get; set; }

        public GetStatusQuery(int id)
        {
            Id = id;
        }
    }

    public class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, StatusVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetStatusQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<StatusVM> Handle(GetStatusQuery request, CancellationToken cancellationToken)
        {
            var result = new StatusVM();
            var Status = await _context.Statuses.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (Status != null)
            {
                result = _mapper.Map<StatusVM>(Status);
            }

            return result;
        }
    }
}
