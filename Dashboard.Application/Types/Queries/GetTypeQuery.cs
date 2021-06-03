using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Types.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Types.Queries
{
    public class GetTypeQuery : IRequest<TypeVM>
    {
        public int Id { get; set; }

        public GetTypeQuery(int id)
        {
            Id = id;
        }
    }

    public class GetTypeQueryHandler : IRequestHandler<GetTypeQuery, TypeVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetTypeQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<TypeVM> Handle(GetTypeQuery request, CancellationToken cancellationToken)
        {
            var result = new TypeVM();
            var Type = await _context.Types.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (Type != null)
            {
                result = _mapper.Map<TypeVM>(Type);
            }

            return result;
        }
    }
}
