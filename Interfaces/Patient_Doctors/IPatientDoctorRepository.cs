using Hospital_managment_system.Entities.PatientsDoctors;
using Hospital_managment_system.ViewModels.PatientDoctorV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces.Patient_Doctors;

public interface IPatientDoctorRepository:IRepository<PatientDoctor,PatientDoctorViewModel>
{

}
