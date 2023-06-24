using Hospital_managment_system.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces.Departments;

public interface IDepartmentRepository:IRepository<Department,Department>
{
    public Task<int> GetTotalDepartment();
    
}
