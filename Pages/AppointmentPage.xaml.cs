using Hospital_managment_system.Components.Appointments;
using Hospital_managment_system.Interfaces.Patient_Doctors;
using Hospital_managment_system.Repositories.PatientsDoctors;
using Hospital_managment_system.ViewModels.PatientDoctorV;
using Hospital_managment_system.Windows.PatientsDoctorsPage;
using Microsoft.EntityFrameworkCore;
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
        public IList<PatientDoctorViewModel> patientDoctorViewModels { get; set; }
        public AppointmentPage()
        {
            InitializeComponent();
            this._patientDoctorRepository = new PatientsDoctorsRepository();

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
            patientDoctorViewModels = await _patientDoctorRepository.GetAllAsync(new Utilities.Paginations()
            {
                PageNumber = 1,
                PageSize = 30
            });
            foreach (var item in patientDoctorViewModels)
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


   

        private async void Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MainWP.Children.Clear();                

                var results = patientDoctorViewModels.Where(d => d.patientfio.ToUpper().Contains(Search.Text.ToUpper()));                

                foreach (var item in results)
                {
                    AppointmentsViewUserControl appointmentsViewUserControl = new AppointmentsViewUserControl();
                    appointmentsViewUserControl.setData(item);
                    MainWP.Children.Add(appointmentsViewUserControl);
                }
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            MainWP.Children.Clear();

            DateTime yesterday = DateTime.Now.AddDays(-1).Date;
            var results = patientDoctorViewModels.Where(d => d.cur_date.Date == yesterday);

            foreach (var item in results)
            {
                AppointmentsViewUserControl appointmentsViewUserControl = new AppointmentsViewUserControl();
                appointmentsViewUserControl.setData(item);
                MainWP.Children.Add(appointmentsViewUserControl);
            }

        }

        private async void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {            
            MainWP.Children.Clear();            
            var results = patientDoctorViewModels.Where(d=>d.cur_date.Date == DateTime.Today.Date);
            foreach (var item in results)
            {
                AppointmentsViewUserControl appointmentsViewUserControl = new AppointmentsViewUserControl();
                appointmentsViewUserControl.setData(item);
                MainWP.Children.Add(appointmentsViewUserControl);
            }
            
        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            MainWP.Children.Clear();

            DateTime today = DateTime.Today;
            int offset = (today.DayOfWeek - DayOfWeek.Monday + 7) % 7; // Calculate the offset to Monday
            DateTime startOfWeek = today.AddDays(-offset); // Start of the week (Monday)
            DateTime endOfWeek = startOfWeek.AddDays(6); // End of the week (Sunday)

            var results = patientDoctorViewModels.Where(d => d.cur_date >= startOfWeek && d.cur_date <= endOfWeek);
            foreach (var item in results)
            {
                AppointmentsViewUserControl appointmentsViewUserControl = new AppointmentsViewUserControl();
                appointmentsViewUserControl.setData(item);
                MainWP.Children.Add(appointmentsViewUserControl);
            }
        }

        private void RadioButton_Click_3(object sender, RoutedEventArgs e)
        {
            MainWP.Children.Clear();

            DateTime currentMonthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // Start of the current month
            DateTime currentMonthEnd = currentMonthStart.AddMonths(1).AddDays(-1); // End of the current month

            var results = patientDoctorViewModels.Where(d => d.cur_date >= currentMonthStart && d.cur_date <= currentMonthEnd);
            foreach (var item in results)
            {
                AppointmentsViewUserControl appointmentsViewUserControl = new AppointmentsViewUserControl();
                appointmentsViewUserControl.setData(item);
                MainWP.Children.Add(appointmentsViewUserControl);
            }
        }

        private async void RadioButton_Click_4(object sender, RoutedEventArgs e)
        {
            await refreshAsync();
        }
    }
}
