using ClientServer.DTOs.Accounts;

namespace ClientServer.Validator;

using FluentValidation;

public class AccountDtoValidator : AbstractValidator<AccountDto>
{
    public AccountDtoValidator()
    {
        RuleFor(account => account.Guid).NotEmpty().WithMessage("Username harus diisi.");
        RuleFor(account => account.Password).NotEmpty().EmailAddress().WithMessage("Alamat email tidak valid.");
        RuleFor(account => account.Password).NotEmpty().MinimumLength(6).WithMessage("Password harus memiliki setidaknya 6 karakter.");
    }
}
