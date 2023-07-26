using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.DTOs.Rooms;
using ClientServer.Models;
using ClientServer.Utilities.Enums;

namespace ClientServer.Repositories;

public class RoomRepository : GeneralRepository<Room>, IRoomRepository
{
    /// <inheritdoc />
    public RoomRepository(BookingDbContext context) : base(context)
    {
    }
}