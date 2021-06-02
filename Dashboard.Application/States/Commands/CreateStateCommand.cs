using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.States.Commands
{
    public class CreateStateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class CreateStateComandHandler : IRequestHandler<CreateStateCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateStateComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<State>(request);

            _context.States.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
