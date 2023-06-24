using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.Rooms;

public sealed class OtherRoom : Room
{
    
    public int room_number { get; set; }
    [MaxLength(50)]
    public string name { get; set; }
    public bool is_free { get; set; }    
    public string description { get; set; }

}
