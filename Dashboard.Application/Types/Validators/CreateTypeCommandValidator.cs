using Dashboard.Application.Types.Commands;
using FluentValidation;

namespace Dashboard.Application.Types.Validators
{
    public class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
    {
        public CreateTypeCommandValidator()
        {
            //todo: checked if there are any validations needed
            //RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
