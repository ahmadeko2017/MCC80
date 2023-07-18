using System.ComponentModel.DataAnnotations;

namespace ClientServer.Models;

public class Room
{
    [Key]
    public Guid Guid { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    public int Floor { get; set; }
    
    public int Capacity { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModifiedTime { get; set; }
    
    public virtual ICollection<Booking> Bookings { get; set; }
}
