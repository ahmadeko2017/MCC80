using ClientServer.Utilities.Enums;

namespace ClientServer.DTOs.Rooms;

public class BookedRoomDto
{
    public Guid BookingGuid { get; set; }
    public string RoomName { get; set; }
    public StatusLevel Status { get; set; }
    public int Floor { get; set; }
    public string BookedBy { get; set; }
}