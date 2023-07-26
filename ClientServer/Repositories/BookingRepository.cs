﻿using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.DTOs.Bookings;
using ClientServer.DTOs.Rooms;
using ClientServer.Models;
using ClientServer.Utilities.Enums;

namespace ClientServer.Repositories;

public class BookingRepository : GeneralRepository<Booking>, IBookingRepository
{
    private readonly IRoomRepository _roomRepository;
    /// <inheritdoc />
    public BookingRepository(BookingDbContext context, IRoomRepository roomRepository) : base(context)
    {
        _roomRepository = roomRepository;
    }
    
    public IEnumerable<RoomDto> GetFreeRoomsToday()
    {
        List<RoomDto> roomDtos = new List<RoomDto>();
        var bookings = GetAll();
        var freeBookings = bookings.Where(b => b.Status == StatusLevel.Done);
        var freeBookingsToday = freeBookings.Where(b => b.EndDate < DateTime.Now);
        foreach (var booking in freeBookingsToday)
        {
            var roomGuid = booking.RoomGuid;
            var room = _roomRepository.GetByGuid(roomGuid);
            RoomDto roomDto = new RoomDto()
            {
                Guid = roomGuid,
                Capacity = room.Capacity,
                Floor = room.Floor,
                Name = room.Name
            };
            roomDtos.Add(roomDto);
        }
        return roomDtos;
    }

    /// <inheritdoc />
    public IEnumerable<BookingLengthDto> getBookingLength()
    {
        List<BookingLengthDto> listBookingLength = new List<BookingLengthDto>();
        TimeSpan workingHour = new TimeSpan(8, 30, 0);
        var timeSpan = new TimeSpan();
        var bookings = GetAll();
        foreach (var booking in bookings)
        {
            var startDate = booking.StartDate;
            var endDate = booking.EndDate;
            var room = _roomRepository.GetByGuid(booking.RoomGuid);
            if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                timeSpan = endDate - startDate;
            }

            var bookingLengthDto = new BookingLengthDto()
            {
                RoomGuid = booking.RoomGuid,
                RoomName = room.Name,
                BookingLength = timeSpan.TotalHours
            };
            listBookingLength.Add(bookingLengthDto);
        }
        return listBookingLength;
    }
}