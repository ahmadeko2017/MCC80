using ClientServer.Contracts;
using ClientServer.DTOs.Bookings;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Bookings;

public class BookingValidator : AbstractValidator<BookingDto>
{
    private readonly IBookingRepository _bookingRepository;

    public BookingValidator(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
        RuleFor(b => b.Guid)
            .NotEmpty().WithMessage("Guid is required");
        RuleFor(b => b.StartDate)
            .NotEmpty().WithMessage("Start date is required")
            .Must((dto, startDate) => startDate < dto.EndDate).WithMessage("Start date must be before end date");
        RuleFor(b => b.EndDate)
            .NotEmpty().WithMessage("End date is required")
            .Must((dto, endDate) => endDate > dto.StartDate).WithMessage("End date must be after start date");
        RuleFor(b => b.Status)
            .IsInEnum().WithMessage("Invalid booking status");
        RuleFor(b => b.Remarks)
            .MaximumLength(200).WithMessage("Remarks cannot exceed 200 characters");
        RuleFor(b => b.EmployeeGuid)
            .NotEmpty().WithMessage("Employee Guid is required");
    }
}