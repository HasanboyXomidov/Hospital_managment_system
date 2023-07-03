using Hospital_managment_system.Components.BedPatients;
using Hospital_managment_system.Interfaces.Bed_patients;
using Hospital_managment_system.Repositories.Bed_patients;
using Hospital_managment_system.Utilities;
using Hospital_managment_system.ViewModels.BedPatientsV;
using Hospital_managment_system.ViewModels.PatientDoctorV;
using Hospital_managment_system.Windows.BedPatients;
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
    /// Interaction logic for Patient.xaml
    /// </summary>
    public partial class Patient : Page
    {
        private readonly IBed_PatientsRepository _repository;
        public IList<BedPatientsViewModel> bedPatientsViewModels { get; set; }

        public Patient()
        {
            InitializeComponent();
            this._repository = new Bed_patientsRepository();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            BedPatientsWindow bedPatientsWindow = new BedPatientsWindow();
            bedPatientsWindow.Show();

        }
        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.None && e.Key == Key.Add)
            {
                BedPatientsWindow bedPatientsWindow = new BedPatientsWindow();
                bedPatientsWindow.ShowDialog();
                MainWP.Children.Clear();
                await refreshasync();

            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await refreshasync();
        }
        public async Task refreshasync()
        {
            Paginations paginations = new Paginations()
            {
                PageNumber = 1,
                PageSize = 30
            };
            bedPatientsViewModels = await _repository.GetAllAsync(paginations);
            foreach (var item in bedPatientsViewModels)
            {
                BedPatientsViewUserControl bedPatientsViewUserControl = new BedPatientsViewUserControl();
                bedPatientsViewUserControl.setData(item);
                MainWP.Children.Add(bedPatientsViewUserControl);

            }
        }

        private async void Search_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                MainWP.Children.Clear();
                var searchBedPatients = bedPatientsViewModels.Where(d => d.name.ToUpper().Contains(Search.Text.ToUpper()));
                foreach ( var item in searchBedPatients)
                {
                    BedPatientsViewUserControl bedPatientsViewUserControl = new BedPatientsViewUserControl();
                    bedPatientsViewUserControl.setData(item);
                    MainWP.Children.Add(bedPatientsViewUserControl);
                }

            }
        }
    }
}
