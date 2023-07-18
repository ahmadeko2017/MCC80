using System.ComponentModel.DataAnnotations;
using ClientServer.Utilities.Enums;

namespace ClientServer.Models;

public class Employee
{
    [Key]
    public Guid Guid { get; set; }
    
    [StringLength(6)]
    public string NIK { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public GenderLevel Gender { get; set; }
    
    public DateTime HiringDate { get; set; }
    
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModifiedDate { get; set; }
    
    public virtual ICollection<Booking> Bookings { get; set; }
    public virtual ICollection<Account> Accounts { get; set; }
    public virtual ICollection<Education> Educations { get; set; }
}
