using Hospital_managment_system.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces;
// Umumiy hammasi uchun ishlaydigan interfacelar yoziladi
public interface IRepository<TModel , TViewModel>
{
    public Task<int> CreateAsync(TModel obj);
    public Task<int> UpdateAsync(long id, TModel editObj);
    public Task<int> DeleteAsync (long id);
    public Task<IList<TViewModel>> GetAllAsync(Paginations @params);
    public Task<TViewModel> GetAsync (long  id); 

}
