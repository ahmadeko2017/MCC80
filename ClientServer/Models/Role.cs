using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

[Table("tb_m_roles")]
public class Role : BaseTable
{
    [Column("name"), MaxLength(100)]
    public string Name { get; set; }

    public virtual ICollection<AccountRole> AccountRoles { get; set; }
}
