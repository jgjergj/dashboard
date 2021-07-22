using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.PaymentAccounts.Commands
{
    public class CreatePaymentAccountCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int StateId { get; set; }
        public int StatusId { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DocumentExpiry { get; set; }

    }

    public class CreatePaymentAccountCommandHandler : IRequestHandler<CreatePaymentAccountCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreatePaymentAccountCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreatePaymentAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PaymentAccount>(request);

            _context.PaymentAccounts.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
