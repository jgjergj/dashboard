using AutoMapper;
using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageBets.Commands
{
    public class UpdateArbitrageBetStatusCommand : IRequest
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

    public class UpdateArbitrageBetStatusCommandHandler : IRequestHandler<UpdateArbitrageBetStatusCommand>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateArbitrageBetStatusCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateArbitrageBetStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ArbitrageBets.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ArbitrageBets), request.Id);
            }

            var status = _context.Statuses.FirstOrDefault(s => s.Name == request.Status);

            //todo: add this new exception
            //if (status == null)
            //{
            //    //throw new StatusNotFoundException();
            //}

            entity.Status = status;

            //_mapper.Map(request, entity);            

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
