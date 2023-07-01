using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.BedPatients;

public sealed class BedPatient: Human
{
    public DateTime come_time { get; set; }
    public DateOnly leave_date { get; set;}
    public long bed_room_id { get; set; }    
    [MaxLength(50)]
    public string allergies {  get; set; }  = string.Empty;

    public long emergency_person_id { get; set; }
    [MaxLength(100)]
    public string where_come_from { get; set; } = string.Empty;


}
