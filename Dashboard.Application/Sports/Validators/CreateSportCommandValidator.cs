using Dashboard.Application.Sports.Commands;
using FluentValidation;

namespace Dashboard.Application.Sports.Validators
{
    public class CreateSportCommandValidator : AbstractValidator<CreateSportCommand>
    {
        public CreateSportCommandValidator()
        {
            //todo: see if there are any validations for the Sport
            //RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
