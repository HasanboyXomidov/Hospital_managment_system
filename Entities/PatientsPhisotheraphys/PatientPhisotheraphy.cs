using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.PatientsPhisotheraphys;

public sealed class PatientPhisotheraphy : Auditable
{
    public long patients_id { get; set; }
    public long phisotheraphy_id { get; set; }

}
