using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Operators.Commands
{
    public class UpdateOperatorCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        //public List<int> Clients { get; set; }

    }

    public class UpdateOperatorCommandHandler : IRequestHandler<UpdateOperatorCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateOperatorCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateOperatorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Operators.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Operators), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.Balance = request.Balance;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
