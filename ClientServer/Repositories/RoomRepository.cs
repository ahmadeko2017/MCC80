using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;

namespace ClientServer.Repositories;

public class RoomRepository : GeneralRepository<Room>, IRoomRepository
{
    /// <inheritdoc />
    public RoomRepository(BookingDbContext context) : base(context)
    {
    }
}