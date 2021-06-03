using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Types.Commands
{
    public class CreateTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Environment { get; set; }
    }

    public class CreateTypeComandHandler : IRequestHandler<CreateTypeCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateTypeComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Type>(request);

            _context.Types.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
