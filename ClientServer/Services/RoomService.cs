using ClientServer.Contracts;
using ClientServer.DTOs.Rooms;
using ClientServer.Models;

namespace ClientServer.Services;

public class RoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
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
}