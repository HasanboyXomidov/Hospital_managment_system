using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.Departments;

public sealed class Department : Auditable
{
    [MaxLength(100)]
    public string name { get; set; } = string.Empty;
    public bool is_active {  get; set; }
    public string description { get; set; } = string.Empty;

}
