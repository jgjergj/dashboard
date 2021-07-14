using Dashboard.Application.Leagues.Commands;
using FluentValidation;

namespace Dashboard.Application.Leagues.Validators
{
    public class CreateLeagueCommandValidator : AbstractValidator<CreateLeagueCommand>
    {
        public CreateLeagueCommandValidator()
        {
            //RuleFor(v => v.State.Code).MaximumLength(3);
        }
    }
}
