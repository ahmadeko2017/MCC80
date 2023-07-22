using ClientServer.Models;

namespace ClientServer.DTOs.Universities;

public class NewUniversityDto
{
    public Guid Guid { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }

    public static implicit operator University(NewUniversityDto newUniversityDto)
    {
        return new University()
        {
            Guid = new Guid(),
            Code = newUniversityDto.Code,
            Name = newUniversityDto.Name,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewUniversityDto(University university)
    {
        return new NewUniversityDto()
        {
            Guid = university.Guid,
            Code = university.Code,
            Name = university.Name
        };
    }
}