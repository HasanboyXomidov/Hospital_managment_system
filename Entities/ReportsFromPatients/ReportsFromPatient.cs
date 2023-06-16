using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.ReportsFromPatients;

public sealed class ReportsFromPatient : Auditable
{
    public long patients_id { get; set; }
    public DateOnly report_date { get; set; }
    public string description { get; set; } = string.Empty;

}
