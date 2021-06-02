using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Statuses.Commands
{
    public class UpdateStatusCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Environment { get; set; }
    }

    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Statuses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Statuses), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.Environment = request.Environment;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
