using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.EmergencyPersons;

public sealed class EmergencyPerson : Auditable
{
    [MaxLength(50)]
    public string name { get; set; }  = string.Empty;
    [MaxLength(50)]
    public string surname { get; set; }= string.Empty;
    [MaxLength(100)]
    public string adress { get; set; } = string.Empty;
    [MaxLength(15)]
    public string tel_number { get; set; } = string.Empty;

}
