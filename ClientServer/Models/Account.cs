using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

[Table("tb_m_accounts")]
public class Account: BaseTable
{
    [Key, ForeignKey("Employee"), Column("guid")]
    public Guid Guid { get; set; }
    
    [Column ("password")]
    public string Password { get; set; }
    
    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
    
    [Column("otp")]
    public int OTP { get; set; }
    
    [Column("is_used")]
    public bool IsUsed { get; set; }
    
    [Column("expired_time")]
    public DateTime ExpiredTime { get; set; }

    public virtual Employee Employee { get; set; }
    
    public virtual ICollection<AccountRole> AccountRoles { get; set; }
}
