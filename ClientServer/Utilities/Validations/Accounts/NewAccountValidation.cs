using ClientServer.Contracts;
using ClientServer.DTOs.AccountRoles;
using ClientServer.DTOs.Accounts;
using ClientServer.DTOs.Bookings;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Accounts
{
    public class NewAccountValidation : AbstractValidator<AccountDto>
    {
        private readonly IAccountRepository _accountRepository;

        public NewAccountValidation(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            RuleFor(a => a.Guid)
                .NotEmpty().WithMessage("Account GUID is required");

            RuleFor(a => a.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .MaximumLength(50).WithMessage("Password cannot exceed 50 characters");

            RuleFor(a => a.OTP)
                .NotEmpty().WithMessage("OTP is required");

            RuleFor(a => a.ExpiredTime)
                .NotEmpty().WithMessage("Expired time is required")
                .Must(BeValidDateTime).WithMessage("Invalid expired time");
        }
        
        private bool BeValidDateTime(DateTime dateTime)
        {
            // Add any custom logic to validate the DateTime, e.g., check if it's in the future
            return dateTime > DateTime.Now;
        }
    }
}