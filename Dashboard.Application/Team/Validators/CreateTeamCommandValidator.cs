using Dashboard.Application.Teams.Commands;
using FluentValidation;

namespace Dashboard.Application.Teams.Validators
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            //RuleFor(v => v.State.Code).MaximumLength(3);
        }
    }
}
