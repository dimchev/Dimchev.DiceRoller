using Dimchev.DiceRoller.Operative.Core.Dtos;
using FluentValidation;

namespace Dimchev.DiceRoller.Operative.WebApi.Validators
{
    public class GetDiceRollsValidator : AbstractValidator<GetDiceRollsRequest>
    {
        private readonly string[] allowedSortValues = { "Sum", "Date", "SumAndDate" };

        public GetDiceRollsValidator()
        {
            RuleFor(request => request.Year)
            .Must(year => year == null || (year >= 1 && year <= DateTime.Now.Year))
            .WithMessage("Year must be a valid year up to the current year.");

            RuleFor(request => request.Month)
                .Must((request, month) => !month.HasValue || (month >= 1 && month <= 12))
                .WithMessage("Month must be between 1 and 12.")
                .When(request => request.Year.HasValue, ApplyConditionTo.CurrentValidator)
                .WithMessage("If Month is provided, Year must also be provided.");

            RuleFor(request => request.Day)
                .Must((request, day) => !day.HasValue || IsValidDay(request.Year, request.Month, day))
                .WithMessage("Day must be a valid day for the given month and year.")
                .When(request => request.Month.HasValue || request.Year.HasValue, ApplyConditionTo.CurrentValidator)
                .WithMessage("If Day is provided, both Year and Month must also be provided.");     

            RuleFor(request => request.SortBy)
            .NotEmpty().WithMessage("SortBy is required.")
            .Must(value => allowedSortValues.Contains(value))
            .WithMessage($"SortBy must be one of the following values: {string.Join(", ", allowedSortValues)}");
        }

        private bool IsValidDay(int? year, int? month, int? day)
        {
            if (year.HasValue && month.HasValue && day.HasValue)
            {
                try
                {
                    DateTime date = new DateTime(year.Value, month.Value, day.Value);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
