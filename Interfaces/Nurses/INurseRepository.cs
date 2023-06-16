using Hospital_managment_system.Entities.Nurses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces.Nurses;

public interface INurseRepository: IRepository<Nurse,Nurse>
{
    public Task<int> CountAync();
}
