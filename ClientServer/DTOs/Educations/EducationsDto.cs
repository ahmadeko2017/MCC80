using ClientServer.Models;

namespace ClientServer.DTOs.Educations;

public class EducationsDto
{
    public Guid Guid { get; set; }
    public string Major { get; set; }
    public string Degree { get; set; }
    public float GPA { get; set; }
    public Guid UniversityGuid { get; set; }

    public static implicit operator Education(EducationsDto educationsDto)
    {
        return new Education()
        {
            Guid = educationsDto.Guid,
            Major = educationsDto.Major,
            Degree = educationsDto.Degree,
            GPA = educationsDto.GPA,
            UniversityGuid = educationsDto.Guid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator EducationsDto(Education education)
    {
        return new EducationsDto()
        {
            Guid = education.Guid,
            Major = education.Major,
            Degree = education.Degree,
            GPA = education.GPA,
            UniversityGuid = education.UniversityGuid
        };
    }
}