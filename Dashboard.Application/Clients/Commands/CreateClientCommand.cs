using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Clients.Commands
{
    public class CreateClientCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Balance { get; set; }
    }

    public class CreateClientComandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateClientComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Client>(request);

            _context.Clients.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
