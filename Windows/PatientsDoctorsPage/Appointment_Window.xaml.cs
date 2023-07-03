using Hospital_managment_system.Entities.PatientsDoctors;
using Hospital_managment_system.Helpers;
using Hospital_managment_system.Interfaces.Bed_patients;
using Hospital_managment_system.Interfaces.Doctors;
using Hospital_managment_system.Interfaces.Patient_Doctors;
using Hospital_managment_system.Repositories.Bed_patients;
using Hospital_managment_system.Repositories.Doctors;
using Hospital_managment_system.Repositories.PatientsDoctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital_managment_system.Windows.PatientsDoctorsPage
{
    /// <summary>
    /// Interaction logic for Appointment_Window.xaml
    /// </summary>
    public partial class Appointment_Window : Window
    {
        private readonly IPatientDoctorRepository _patientdoctor;
        private readonly IBed_PatientsRepository _repository;
        private readonly IDoctorRepository _doctorRepository;
        PatientDoctor patientDoctor = new PatientDoctor();
        public Appointment_Window()
        {
            InitializeComponent();
            this._patientdoctor=new PatientsDoctorsRepository();
            this._repository = new Bed_patientsRepository();
            this._doctorRepository=new DoctorRepository ();

        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            patientDoctor.patient_id = (long)cbpatientname.SelectedValue;
            patientDoctor.doctor_id = (long)cbdoktorname.SelectedValue;
            patientDoctor.next_exam_day = int.Parse(lblNextExam.Text);
            patientDoctor.doctor_exam_cost = float.Parse(Doctor_exam_cost.Text);
            patientDoctor.description = lbldescription.Text;
            patientDoctor.created_at = patientDoctor.updated_at = TimeHelper.GetDateTime();
            patientDoctor.cur_date = DateOnly.FromDateTime(DateTime.Today);
            var getdoctorQueue = await _patientdoctor.GetCurrentQueue((long)cbdoktorname.SelectedValue);
            patientDoctor.patient_queue = getdoctorQueue + 1;

            var result = await _patientdoctor.CreateAsync(patientDoctor);
            if (result > 0) {MessageBox.Show("Appointment Created"); this.Close(); 
                QueueWindowShow queueWindowShow = new QueueWindowShow();
                queueWindowShow.setData(patientDoctor);
                queueWindowShow.ShowDialog();
                    }
            else MessageBox.Show("Not Created!!");

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {           
            var bedPatients = await _repository.GetAllAsync(new Utilities.Paginations()
            {
                PageNumber = 1,
                PageSize = 100
            }
            );
            cbpatientname.ItemsSource = bedPatients;
            var doctors = await _doctorRepository.GetAllAsync(new Utilities.Paginations() 
            { PageNumber = 1,
                PageSize = 30 
            });
            cbdoktorname.ItemsSource = doctors;
            


            //patientDoctor.patient_queue =
        }

        private void Doctor_exam_cost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DoctorNextExamDay_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
