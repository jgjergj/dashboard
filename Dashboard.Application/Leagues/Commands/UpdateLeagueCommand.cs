﻿using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Leagues.Commands
{
    public class UpdateLeagueCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int StateId { get; set; }
        public int SportId { get; set; }

    }

    public class UpdateLeagueCommandHandler : IRequestHandler<UpdateLeagueCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateLeagueCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLeagueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Leagues.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Leagues), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.StateId = request.StateId;
            entity.SportId = request.SportId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
