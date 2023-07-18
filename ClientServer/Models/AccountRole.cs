using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

public class AccountRole
{
    [Key]
    public Guid Guid { get; set; }
    
    [ForeignKey("Account")]
    public Guid AccountGuid { get; set; }
    
    [ForeignKey("Role")]
    public Guid RoleGuid { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModifiedDate { get; set; }

    public virtual Account Account { get; set; }
    public virtual Role Role { get; set; }
}
