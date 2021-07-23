using Dashboard.Application.Accounts.Commands;
using FluentValidation;

namespace Dashboard.Application.Accounts.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            //todo: see if there are any validations for the client
            //RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
