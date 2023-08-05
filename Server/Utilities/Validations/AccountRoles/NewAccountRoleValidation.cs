
using ClientServer.Contracts;
using ClientServer.DTOs.AccountRoles;
using FluentValidation;

namespace ClientServer.Utilities.Validations.AccountRoles;

public class NewAccountRoleDtoValidator : AbstractValidator<NewAccountRoleDto>
{
    public readonly IAccountRoleRepository _AccountRoleRepository;

    public NewAccountRoleDtoValidator(IAccountRoleRepository accountRoleRepository)
    {
        _AccountRoleRepository = accountRoleRepository;
        RuleFor(dto => dto.AccountGuid)
            .NotEmpty().WithMessage("Account GUID is required");

        RuleFor(dto => dto.RoleGuid)
            .NotEmpty().WithMessage("Role GUID is required");
    }
}