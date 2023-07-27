﻿using ClientServer.Contracts;
using ClientServer.DTOs.Accounts;
using ClientServer.DTOs.Educations;
using ClientServer.DTOs.Employees;
using ClientServer.Models;
using ClientServer.Utilities.Handlers;
using Microsoft.EntityFrameworkCore;

namespace ClientServer.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUniversityRepository _universityRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly DbContext _dbContext;

    public AccountService(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IEducationRepository educationRepository, IUniversityRepository universityRepository, DbContext dbContext)
    {
        _accountRepository = accountRepository;
        _employeeRepository = employeeRepository;
        _educationRepository = educationRepository;
        _universityRepository = universityRepository;
        _dbContext = dbContext;
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
            // ini untuk cek emaik sama phone number udah ada atau belum
            if (!_employeeRepository.IsNotExist(registerDto.Email) ||
                !_employeeRepository.IsNotExist(registerDto.PhoneNumber))
            {
                return 0; // kalau sudah ada, pendaftaran gagal.
            }

            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var university = _universityRepository.GetByCode(registerDto.UniversityCode);
                if (university is null)
                {
                    // Jika universitas belum ada, buat objek University baru dan simpan
                    var createUniversity = _universityRepository.Create(new University {
                        Code = registerDto.UniversityCode,
                        Name = registerDto.UniversityName
                    });

                    university = createUniversity;
                }

                var newNik =
                    GenerateHandler.NIK(_employeeRepository
                                           .GetLastNik()); //karena niknya generate, sebelumnya kalo ga dikasih ini niknya null jadi error
                var employeeGuid = Guid.NewGuid(); // Generate GUID baru untuk employee

                // Buat objek Employee dengan nilai GUID baru
                var employee = _employeeRepository.Create(new Employee {
                    Guid = employeeGuid, //ambil dari variabel yang udah dibuat diatas
                    NIK = newNik,        //ini juga
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    BirthDate = registerDto.BirthDate,
                    Gender = registerDto.Gender,
                    HiringDate = registerDto.HiringDate,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber
                });


                var education = _educationRepository.Create(new Education {
                    Guid = employeeGuid, // Gunakan employeeGuid
                    Major = registerDto.Major,
                    Degree = registerDto.Degree,
                    GPA = registerDto.GPA,
                    UniversityGuid = university.Guid
                });

                var account = _accountRepository.Create(new Account {
                    Guid = employeeGuid, // Gunakan employeeGuid
                    OTP = 1,             //sementara ini dicoba gabisa diisi angka nol didepan, tadi masukin 098 error
                    IsUsed = true,
                    Password = registerDto.Password
                });
                transaction.Commit();
                return 1;
            }
            catch
            {
                transaction.Rollback();
                return -1;
            }
        }

    public int ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var isExist = _employeeRepository.CheckEmail(changePasswordDto.Email);
            if (isExist is null)
            {
                return -1; //Account not found
            }

            var getAccount = _accountRepository.GetByGuid(isExist.Guid);
            if (getAccount.OTP != changePasswordDto.OTP)
            {
                return 0;
            }

            if (getAccount.IsUsed)
            {
                return 1;
            }

            if (getAccount.ExpiredTime < DateTime.Now)
            {
                return 2;
            }

            var account = new Account
            {
                Guid = getAccount.Guid,
                IsUsed = true,
                ModifiedDate = DateTime.Now,
                CreatedDate = getAccount.CreatedDate,
                OTP = getAccount.OTP,
                ExpiredTime = getAccount.ExpiredTime,
                Password = changePasswordDto.NewPassword
            };

            var isUpdated = _accountRepository.Update(account);
            if (!isUpdated)
            {
                return 0; //Account Not Update
            }

            return 3;
        }
        public int ForgotPassword(ForgotPasswordDto forgotPassword)
        {
            /*var employee = _employeeRepository.GetByEmail(forgotPassword.Email);
            if (employee is null)
                return 0; // Email not found
            var account = _accountRepository.GetByGuid(employee.Guid);
            if (account is null)
                return -1;*/

            var getAccountDetail = (from e in _employeeRepository.GetAll()
                                    join a in _accountRepository.GetAll() on e.Guid equals a.Guid
                                    where e.Email == forgotPassword.Email
                                    select a).FirstOrDefault();

            _accountRepository.Clear();
            if (getAccountDetail is null)
            {
                return 0;
            }

            var otp = new Random().Next(111111, 999999);
            var account = new Account
            {
                Guid = getAccountDetail.Guid,
                Password = getAccountDetail.Password,
                ExpiredTime = DateTime.Now.AddMinutes(5),
                OTP = otp,
                IsUsed = false,
                CreatedDate = getAccountDetail.CreatedDate,
                ModifiedDate = DateTime.Now
            };

            var isUpdated = _accountRepository.Update(account);

            if (!isUpdated)
                return -1;

            return 1;
        }
}