using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.Services;

public class Service :Auditable
{
    [MaxLength(50)]
    public string name { get; set; }
    public long rooms_id { get; set; }
    public float cost { get; set; }

}
