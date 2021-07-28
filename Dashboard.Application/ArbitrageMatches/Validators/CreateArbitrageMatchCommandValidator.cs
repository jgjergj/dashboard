using Dashboard.Application.ArbitrageMatches.Commands;
using FluentValidation;

namespace Dashboard.Application.ArbitrageMatches.Validators
{
    public class CreateArbitrageMatchCommandValidator : AbstractValidator<CreateArbitrageMatchCommand>
    {
        public CreateArbitrageMatchCommandValidator()
        {
            //todo: see if there are any validations for the client
            //RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
