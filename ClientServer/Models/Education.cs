using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ClientServer.Models;

[Table("tb_m_educations")]
public class Education : BaseTable
{
    [Key, ForeignKey("Employee")]
    public Guid Guid { get; set; }
    
    [Column("major"), MaxLength(100)]
    public string Major { get; set; }
    
    [Column("degree"), MaxLength(100)]
    public string Degree { get; set; }
    
    [Column("gpa")]
    public float GPA { get; set; }
    
    [Column("university_guid"), ForeignKey("University")]
    public Guid UniversityGuid { get; set; }

    public virtual University University { get; set; }
    public virtual Employee Employee { get; set; }
}