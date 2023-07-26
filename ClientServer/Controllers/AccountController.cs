using System.Net;
using ClientServer.DTOs.Accounts;
using ClientServer.DTOs.Universities;
using ClientServer.Services;
using ClientServer.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ClientServer.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;
    private readonly EducationService _educationService;
    private readonly EmployeeService _employeeService;
    private readonly UniversityService _universityService;
    
    public AccountController(AccountService accountService, EducationService educationService, EmployeeService employeeService, UniversityService universityService)
    {
        _accountService = accountService;
        _educationService = educationService;
        _employeeService = employeeService;
        _universityService = universityService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _accountService.GetAll();
        if (!result.Any())
        {
            return NotFound(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<IEnumerable<AccountDto>>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieving data",
            Data = result
        });
    }
    
    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = _accountService.GetByGuid(guid);
        if (result is null)
        {
            return NotFound(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        return Ok(new ResponseHandler<AccountDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieving data",
            Data = result
        });
    }

    [HttpPost]
    public IActionResult Insert(AccountDto accountDto)
    {
        var result = _accountService.Create(accountDto);
        if (result is null)
        {
            return StatusCode(500, new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database"
            });
        }

        return Ok(new ResponseHandler<AccountDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieving data",
            Data = result
        });
    }
    
    [HttpPut]
    public IActionResult Update(AccountDto accountDto)
    {
        var result = _accountService.Update(accountDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database"
            });
        }

        return Ok(new ResponseHandler<int>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieving data",
            Data = result
        });
    }
    
    [HttpDelete]
    public IActionResult Delete(Guid guid)
    {
        var result = _accountService.Delete(guid);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Guid is not found"
            });
        }

        if (result is 0)
        {
            return StatusCode(500, new ResponseHandler<AccountDto>
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = "Error retrieving data from the database"
            });
        }

        return Ok(new ResponseHandler<int>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Success retrieving data",
            Data = result
        });
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginDto loginDto)
    {
        var result = _accountService.Login(loginDto);

        if (result is -1)
        {
            return NotFound(new ResponseHandler<LoginDto> {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Email or Password is incorrect"
            });
        }
        
        return Ok(new ResponseHandler<LoginDto> {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Login Success"
        });
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDto registerDto)
    {
        var result = _accountService.Register(registerDto);
        if (result is -1)
        {
            return NotFound(new ResponseHandler<LoginDto> {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Registration failed"
            });
        }
        if (result < -1)
        {
            return NotFound(new ResponseHandler<int> {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Registration failed",
                Data = result
            });
        }
        return Ok(new ResponseHandler<LoginDto> {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Registration success"
        });
    }
}