using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

[Table("tb_tr_account_roles")]
public class AccountRole : BaseTable
{
    [ForeignKey("Account")]
    public Guid AccountGuid { get; set; }
    
    [ForeignKey("Role")]
    public Guid RoleGuid { get; set; }

    public virtual Account? Account { get; set; }
    public virtual Role? Role { get; set; }
}
