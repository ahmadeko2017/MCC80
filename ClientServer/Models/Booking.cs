using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientServer.Models;

public class Booking
{
    [Key]
    public Guid Guid { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public int Status { get; set; }

    [Required]
    public string Remarks { get; set; }

    [Required]
    [ForeignKey("Room")]
    public Guid RoomGuid { get; set; }

    [Required]
    [ForeignKey("Employee")]
    public Guid EmployeeGuid { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime ModifiedDate { get; set; }

    public virtual Room Room { get; set; }
    public virtual Employee Employee { get; set; }
}
