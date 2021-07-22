using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Operators.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Operators.Queries
{
    public class GetOperatorQuery : IRequest<OperatorVM>
    {
        public int Id { get; set; }

        public GetOperatorQuery(int id)
        {
            Id = id;
        }
    }

    public class GetOperatorQueryHandler : IRequestHandler<GetOperatorQuery, OperatorVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetOperatorQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<OperatorVM> Handle(GetOperatorQuery request, CancellationToken cancellationToken)
        {
            var result = new OperatorVM();
            var Operator = await _context.Operators.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (Operator != null)
            {
                result = _mapper.Map<OperatorVM>(Operator);
            }

            return result;
        }
    }
}
