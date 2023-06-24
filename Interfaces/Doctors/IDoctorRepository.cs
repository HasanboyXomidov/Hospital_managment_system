using Hospital_managment_system.Entities.Doctors;
using Hospital_managment_system.ViewModels.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces.Doctors;

public interface IDoctorRepository : IRepository<Doctor,DoctorsViewModel>
{
    public Task<int> CountDoctor();
}
