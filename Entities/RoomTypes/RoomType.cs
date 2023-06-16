using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.RoomTypes;

public sealed class RoomType: Auditable
{
    [MaxLength(50)]
    public string name { get; set; } = string.Empty;
    public float cost { get; set; } 

}
