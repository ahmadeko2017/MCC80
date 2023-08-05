using ClientServer.Contracts;
using ClientServer.DTOs.Universities;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Universities;

public class UniversityValidator : AbstractValidator<UniversityDto>
{
    private readonly IUniversityRepository _universityRepository;

    public UniversityValidator(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;

        RuleFor(u => u.Guid)
            .NotEmpty().WithMessage("Guid is required");
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(u => u.Code)
            .NotEmpty();
    }
}