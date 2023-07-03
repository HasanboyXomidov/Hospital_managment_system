using Hospital_managment_system.Entities.BedRooms;
using Hospital_managment_system.Entities.PatientsDoctors;
using Hospital_managment_system.Interfaces.Patient_Doctors;
using Hospital_managment_system.Repositories.PatientsDoctors;
using Hospital_managment_system.ViewModels.PatientDoctorV;
using Hospital_managment_system.Windows.PatientsDoctorsPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital_managment_system.Components.Appointments
{
    /// <summary>
    /// Interaction logic for AppointmentsViewUserControl.xaml
    /// </summary>
    public partial class AppointmentsViewUserControl : UserControl
    {
        private readonly IPatientDoctorRepository _patientDoctorRepository;
        public bool isvisible { get; set; } = false;
        private PatientDoctor PatientDoctor { get; set; }

        public AppointmentsViewUserControl()
        {
            InitializeComponent();
            PatientDoctor = new PatientDoctor();
            this._patientDoctorRepository = new PatientsDoctorsRepository();
        }                
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
        public void setData(PatientDoctorViewModel viewModel)
        {
            lblqueue.Content = viewModel.patientQueue;
            lblname.Content = viewModel.patientfio;
            //lblGender.Content = viewModel.gender_age;
            lblphone.Content = viewModel.tel_number;
            lbldoctorname.Content = viewModel.doctorfio;
            lbltime.Content = viewModel.cur_date;

            PatientDoctor.Id = viewModel.id;
            PatientDoctor.doctor_exam_cost = viewModel.doctorExamCost;
            PatientDoctor.description = viewModel.description;
            PatientDoctor.next_exam_day = viewModel.next_exam;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            if (!isvisible)
            {
                grdEditDelete2.Visibility = Visibility.Visible;
                isvisible = true;
            }
            else
            {
                grdEditDelete2.Visibility = Visibility.Hidden;
                isvisible = false;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Appointment_Window_Update win = new Appointment_Window_Update();
            win.setData(PatientDoctor);
            win.ShowDialog();

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete ?",
                    "Delete file",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var dll = await _patientDoctorRepository.DeleteAsync(PatientDoctor.Id);
                if (dll > 0) MessageBox.Show("Deleted!!");
                else MessageBox.Show("Not Deleted !!");
            }
            else MessageBox.Show("Something wrong ");
                   
        }
    }
}
