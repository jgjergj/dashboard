using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Departments.Commands
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public List<int> Operators{ get; set; }
    }

    public class CreateDepartmentComandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateDepartmentComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Department>(request);

            _context.Departments.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            var operators = _context.Operators.Where(t => request.Operators.Contains(t.Id)).ToList();

            foreach (var operatorObj in operators)
            {
                operatorObj.DepartmentId = entity.Id;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
