using Hospital_managment_system.ViewModels.PatientDoctorV;
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
        public bool button {  get ; set; }=false;
        public AppointmentsViewUserControl()
        {
            InitializeComponent();
        }                
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!button) { grdEditDelete2.Visibility = Visibility.Visible; button = true; }
            else grdEditDelete2.Visibility = Visibility.Hidden; button = false;
        }
        public void setData(PatientDoctorViewModel viewModel)
        {
            lblqueue.Content = viewModel.patientQueue;
            lblname.Content = viewModel.patientfio;
            //lblGender.Content = viewModel.gender_age;
            lblphone.Content = viewModel.tel_number;
            lbldoctorname.Content = viewModel.doctorfio;
            lbltime.Content = viewModel.cur_date;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            if(!button) { grdEditDelete2.Visibility=Visibility.Visible; button = true; }
            else grdEditDelete2.Visibility=Visibility.Hidden; button = false;
        }
    }
}
