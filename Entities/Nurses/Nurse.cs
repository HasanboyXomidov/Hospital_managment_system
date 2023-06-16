using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.Nurses;

public sealed class Nurse : Human
{
    public float salary { get; set; }
    public string image_path { get; set; } = string.Empty;
}
