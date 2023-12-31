﻿using ClientServer.Contracts;
using ClientServer.DTOs.Rooms;
using ClientServer.Models;
using ClientServer.Utilities.Enums;

namespace ClientServer.Services;

public class RoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public RoomService(IRoomRepository roomRepository, IBookingRepository bookingRepository, IEmployeeRepository employeeRepository)
    {
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<RoomDto> GetAll()
    {
        var rooms = _roomRepository.GetAll();
        if (!rooms.Any())
        {
            return Enumerable.Empty<RoomDto>();
        }

        var roomDtos = new List<RoomDto>();
        foreach (var room in rooms)
        {
            roomDtos.Add((RoomDto)room);
        }

        return roomDtos;
    }

    public RoomDto? GetByGuid(Guid guid)
    {
        var room = _roomRepository.GetByGuid(guid);
        if (room is null)
        {
            return null;
        }

        return (RoomDto)room;
    }

    public NewRoomDto? Create(NewRoomDto newRoomDto)
    {
        var room = _roomRepository.Create(newRoomDto);
        if (room is null)
        {
            return null;
        }

        return (NewRoomDto)room;
    }

    public int Update(RoomDto roomDto)
    {
        var room = _roomRepository.GetByGuid(roomDto.Guid);
        if (room is null)
        {
            return -1;
        }

        Room toUpdate = roomDto;
        toUpdate.CreatedDate = room.CreatedDate;
        var result = _roomRepository.Update(toUpdate);

        return result ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var room = _roomRepository.GetByGuid(guid);
        if (room is null)
        {
            return -1;
        }

        var result = _roomRepository.Delete(room);
        return result ? 1 : 0;
    }

    public IEnumerable<BookedRoomDto> GetRoom()
    {
        var today = DateTime.Today.ToString("dd-MM-yyyy");
        var bookings = _bookingRepository.GetAll()
            .Where(b => b.StartDate.ToString("dd-MM-yyyy").Equals(today));

        if (!bookings.Any())
        {
            return null;
        }

        var bookingToday = new List<BookedRoomDto>();
        foreach (var booking in bookings)
        {
            var employee = _employeeRepository.GetByGuid(booking.Guid);
            var room = _roomRepository.GetByGuid(booking.RoomGuid);

            var bookedRoom = new BookedRoomDto()
            {
                BookingGuid = booking.Guid,
                RoomName = room.Name,
                Status = booking.Status,
                Floor = room.Floor,
                BookedBy = employee.FirstName + " " + employee.LastName
            };
            
            bookingToday.Add(bookedRoom);
        }

        return bookingToday;
    }
}