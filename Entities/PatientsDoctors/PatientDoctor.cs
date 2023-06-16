using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.PatientsDoctors;

public sealed class PatientDoctor: Auditable
{
    public long patient_id { get; set; }
    public long doctor_id { get; set; }
    public int patient_queue { get ; set; }
    public DateOnly cur_date { get; set; }  
    public float doctor_exam_cost { get; set; } 
    public string description { get; set; } = string.Empty;

}
