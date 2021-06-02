using Dashboard.Application.States.Commands;
using FluentValidation;

namespace Dashboard.Application.States.Validators
{
    public class CreateStateCommandValidator : AbstractValidator<CreateStateCommand>
    {
        public CreateStateCommandValidator()
        {
            RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
