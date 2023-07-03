using Hospital_managment_system.Entities.PatientsDoctors;
using Hospital_managment_system.Utilities;
using Hospital_managment_system.ViewModels.PatientDoctorV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces.Patient_Doctors;

public interface IPatientDoctorRepository:IRepository<PatientDoctor,PatientDoctorViewModel>
{
    public Task<int> GetCurrentQueue(long queue);
    public Task<int> GetTodaysTotalAppointment();
    public Task<int> GetYesterdaysTotalAppointment();
    public Task<int>GetWeeklyAllAppointment();
    public Task<int> MonthlyAllAppointments();
    public Task<IList<PatientDoctorViewModel>> GetNextExamPatients(Paginations @params);
    public Task<IList<PatientDoctorViewModel>> Searching(string item, Paginations @params);

}
