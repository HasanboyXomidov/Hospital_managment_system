using Hospital_managment_system.Entities.Surjeries;
using Hospital_managment_system.Interfaces.Surjeries;
using Hospital_managment_system.Utilities;
using Hospital_managment_system.ViewModels.Surjeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Repositories.Surjeries;

public class SurjeryRepository : BaseRepository, ISurjeryRepository
{
    public Task<int> CreateAsync(Surjery obj)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<SurjeryView>> GetAllAsync(Paginations @params)
    {
        throw new NotImplementedException();
    }

    public Task<SurjeryView> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Surjery editObj)
    {
        throw new NotImplementedException();
    }
}
