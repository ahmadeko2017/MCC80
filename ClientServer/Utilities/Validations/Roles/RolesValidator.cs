using ClientServer.Contracts;
using ClientServer.DTOs.Roles;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Roles;

public class RolesValidator : AbstractValidator<RoleDto>
{
    private readonly IRoleRepository _roleRepository;

    public RolesValidator(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
        RuleFor(r => r.Guid)
            .NotEmpty().WithMessage("Guid is required");
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Role name is required")
            .MaximumLength(50).WithMessage("Role name cannot exceed 50 characters");
    }
}