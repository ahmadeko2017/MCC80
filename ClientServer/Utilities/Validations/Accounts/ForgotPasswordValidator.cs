using ClientServer.Contracts;
using ClientServer.DTOs.Accounts;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Accounts;

public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
{
    private readonly IEmployeeRepository _employeeRepository;

    public ForgotPasswordValidator(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");
    }
}