using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

public class AccountRole
{
    [Key]
    public Guid Guid { get; set; }

    [Required]
    [ForeignKey("Account")]
    public Guid AccountGuid { get; set; }

    [Required]
    [ForeignKey("Role")]
    public Guid RoleGuid { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }

    public virtual Account Account { get; set; }
    public virtual Role Role { get; set; }
}
