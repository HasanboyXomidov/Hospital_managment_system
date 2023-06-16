using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities;

public abstract  class Room : Auditable
{
    public int room_number { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }=string.Empty;
    public bool is_empty { get; set; }    
    public string description { get; set; }


}
