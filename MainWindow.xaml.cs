using Hospital_managment_system.Entities.PatientsDoctors;
using Hospital_managment_system.Pages;
using Hospital_managment_system.Windows;
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

namespace Hospital_managment_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rbDashboard_Click(object sender, RoutedEventArgs e)
        {
            DashboardPage dashboardpage = new DashboardPage();
            PageNavigator.Content = dashboardpage;
            
        }

        private void rbAppointment_Checked(object sender, RoutedEventArgs e)
        {
            AppointmentPage appointmentpage = new AppointmentPage();
            PageNavigator.Content = appointmentpage;
        }

        private void rbPatient_Click(object sender, RoutedEventArgs e)
        {
            
            Patient patient = new Patient();
            PageNavigator.Content = patient;
        }

        private void rbSurjeries_Click(object sender, RoutedEventArgs e)
        {
            SurjeriePage surjeripage = new SurjeriePage();
            PageNavigator.Content = surjeripage;            
        }

        private void rbBed_Managment_Click(object sender, RoutedEventArgs e)
        {
            
            BedMangmentPage page = new BedMangmentPage();
            PageNavigator.Content = page;

        }

        private void rbStaff_Click(object sender, RoutedEventArgs e)
        {
            StaffPage page = new StaffPage();
            PageNavigator.Content = page;
        }

        private void rbPayment_Click(object sender, RoutedEventArgs e)
        {
            PaymentPage page = new PaymentPage();
            PageNavigator.Content = page;
        }

        private void rbBMessage_Click(object sender, RoutedEventArgs e)
        {
            MessagePage page    = new MessagePage();
            PageNavigator.Content = page;
        }

        private void rbComplaint_Click(object sender, RoutedEventArgs e)
        {
            ComplaintPage page = new ComplaintPage();
            PageNavigator.Content = page;
        }

        private void rbDoctor_Checked(object sender, RoutedEventArgs e)
        {
            DoctorPage doctorpage = new DoctorPage();
            PageNavigator.Content = doctorpage;
        }

        private void rbDepartment_Checked(object sender, RoutedEventArgs e)
        {
            Department department = new Department();
            PageNavigator.Content = department;
        }

        private void rbOthers_Click_1(object sender, RoutedEventArgs e)
        {
            OthersPage othersPage = new OthersPage();
            PageNavigator.Content = othersPage;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login_page login_Page = new Login_page();
            login_Page.ShowDialog();
            this.Show();

        }

        private void Doc_Border_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Doc_Border_Click_1(object sender, RoutedEventArgs e)
        {
            DocumentationPage documentationPage = new DocumentationPage();
            PageNavigator.Content = documentationPage;
        }
    }
}
