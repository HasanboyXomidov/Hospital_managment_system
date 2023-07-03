using Hospital_managment_system.Components.Messages;
using Hospital_managment_system.Interfaces.Patient_Doctors;
using Hospital_managment_system.Repositories.PatientsDoctors;
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
    /// Interaction logic for MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        private readonly IPatientDoctorRepository _patientDoctorRepository;
        public MessagePage()
        {
            InitializeComponent();
            this._patientDoctorRepository=new PatientsDoctorsRepository();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await _patientDoctorRepository.GetNextExamPatients(new Utilities.Paginations()
            {
                PageNumber = 1,
                PageSize = 30
            });
            foreach (var patient in result)
            {
                MessagesViewUserControl messagesViewUserControl = new MessagesViewUserControl();
                messagesViewUserControl.setData(patient);
                MainWP.Children.Add(messagesViewUserControl);
            }
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
