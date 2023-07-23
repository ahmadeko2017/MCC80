using ClientServer.DTOs.Educations;
using ClientServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientServer.Controllers;

[ApiController]
[Route("api/educations")]
public class EducationController : ControllerBase
{
    private readonly EducationService _educationService;
    
    public EducationController(EducationService educationService)
    {
        _educationService = educationService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _educationService.GetAll();
        if (!result.Any())
        {
            return NotFound("No data found");
        }

        return Ok(result);
    }
    
    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _educationService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound("No data found");
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Insert(EducationDto educationDto)
    {
        var result = _educationService.Create(educationDto);
        if (result is null)
        {
            return StatusCode(500, "Error retrieving data from the database");
        }

        return Ok(result);
    }
    
    [HttpPut]
    public IActionResult Update(EducationDto educationDto)
    {
        var result = _educationService.Update(educationDto);
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
        var result = _educationService.Delete(guid);
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
