using Hospital_managment_system.Components.DoctorComponents;
using Hospital_managment_system.Interfaces.Doctors;
using Hospital_managment_system.Repositories.Doctors;
using Hospital_managment_system.Utilities;
using Hospital_managment_system.Windows.Doctors;
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
    /// Interaction logic for DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        private readonly IDoctorRepository _repository;
        
        public DoctorPage()
        {
            InitializeComponent();
            this._repository = new DoctorRepository();
        }


        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            DoctorCreateWindow doctorCreateWindow = new DoctorCreateWindow();
            doctorCreateWindow.ShowDialog();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            

            Paginations paginations = new Paginations()
            {
                PageNumber = 1,
                PageSize = 20               
            };
            var doctors = await _repository.GetAllAsync(paginations);
            var cntdoctor = await _repository.CountDoctor();
            CountDoctorlbl.Content ="Total " + cntdoctor.ToString() +" Doctors.";
            foreach ( var doctor in doctors)
            {
                DoctorViewUserControl doctorViewUserControl = new DoctorViewUserControl();
                doctorViewUserControl.setData(doctor);
                MainWP.Children.Add(doctorViewUserControl);
            }

        }
    }
}
