using Hospital_managment_system.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.ViewModels.BedPatientsV;

public class BedPatientsViewModel:Auditable
{
    public string name { get; set; }
    public string surname { get; set; }
    public DateOnly date_birth { get; set; }
    public string adress { get; set; }
    public bool is_male { get; set; }
    public string tel_number { get; set; }
    public DateTime comeTime { get; set; }
    public DateTime leaveTime { get; set; }
    public int room_number { get; set; }
    public string description { get; set;}
    public string allergies { get; set; }
    public string where_come_from { get; set; }


}
