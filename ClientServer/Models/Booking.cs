using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClientServer.Utilities.Enums;

namespace ClientServer.Models;

[Table("tb_tr_bookings")]
public class Booking : BaseTable
{
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    
    [Column("end_date")]
    public DateTime EndDate { get; set; }
    
    [Column("status")]
    public StatusLevel Status { get; set; }
    
    [Column("remarks")]
    public string Remarks { get; set; }
    
    [Column("room_guid"), ForeignKey("Room")]
    public Guid RoomGuid { get; set; }
    
    [Column("employee_guid"), ForeignKey("Employee")]
    public Guid EmployeeGuid { get; set; }

    public virtual Room Room { get; set; }
    public virtual Employee Employee { get; set; }
}
