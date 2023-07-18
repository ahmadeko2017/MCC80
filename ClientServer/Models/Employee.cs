using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClientServer.Utilities.Enums;

namespace ClientServer.Models;

[Table("tb_m_employees")]
public class Employee : BaseTable
{
    [Column("nik"), StringLength(6)]
    public string NIK { get; set; }
    
    [Column("first_name"), MaxLength(100)]
    public string FirstName { get; set; }

    [Column("last_name"), MaxLength(100)]
    public string? LastName { get; set; }
    
    [Column("birth_date")]
    public DateTime BirthDate { get; set; }
    
    [Column("gender")]
    public GenderLevel Gender { get; set; }
    
    [Column("hiring_date")]
    public DateTime HiringDate { get; set; }
    
    [Column("email"), MaxLength(100), EmailAddress]
    public string Email { get; set; }

    [Column("phone_number"), MaxLength(20)]
    public string PhoneNumber { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; }
    public virtual Account Account { get; set; }
    public virtual Education Education { get; set; }
}
