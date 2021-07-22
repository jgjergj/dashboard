using Dashboard.Application.Operators.Commands;
using FluentValidation;

namespace Dashboard.Application.Operators.Validators
{
    public class CreateOperatorCommandValidator : AbstractValidator<CreateOperatorCommand>
    {
        public CreateOperatorCommandValidator()
        {
            //RuleFor(v => v.State.Code).MaximumLength(3);
        }
    }
}
