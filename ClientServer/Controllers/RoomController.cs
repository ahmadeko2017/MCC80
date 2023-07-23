﻿using ClientServer.DTOs.Rooms;
using ClientServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientServer.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomController : ControllerBase
{
    private readonly RoomService _roomService;
    
    public RoomController(RoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _roomService.GetAll();
        if (!result.Any())
        {
            return NotFound("No data found");
        }

        return Ok(result);
    }
    
    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _roomService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound("No data found");
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Insert(NewRoomDto newRoomDto)
    {
        var result = _roomService.Create(newRoomDto);
        if (result is null)
        {
            return StatusCode(500, "Error retrieving data from the database");
        }

        return Ok(result);
    }
    
    [HttpPut]
    public IActionResult Update(RoomDto roomDto)
    {
        var result = _roomService.Update(roomDto);
        if (result is -1)
        {
            return NotFound("Guid is not found");
        }

        if (result is 0)
        {
            return StatusCode(500, "Error retrieving data from the database");
        }

        return Ok("Update success");
    }
    
    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _roomService.Delete(guid);
        if (result is -1)
        {
            return NotFound("Guid is not found");
        }

        if (result is 0)
        {
            return StatusCode(500, "Error retrieving data from the database");
        }

        return Ok("Delete success");
    }
}