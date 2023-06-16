using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.BedRooms;

public sealed class BedRoom : Room
{    
    public long room_type_id { get ; set; } 
    public int capacity { get; set; }
    
}
