using Dashboard.Application.Departments.Commands;
using FluentValidation;

namespace Dashboard.Application.Departments.Validators
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            //RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
