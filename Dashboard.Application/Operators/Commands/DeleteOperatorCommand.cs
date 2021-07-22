using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Operators.Commands
{
    public class DeleteOperatorCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteOperatorCommandHandler : IRequestHandler<DeleteOperatorCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteOperatorCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteOperatorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Operators
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Operator), request.Id);
            }
            
            var clients = _context.Clients.Where(c => c.OperatorId == entity.Id).ToList();
            foreach (var client in clients)
            {
                client.OperatorId = 0;
            }

            _context.Operators.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
