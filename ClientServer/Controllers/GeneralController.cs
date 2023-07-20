using ClientServer.Contracts;
using ClientServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientServer.Controllers;

[ApiController]
[Route("api/{entity}")]
public class GeneralController<TEntity> : ControllerBase
{
    private readonly IGeneralRepository<TEntity> _generalRepository;

    public GeneralController(IGeneralRepository<TEntity> generalRepository)
    {
        _generalRepository = generalRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _generalRepository.GetAll();
        if (!result.Any())
        {
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _generalRepository.GetByGuid(guid);
        if (result is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }

    [HttpPost]
    public IActionResult Insert([FromBody] TEntity entity)
    {
        var result = _generalRepository.Create(entity);
        if (result is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(result);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] TEntity entity)
    {
        var result = _generalRepository.Update(entity);
        if (!result)
        {
            return StatusCode(500, "Error Retrieve from database");
        }

        return Ok("Update success");
    }
    
    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var data = _generalRepository.GetByGuid(guid);
        if (data is null)
        {
            return NotFound("Guid is not found");
        }
        
        var result = _generalRepository.Delete(data);
        if (!result)
        {
            return StatusCode(500, "Error Retrieve from database");
        }

        return Ok("Delete success");
    }
}