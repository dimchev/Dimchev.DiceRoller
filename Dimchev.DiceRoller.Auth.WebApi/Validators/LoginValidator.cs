using Dimchev.DiceRoller.Auth.Core.Dtos;
using FluentValidation;

namespace Dimchev.DiceRoller.Auth.WebApi.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(login => login.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .Length(5, 100).WithMessage("Email must be between 5 and 100 characters.");

            RuleFor(login => login.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
