using ClientServer.Contracts;
using ClientServer.DTOs.Educations;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Educations;

public class NewEducationValidation : AbstractValidator<EducationDto>
{
    private readonly IEducationRepository _educationRepository;

    public NewEducationValidation(IEducationRepository educationRepository)
    {
        _educationRepository = educationRepository;
        RuleFor(e => e.Guid)
            .NotEmpty().WithMessage("Education Guid is required");
        RuleFor(e => e.Major)
            .NotEmpty().WithMessage("Major is required")
            .MaximumLength(50).WithMessage("Major cannot exceed 50 characters");
        RuleFor(e => e.Degree)
            .NotEmpty().WithMessage("Degree is required")
            .MaximumLength(50).WithMessage("Degree cannot exceed 50 characters");
        RuleFor(e => e.UniversityGuid)
            .NotEmpty().WithMessage("University Guid is required");
    }
}