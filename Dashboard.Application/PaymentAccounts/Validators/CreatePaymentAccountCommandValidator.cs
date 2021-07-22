using Dashboard.Application.PaymentAccounts.Commands;
using FluentValidation;

namespace Dashboard.Application.PaymentAccounts.Validators
{
    public class CreatePaymentAccountCommandValidator : AbstractValidator<CreatePaymentAccountCommand>
    {
        public CreatePaymentAccountCommandValidator()
        {
            //RuleFor(v => v.State.Code).MaximumLength(3);
        }
    }
}
