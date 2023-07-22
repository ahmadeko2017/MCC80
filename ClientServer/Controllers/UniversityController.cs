using ClientServer.Contracts;
using ClientServer.DTOs.Universities;
using ClientServer.Models;
using ClientServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientServer.Controllers;

[ApiController]
[Route("api/univerities")]
public class UniversityController : ControllerBase
{
    private readonly UniversityService _universityController;
    
    public UniversityController(UniversityService universityController)
    {
        _universityController = universityController;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _universityController.GetAll();
        if (!result.Any())
        {
            return NotFound("No data found");
        }

        return Ok(result);
    }
    
    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _universityController.GetByGuid(guid);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Insert(UniversityDto universityDto)
    {
        var result = _universityController.Create(universityDto);
        if (result is null)
        {
            return StatusCode(500, "Error Retrieve from database");
        }

        return Ok(result);
    }
    
    [HttpPut]
    public IActionResult Update(UniversityDto universityDto)
    {
        var result = _universityController.Update(universityDto);
        if (result is -1)
        {
            return NotFound("Guid is not found");
        }

        if (result is 0)
        {
            return StatusCode(500, "Error Retrieve from database");
        }

        return Ok("Update success");
    }
    
    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _universityController.Delete(guid);
        if (result is -1)
        {
            return NotFound("Guid is not found");
        }

        if (result is 0)
        {
            return StatusCode(500, "Error Retrieve from database");
        }

        return Ok("Delete success");
    }
}