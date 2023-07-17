using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

public class Account
{
    [Key, ForeignKey("Employee")]
    public Guid Guid { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    [Required]
    public int OTP { get; set; }

    [Required]
    public bool IsUsed { get; set; }

    [Required]
    public DateTime ExpiredTime { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }

    public virtual Employee Employee { get; set; }
    
    public virtual ICollection<AccountRole> AccountRoles { get; set; }
}
