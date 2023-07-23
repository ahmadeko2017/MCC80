﻿using ClientServer.DTOs.AccountRoles;
using ClientServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientServer.Controllers;

[ApiController]
[Route("api/accountroles")]
public class AccountRoleController : ControllerBase
{
    private readonly AccountRoleService _accountRoleService;
    
    public AccountRoleController(AccountRoleService accountRoleService)
    {
        _accountRoleService = accountRoleService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _accountRoleService.GetAll();
        if (!result.Any())
        {
            return NotFound("No data found");
        }

        return Ok(result);
    }
    
    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _accountRoleService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound("No data found");
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Insert(NewAccountRoleDto newAccountRoleDto)
    {
        var result = _accountRoleService.Create(newAccountRoleDto);
        if (result is null)
        {
            return StatusCode(500, "Error retrieving data from the database");
        }

        return Ok(result);
    }
    
    [HttpPut]
    public IActionResult Update(AccountRoleDto accountRoleDto)
    {
        var result = _accountRoleService.Update(accountRoleDto);
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
        var result = _accountRoleService.Delete(guid);
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
