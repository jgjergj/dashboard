using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Departments.Commands
{
    public class UpdateDepartmentCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Balance { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateDepartmentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Departments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Departments), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.Balance = request.Balance;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
