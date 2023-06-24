using Hospital_managment_system.Entities.BedPatients;
using Hospital_managment_system.Interfaces.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces.Bed_patients;

public interface  IBed_PatientsRepository : IRepository<BedPatient,BedPatient>
{

}
