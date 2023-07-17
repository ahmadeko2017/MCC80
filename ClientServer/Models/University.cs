using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

public class University
{
    [Key]
    public Guid Guid { get; set; }

    [Required]
    [MaxLength(50)]
    public string Code { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }
    
    public virtual ICollection<Education> Educations { get; set; }
}
