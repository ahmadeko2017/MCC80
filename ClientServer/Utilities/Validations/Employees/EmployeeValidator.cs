using System.ComponentModel.DataAnnotations;
using ClientServer.Contracts;
using ClientServer.DTOs.Employees;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Employees;

public class EmployeeValidator : AbstractValidator<EmployeeDto>
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeValidator(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
        RuleFor(e => e.FirstName)
            .NotEmpty();
        RuleFor(e => e.BirthDate)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.Now.AddYears(-10));
        RuleFor(e => e.Gender)
            .NotNull()
            .IsInEnum();
        RuleFor(e => e.HiringDate)
            .NotEmpty();
        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid")
            .Must((e, s) => IsDuplicateValue(e.Email, e.Guid)).WithMessage("Email already exist");
        RuleFor(e => e.PhoneNumber)
            .NotEmpty()
            .MaximumLength(20)
            .Matches(@"^\+[0-9]").WithMessage("Incorect format number")
            .Must((e, s) => IsDuplicateValue(s, e.Guid)).WithMessage("Phone number already exists");
    }

    private bool IsDuplicateValue(string arg, Guid guid)
    {
        var temp = false;
        var (email, phone) = GetEmailPhone(guid);
        if (arg == email || arg == phone)
        {
            temp = true;
        }

        var result = _employeeRepository.IsNotExist(arg) || temp;
        return result;
    }

    private (string?, string?) GetEmailPhone(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        return (employee.Email, employee.PhoneNumber);
    }
    
}