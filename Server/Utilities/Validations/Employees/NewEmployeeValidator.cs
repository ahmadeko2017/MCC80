using ClientServer.Contracts;
using ClientServer.DTOs.Employees;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Employees;

public class NewEmployeeValidator : AbstractValidator<NewEmployeeDto>
{
    private readonly IEmployeeRepository _employeeRepository;

    public NewEmployeeValidator(IEmployeeRepository employeeRepository)
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
            .Must(IsDuplicateValue).WithMessage("Email already exist");
        RuleFor(e => e.PhoneNumber)
            .NotEmpty()
            .MaximumLength(20)
            .Matches(@"^\+[0-9]").WithMessage("Incorect format number")
            .Must(IsDuplicateValue).WithMessage("Phone number already exists");
    }

    private bool IsDuplicateValue(string arg)
    {
        return _employeeRepository.IsNotExist(arg);
    }
}