using Hospital_managment_system.Entities;
using Hospital_managment_system.Entities.RoomTypes;
using Hospital_managment_system.Enums.RoomTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.ViewModels.BedRooms;

public sealed class BedRoomsViewModel: Auditable
{

    [MaxLength(50)]
    public string name { get ; set; }    
    public RoomTypeEnum room_type { get; set; } 
    public float  Room_cost { get; set; }
    public int room_number {  get; set; }
    public int capacity { get; set; }
    public bool is_free { get; set; }
    public string description { get; set; }

}
