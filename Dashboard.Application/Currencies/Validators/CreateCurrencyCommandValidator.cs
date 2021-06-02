using Dashboard.Application.Currencies.Commands;
using FluentValidation;

namespace Dashboard.Application.Currencies.Validators
{
    public class CreateCurrencyCommandValidator : AbstractValidator<CreateCurrencyCommand>
    {
        public CreateCurrencyCommandValidator()
        {
            RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
