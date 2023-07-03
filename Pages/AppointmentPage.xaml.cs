using Hospital_managment_system.Components.Appointments;
using Hospital_managment_system.Interfaces.Patient_Doctors;
using Hospital_managment_system.Repositories.PatientsDoctors;
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

namespace Hospital_managment_system.Pages
{
    /// <summary>
    /// Interaction logic for AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page
    {
        private readonly IPatientDoctorRepository _patientDoctorRepository;

        public AppointmentPage()
        {
            InitializeComponent();
            this._patientDoctorRepository=new PatientsDoctorsRepository();
            
        }
        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.None && e.Key == Key.Add)
            {                
                Appointment_Window appointment_Window = new Appointment_Window();
                appointment_Window.ShowDialog();
                MainWP.Children.Clear();
            }
            await refreshAsync();
        }


        private async void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            Appointment_Window appointment_Window = new Appointment_Window();
            appointment_Window.ShowDialog();
            MainWP.Children.Clear();
            await refreshAsync();
        }        
        private async void Page_Loaded_1(object sender, RoutedEventArgs e)
        {            
            await refreshAsync();
        }
        public async Task refreshAsync()
        {
            MainWP.Children.Clear();
            var getruslt = await _patientDoctorRepository.GetAllAsync(new Utilities.Paginations()
            {
                PageNumber = 1,
                PageSize = 30
            });
            foreach (var item in getruslt)
            {
                AppointmentsViewUserControl appointmentsViewUserControl = new AppointmentsViewUserControl();
                appointmentsViewUserControl.setData(item);
                MainWP.Children.Add(appointmentsViewUserControl);
            }
            var getTodaysTotal = await _patientDoctorRepository.GetTodaysTotalAppointment();
            var getYesterdaysTotal = await _patientDoctorRepository.GetYesterdaysTotalAppointment();
            var getWeeklyTotal = await _patientDoctorRepository.GetWeeklyAllAppointment();
            var getmonthlyTotal = await _patientDoctorRepository.MonthlyAllAppointments();

            Todays_Total_Appointment.Content = getTodaysTotal;
            Yesterday_Total_Appointment.Content = getYesterdaysTotal;
            lblweaklyall.Content = getWeeklyTotal;
            Monthly_Total_Appointments.Content = getmonthlyTotal;
        }
    }
}
