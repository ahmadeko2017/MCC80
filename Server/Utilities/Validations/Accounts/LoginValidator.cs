using ClientServer.DTOs.Accounts;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Accounts;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(e => e.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(e => e.Password)
            .NotEmpty();
    }
}