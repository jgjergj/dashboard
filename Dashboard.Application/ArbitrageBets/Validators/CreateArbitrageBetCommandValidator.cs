using Dashboard.Application.ArbitrageBets.Commands;
using FluentValidation;

namespace Dashboard.Application.ArbitrageBets.Validators
{
    public class CreateArbitrageBetCommandValidator : AbstractValidator<CreateArbitrageBetCommand>
    {
        public CreateArbitrageBetCommandValidator()
        {
            //todo: see if there are any validations for the client
            //RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
