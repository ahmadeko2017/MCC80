using System.ComponentModel.DataAnnotations;

namespace ClientServer.Models;

public class Role
{
    [Key]
    public Guid Guid { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModifiedDate { get; set; }
    
    public virtual ICollection<AccountRole> AccountRoles { get; set; }
}
