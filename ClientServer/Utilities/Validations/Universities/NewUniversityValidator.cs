using ClientServer.Contracts;
using ClientServer.DTOs.Universities;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Universities;

public class NewUniversityValidator : AbstractValidator<NewUniversityDto>
{
    private readonly IUniversityRepository _universityRepository;

    public NewUniversityValidator(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;

        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(u => u.Code)
            .NotEmpty();
    }
}