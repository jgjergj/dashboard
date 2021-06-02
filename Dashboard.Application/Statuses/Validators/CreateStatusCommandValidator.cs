using Dashboard.Application.Statuses.Commands;
using FluentValidation;

namespace Dashboard.Application.Statuses.Validators
{
    public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
    {
        public CreateStatusCommandValidator()
        {
            //todo: checked if there are any validations needed
            //RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
