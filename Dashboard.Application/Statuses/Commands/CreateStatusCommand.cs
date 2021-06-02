using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Statuses.Commands
{
    public class CreateStatusCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Environment { get; set; }
    }

    public class CreateStatusComandHandler : IRequestHandler<CreateStatusCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateStatusComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Status>(request);

            _context.Statuses.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
