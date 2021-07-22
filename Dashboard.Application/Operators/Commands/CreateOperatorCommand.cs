using AutoMapper;
using Dashboard.Application.Clients.ViewModels;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Operators.Commands
{
    public class CreateOperatorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public List<int> Clients { get; set; }
    }

    public class CreateOperatorCommandHandler : IRequestHandler<CreateOperatorCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateOperatorCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateOperatorCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Operator>(request);

            _context.Operators.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            var clients = _context.Clients.Where(t => request.Clients.Contains(t.Id)).ToList();

            foreach (var client in clients)
            {
                client.OperatorId = entity.Id;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
