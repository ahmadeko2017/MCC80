using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

public class University
{
    [Key]
    public Guid Guid { get; set; }
    
    [MaxLength(50)]
    public string Code { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModifiedDate { get; set; }
    
    public virtual ICollection<Education> Educations { get; set; }
}
