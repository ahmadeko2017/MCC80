using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;

namespace ClientServer.Repositories;

public class BookingRepository : GeneralRepository<Booking>, IBookingRepository
{
    /// <inheritdoc />
    protected BookingRepository(BookingDbContext context) : base(context)
    {
    }
}