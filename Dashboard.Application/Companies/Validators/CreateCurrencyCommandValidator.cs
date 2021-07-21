using Dashboard.Application.Companies.Commands;
using FluentValidation;

namespace Dashboard.Application.Companies.Validators
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            //RuleFor(v => v.Code).MaximumLength(3);
        }
    }
}
