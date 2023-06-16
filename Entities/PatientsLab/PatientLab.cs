using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.PatientsLab;

public sealed class PatientLab: Auditable
{
    public long patients_id { get; set; }
    public long lab_id { get; set;}


}
