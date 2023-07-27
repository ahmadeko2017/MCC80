using System.Data;
using ClientServer.Contracts;
using ClientServer.DTOs.Roles;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Roles;

public class NewRolesValidator : AbstractValidator<NewRoleDto>
{
    private readonly IRoleRepository _roleRepository;

    public NewRolesValidator(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Role name is required")
            .MaximumLength(50).WithMessage("Role name cannot exceed 50 characters");
    }
}