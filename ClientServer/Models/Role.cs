using System.ComponentModel.DataAnnotations;

namespace ClientServer.Models;

public class Role
{
    [Key]
    public Guid Guid { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }
    
    public virtual ICollection<AccountRole> AccountRoles { get; set; }
}
