using ClientServer.Contracts;
using ClientServer.DTOs.Accounts;
using ClientServer.DTOs.Educations;
using ClientServer.DTOs.Employees;
using ClientServer.Models;
using ClientServer.Utilities.Handlers;

namespace ClientServer.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUniversityRepository _universityRepository;
    private readonly IEducationRepository _educationRepository;

    public AccountService(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IEducationRepository educationRepository, IUniversityRepository universityRepository)
    {
        _accountRepository = accountRepository;
        _employeeRepository = employeeRepository;
        _educationRepository = educationRepository;
        _universityRepository = universityRepository;
    }

    public IEnumerable<AccountDto> GetAll()
    {
        var accounts = _accountRepository.GetAll();
        if (!accounts.Any())
        {
            return Enumerable.Empty<AccountDto>();
        }

        var accountDtos = new List<AccountDto>();
        foreach (var account in accounts)
        {
            accountDtos.Add((AccountDto)account);
        }

        return accountDtos;
    }

    public AccountDto? GetByGuid(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null)
        {
            return null;
        }

        return (AccountDto)account;
    }

    public AccountDto? Create(AccountDto newAccountDto)
    {
        var account = _accountRepository.Create(newAccountDto);
        if (account is null)
        {
            return null;
        }

        return (AccountDto)account;
    }

    public int Update(AccountDto accountDto)
    {
        var account = _accountRepository.GetByGuid(accountDto.Guid);
        if (account is null)
        {
            return -1;
        }

        Account toUpdate = accountDto;
        toUpdate.CreatedDate = account.CreatedDate;
        var result = _accountRepository.Update(toUpdate);

        return result ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null)
        {
            return -1;
        }

        var result = _accountRepository.Delete(account);
        return result ? 1 : 0;
    }

    public int Login(LoginDto loginDto)
    {
        var getEmployee = _employeeRepository.GetByEmail(loginDto.Email);
        if (getEmployee is null)
        {
            return -1; // Email not found
        }

        var getAccount = _accountRepository.GetByGuid(getEmployee.Guid);
        if (getAccount.Password == loginDto.Password)
        {
            return 1; // Login Success
        }

        return -1; // Email or Password incorrect.                         
    }

    public int Register(RegisterDto registerDto)
    {
        var newEmployeeDto = new NewEmployeeDto()
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            BirthDate = registerDto.BitrhDate,
            Gender = registerDto.Gender,
            HiringDate = registerDto.HiringDate,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber
        };
        
        var lastNik = _employeeRepository.GetLastNik();
        Employee emp = newEmployeeDto;
        emp.NIK = GenerateHandler.NIK(lastNik);
        
        var employee = _employeeRepository.Create(emp);
        if (employee is null)
        {
            return -1; // Error while insert employee
        }
        
        var newAccountDto = new AccountDto()
        {
            Guid = employee.Guid,
            ExpiredTime = DateTime.Now.Add(new TimeSpan(365)),
            IsDeleted = false,
            IsUsed = false,
            OTP = GenerateHandler.OTP(4),
            Password = registerDto.Password
        };
        var account = _accountRepository.Create(newAccountDto);
        if (account is null)
        {
            return -2; // Account fail to create
        }

        var university = _universityRepository.GetByCode(registerDto.UniversityCode);
        if (university is null)
        {
            return -3; // University not found
        }
        
        var newEducationDto = new EducationDto()
        {
            Guid = employee.Guid,
            Major = registerDto.Major,
            Degree = registerDto.Degree,
            GPA = registerDto.GPA,
            UniversityGuid = university.Guid
        };

        var education = _educationRepository.Create(newEducationDto);
        if (education is null)
        {
            return -4;
        }
        
        return 1;
    }

    public int ForgotPasswordDto(ForgotPasswordDto forgotPasswordDto)
    {
        var employee = _employeeRepository.GetByEmail(forgotPasswordDto.Email);
        if (employee is null)
        {
            return 0; // Email not found
        }

        var account = _accountRepository.GetByGuid(employee.Guid);
        if (account is null)
        {
            return -1;
        }

        var otp = new Random().Next(111111, 999999);
        var isUpdated = _accountRepository.Update(new Account()
        {
            Guid = account.Guid,
            Password = account.Password,
            ExpiredTime = DateTime.Now.AddMinutes(5),
            OTP = otp,
            IsUsed = false,
            CreatedDate = account.CreatedDate,
            ModifiedDate = DateTime.Now
        });

        if (!isUpdated)
        {
            return -1;
        }

        forgotPasswordDto.Email = $"{otp}";
        return 1;
    }

    public int ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var isExist = _employeeRepository.CheckEmail(changePasswordDto.Email);
        if (isExist is null)
        {
            return -1;
        }

        var getAccount = _accountRepository.GetByGuid(isExist.Guid);
        var account = new Account()
        {
            Guid = getAccount.Guid,
            IsUsed = true,
            ModifiedDate = DateTime.Now,
            CreatedDate = getAccount.CreatedDate,
            OTP = getAccount.OTP,
            ExpiredTime = getAccount.ExpiredTime,
            Password = changePasswordDto.NewPassword
        };
        if (getAccount.OTP != changePasswordDto.OTP)
        {
            return 0;
        }

        if (getAccount.IsUsed == true)
        {
            return 1;
        }

        if (getAccount.ExpiredTime < DateTime.Now)
        {
            return 2;
        }

        var isUpdated = _accountRepository.Update(account);
        if (!isUpdated)
        {
            return 0;
        }

        return 3;
    }
}