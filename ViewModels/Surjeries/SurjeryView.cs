using Hospital_managment_system.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.ViewModels.Surjeries;

public sealed class SurjeryView: Auditable
{
    public long id { get; set; }
    [MaxLength(100)]
    public string doctor_fio { get ; set; }
    [MaxLength(150)]
    public string patient_info { get; set; }    
    public string description { get; set; }

    public DateTime surjery_time { get; set; }
    public DateTime surjery_end_time { get; set; }
    [MaxLength(50)]
    public string status { get; set; }


}
