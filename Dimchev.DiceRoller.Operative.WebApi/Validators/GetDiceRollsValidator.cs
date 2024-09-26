using Dimchev.DiceRoller.Operative.Core.Dtos;
using FluentValidation;

namespace Dimchev.DiceRoller.Operative.WebApi.Validators
{
    public class GetDiceRollsValidator : AbstractValidator<GetDiceRollsRequest>
    {
        private readonly string[] allowedSortValues = { "Sum", "Date", "SumAndDate" };

        public GetDiceRollsValidator()
        {
            RuleFor(request => request.SortBy)
            .NotEmpty().WithMessage("SortBy is required.")
            .Must(value => allowedSortValues.Contains(value))
            .WithMessage($"SortBy must be one of the following values: {string.Join(", ", allowedSortValues)}");
        }
    }
}
