using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

public class Education
{
    [Key, ForeignKey("Employee")]
    public Guid Guid { get; set; }

    [Required]
    [MaxLength(100)]
    public string Major { get; set; }

    [Required]
    [MaxLength(100)]
    public string Degree { get; set; }

    [Required]
    public float GPA { get; set; }

    [Required]
    [ForeignKey("University")]
    public Guid UniversityGuid { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }
    
    public virtual University University { get; set; }
    public virtual Employee Employee { get; set; }
}