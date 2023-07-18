using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

public class Education
{
    [Key, ForeignKey("Employee")]
    public Guid Guid { get; set; }
    
    [MaxLength(100)]
    public string Major { get; set; }
    
    [MaxLength(100)]
    public string Degree { get; set; }
    
    public float GPA { get; set; }
    
    [ForeignKey("University")]
    public Guid UniversityGuid { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModifiedDate { get; set; }
    
    public virtual University University { get; set; }
    public virtual Employee Employee { get; set; }
}