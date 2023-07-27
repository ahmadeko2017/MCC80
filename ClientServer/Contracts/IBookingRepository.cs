using ClientServer.DTOs.Bookings;
using ClientServer.DTOs.Rooms;
using ClientServer.Models;

namespace ClientServer.Contracts;

public interface IBookingRepository : IGeneralRepository<Booking>
{
}