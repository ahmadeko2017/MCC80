using System.ComponentModel.DataAnnotations;

namespace ClientServer.Models;

public class Room
{
    [Key]
    public Guid Guid { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int Floor { get; set; }

    [Required]
    public int Capacity { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime ModifiedTime { get; set; }
    
    public virtual ICollection<Booking> Bookings { get; set; }
}
