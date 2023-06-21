using Hospital_managment_system.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.ViewModels.Doctors;

public sealed class DoctorsViewModel: Auditable
{
    [MaxLength(50)]
    public string name { get; set; }
    [MaxLength(50)]
    public string surname { get; set; }
    public bool is_male { get; set; }
    [MaxLength(100)]
    public string adress { get; set; }
    [MaxLength(15)]
    public string tel_number { get; set; }
    public DateOnly date_birth { get; set; }
    [MaxLength(50)]
    public string department { get; set; }
    public int room { get; set; }
    public string description { get; set; }=string.Empty;    

}
