using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClientServer.Utilities.Enums;

namespace ClientServer.Models;

public class Booking
{
    [Key]
    public Guid Guid { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public StatusLevel Status { get; set; }
    
    public string Remarks { get; set; }
    
    [ForeignKey("Room")]
    public Guid RoomGuid { get; set; }
    
    [ForeignKey("Employee")]
    public Guid EmployeeGuid { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModifiedDate { get; set; }

    public virtual Room Room { get; set; }
    public virtual Employee Employee { get; set; }
}
