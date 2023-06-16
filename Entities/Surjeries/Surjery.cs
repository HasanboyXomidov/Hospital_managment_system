using Hospital_managment_system.Enums.SurjeryStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.Surjeries;

public sealed class Surjery: Auditable
{
    public long doctor_id {  get; set; }
    public long patient_id {  get; set; }
    public string description { get; set; }=string.Empty;
    public DateTime surjery_start_time { get; set; }
    public DateTime surjery_end_time { get; set; }
    public SurjeryStatus surjery_status { get; set;}


}
