using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.Doctors;

public sealed class Doctor : Human
{   // Doktorning qaysi bolimda ishlashi "Department"
    public long department_id { get; set; }
    public long rooms_id { get; set; }
    public string description { get; set; } = string.Empty;
    public string medical_education_image_path { get; set; } = string.Empty;
    public string higher_education_image_path { get; set; } = string.Empty;
    
}
