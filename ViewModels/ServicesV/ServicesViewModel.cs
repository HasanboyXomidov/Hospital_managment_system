using Hospital_managment_system.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.ViewModels.ServicesV;

public sealed class ServicesViewModel: Auditable
{
    [MaxLength(50)]
    public string name { get; set; }
    public int room { get; set; }
    public float cost { get; set; }

}
