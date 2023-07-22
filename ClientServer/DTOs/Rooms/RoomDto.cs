using ClientServer.Models;

namespace ClientServer.DTOs.Rooms;

public class RoomDto
{
    public string Name { get; set; }
    public int Floor { get; set; }
    public int Capacity { get; set; }

    public static implicit operator Room(RoomDto roomDto)
    {
        return new Room()
        {
            Guid = new Guid(),
            Name = roomDto.Name,
            Floor = roomDto.Floor,
            Capacity = roomDto.Capacity,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator RoomDto(Room room)
    {
        return new RoomDto()
        {
            Name = room.Name,
            Floor = room.Floor,
            Capacity = room.Capacity
        };
    }
}