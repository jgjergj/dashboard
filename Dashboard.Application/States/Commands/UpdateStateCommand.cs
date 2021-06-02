using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.States.Commands
{
    public class UpdateStateCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateStateCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.States.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(States), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.Code = request.Code;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
