using System.Data;
using ClientServer.Contracts;
using ClientServer.DTOs.Accounts;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Accounts;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public RegisterValidator(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
        
        RuleFor(r => r.FirstName)
            .NotEmpty().WithMessage("First name is required");
        RuleFor(r => r.LastName);
        RuleFor(r => r.BitrhDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now.AddYears(-10));
        RuleFor(r => r.Gender)
            .NotEmpty()
            .IsInEnum();
        RuleFor(r => r.HiringDate)
            .NotEmpty();
        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .Must((s) => IsDuplicateValue(s)).WithMessage("Email already exist");
        RuleFor(r => r.PhoneNumber)
            .NotEmpty()
            .MaximumLength(20)
            .Matches(@"^\+[0-9]").WithMessage("Incorect format number")
            .Must((s) => IsDuplicateValue(s)).WithMessage("Email already exist");
        RuleFor(r => r.Major)
            .NotEmpty();
        RuleFor(r => r.Degree)
            .NotEmpty();
        RuleFor(r => r.UniversityCode)
            .NotEmpty();
        RuleFor(r => r.UniversityName)
            .NotEmpty();
        RuleFor(r => r.OTP)
            .NotEmpty()
            .MaximumLength(4)
            .Matches(@"[0-9]+").WithMessage("Incorect format OTP");
        RuleFor(register => register.Password)
            .NotEmpty().WithMessage("Password is required")
            .Matches(@"^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[^a-zA-Z\d]).{8,}$");
        RuleFor(register => register.ConfirmPassword)
            .Equal(register => register.Password)
            .WithMessage("Passwords do not match");
    }
    
    private bool IsDuplicateValue(string arg)
    {
        var result = _employeeRepository.IsNotExist(arg);
        return result;
    }
}