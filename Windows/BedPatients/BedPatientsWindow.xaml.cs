using Hospital_managment_system.Entities.BedPatients;
using Hospital_managment_system.Helpers;
using Hospital_managment_system.Interfaces.Bed_patients;
using Hospital_managment_system.Interfaces.BedRooms;
using Hospital_managment_system.Interfaces.Doctors;
using Hospital_managment_system.Repositories.Bed_patients;
using Hospital_managment_system.Repositories.BedRooms;
using Hospital_managment_system.Repositories.Doctors;
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
using System.Windows.Shapes;

namespace Hospital_managment_system.Windows.BedPatients
{
    /// <summary>
    /// Interaction logic for BedPatientsWindow.xaml
    /// </summary>
    public partial class BedPatientsWindow : Window
    {
        private readonly IBedRoomsRepository _doctorRepository;
        private readonly IBed_PatientsRepository _PatientsRepository;
        public BedPatientsWindow()
        {
            InitializeComponent();
            this. _doctorRepository = new BedRoomRepository();
            this._PatientsRepository = new Bed_patientsRepository();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var doctors = await _doctorRepository.GetAllAsync(new Utilities.Paginations()
            { PageNumber = 1 ,
            PageSize = 100 }                
            );
            Roomnumbercb.ItemsSource = doctors;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            BedPatient bedPatient = new BedPatient();
            bedPatient.name = lblName.Text;
            bedPatient.surname=lblSurName.Text;
            if (FemaleRb.IsChecked == true) bedPatient.is_male = false;
            else bedPatient.is_male = true;
            bedPatient.adress = Adresslbl.Text;
            bedPatient.tel_number = Tel_Numberlbl.Text;
            if (DateBirthdp.SelectedDate is not null) { bedPatient.date_birth = DateOnly.FromDateTime(DateBirthdp.SelectedDate.Value); }             
            
            bedPatient.where_come_from = WhereComFrom.Text;
            bedPatient.bed_room_id = (long)Roomnumbercb.SelectedValue;
            bedPatient.description = Descriptiontb.Text;
            bedPatient.allergies = Allergies.Text;
            bedPatient.come_time = TimeHelper.GetDateTime();
            if(LeaveDateP.SelectedDate is not null) { bedPatient.leave_date = DateOnly.FromDateTime(LeaveDateP.SelectedDate.Value); }
            else bedPatient.leave_date= DateOnly.FromDateTime(TimeHelper.GetDateTime());

            var result = await _PatientsRepository.CreateAsync(bedPatient);
            if (result > 0) MessageBox.Show("Created Patient");
            else MessageBox.Show("Not Created ");


        }

        private void Tel_Numberlbl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
