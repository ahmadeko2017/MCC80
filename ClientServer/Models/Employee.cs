using System.ComponentModel.DataAnnotations;

namespace ClientServer.Models;

public class Employee
{
    [Key]
    public Guid Guid { get; set; }

    [Required]
    [StringLength(6)]
    public string NIK { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public int Gender { get; set; }

    [Required]
    public DateTime HiringDate { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }
    
    public virtual ICollection<Booking> Bookings { get; set; }
    public virtual ICollection<Account> Accounts { get; set; }
    public virtual ICollection<Education> Educations { get; set; }
}
