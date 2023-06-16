using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities;

public abstract class Human : Auditable
{
    [MaxLength(50)]
    public string name { get; set; }
    [MaxLength(50)]
    public string surname {  get; set; } = string.Empty;
    [MaxLength (15)]
    public string tel_number { get ; set; } = string.Empty;        
    public DateOnly date_birth { get; set; }
    public string Passport_Image_Path { get; set; } = string.Empty;
    public bool is_male { get; set; }
    [MaxLength (100)]
    public string adress {get; set; } = string.Empty;
    public string description {get; set; } = string.Empty;


 
       


    // id , name , surname , date_birth , adress , tel number , passport_image_path
}
