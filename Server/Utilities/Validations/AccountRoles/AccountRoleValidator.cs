using ClientServer.Contracts;
using ClientServer.DTOs.AccountRoles;
using FluentValidation;

namespace ClientServer.Utilities.Validations.AccountRoles;

public class AccountRoleValidator : AbstractValidator<AccountRoleDto>
{
    public readonly IAccountRoleRepository _AccountRoleRepository;

    public AccountRoleValidator(IAccountRoleRepository accountRoleRepository)
    {
        _AccountRoleRepository = accountRoleRepository;
        RuleFor(dto => dto.Guid)
            .NotEmpty().WithMessage("Guid is required");
        RuleFor(dto => dto.AccountGuid)
            .NotEmpty().WithMessage("Account GUID is required");

        RuleFor(dto => dto.RoleGuid)
            .NotEmpty().WithMessage("Role GUID is required");
    }
}