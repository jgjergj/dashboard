using Dashboard.Application.Clients.Commands;
using FluentValidation;

namespace Dashboard.Application.Clients.Validators
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            //todo: see if there are any validations for the client
            //RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
