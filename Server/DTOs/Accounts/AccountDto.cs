﻿using ClientServer.Models;

namespace ClientServer.DTOs.Accounts;

public class AccountDto
{
    public Guid Guid { get; set; }
    public string Password { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiredTime { get; set; }

    public static implicit operator Account(AccountDto accountDto)
    {
        return new Account()
        {
            Guid = accountDto.Guid,
            Password = accountDto.Password,
            IsDeleted = accountDto.IsDeleted,
            OTP = 111111,
            IsUsed = accountDto.IsUsed,
            ExpiredTime = accountDto.ExpiredTime,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator AccountDto(Account account)
    {
        return new AccountDto()
        {
            Guid = account.Guid,
            Password = account.Password,
            IsDeleted = account.IsDeleted,
            IsUsed = account.IsUsed,
            ExpiredTime = account.ExpiredTime
        };
    }
}