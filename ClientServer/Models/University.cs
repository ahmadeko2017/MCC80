using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

[Table("tb_m_universities")]
public class University : BaseTable
{
    [Column ("code"),MaxLength(50)]
    public string Code { get; set; }
    
    [Column("name"), MaxLength(100)]
    public string Name { get; set; }

    public virtual ICollection<Education>? Educations { get; set; }
}
