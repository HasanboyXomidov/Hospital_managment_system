using Hospital_managment_system.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.ViewModels.PatientDoctorV;

public class PatientDoctorViewModel
{
    public long id { get; set; }
    [MaxLength(100)]
    public string patientfio { get; set; }
    [MaxLength(100)]
    public string gender_age { get; set; }
    [MaxLength(15)]
    public string tel_number { get; set; }
    [MaxLength(150)]
    public string doctorfio { get; set; }
    public DateTime cur_date { get; set; }= DateTime.Now.Date;
    public int patientQueue { get ; set; }
    public float doctorExamCost { get; set; }
    public string description { get; set; }
    public int next_exam { get; set; }

}
