using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

public class Account
{
    [Key, ForeignKey("Employee")]
    public Guid Guid { get; set; }
    
    public string Password { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public int OTP { get; set; }
    
    public bool IsUsed { get; set; }
    
    public DateTime ExpiredTime { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModifiedDate { get; set; }

    public virtual Employee Employee { get; set; }
    
    public virtual ICollection<AccountRole> AccountRoles { get; set; }
}
