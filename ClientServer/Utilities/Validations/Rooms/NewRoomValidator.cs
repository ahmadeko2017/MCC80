using System.Data;
using ClientServer.Contracts;
using ClientServer.DTOs.Rooms;
using FluentValidation;

namespace ClientServer.Utilities.Validations.Rooms;

public class NewRoomValidator : AbstractValidator<NewRoomDto>
{
    private readonly IRoomRepository _roomRepository;
    
    public NewRoomValidator(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;

        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Room name is required")
            .MaximumLength(50).WithMessage("Romm name cannot exceed 50 characters");
        RuleFor(r => r.Floor)
            .NotEmpty().WithMessage("Floor number is required")
            .GreaterThanOrEqualTo(1).WithMessage("Floor number must be greater than or equal to 1");
        RuleFor(r => r.Capacity)
            .NotEmpty().WithMessage("Capacity is required")
            .GreaterThan(0).WithMessage("Capacity must be greader than 0");
    }
}