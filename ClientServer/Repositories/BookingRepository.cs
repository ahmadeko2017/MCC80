using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.DTOs.Bookings;
using ClientServer.DTOs.Rooms;
using ClientServer.Models;
using ClientServer.Utilities.Enums;

namespace ClientServer.Repositories;

public class BookingRepository : GeneralRepository<Booking>, IBookingRepository
{
    public BookingRepository(BookingDbContext context) : base(context)
    {
    }
}