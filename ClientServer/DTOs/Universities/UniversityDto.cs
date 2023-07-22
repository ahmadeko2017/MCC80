﻿using ClientServer.Models;

namespace ClientServer.DTOs.Universities;

public class UniversityDto
{
    public Guid Guid { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }

    public static implicit operator University(UniversityDto universityDto)
    {
        return new University()
        {
            Guid = new Guid(),
            Code = universityDto.Code,
            Name = universityDto.Name,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator UniversityDto(University university)
    {
        return new UniversityDto()
        {
            Guid = university.Guid,
            Code = university.Code,
            Name = university.Name
        };
    }
}