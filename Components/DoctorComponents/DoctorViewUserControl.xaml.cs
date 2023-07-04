using Hospital_managment_system.Components.Departments;
using Hospital_managment_system.Entities.Doctors;
using Hospital_managment_system.Entities.Nurses;
using Hospital_managment_system.Entities.PatientsDoctors;
using Hospital_managment_system.Interfaces;
using Hospital_managment_system.Interfaces.Doctors;
using Hospital_managment_system.Interfaces.Patient_Doctors;
using Hospital_managment_system.Repositories.Doctors;
using Hospital_managment_system.ViewModels.Doctors;
using Hospital_managment_system.Windows.Doctors;
using MaterialDesignThemes.Wpf;
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

namespace Hospital_managment_system.Components.DoctorComponents
{
    /// <summary>
    /// Interaction logic for DoctorViewUserControl.xaml
    /// </summary>
    public partial class DoctorViewUserControl : UserControl
    {
        public long Id { get; private set; }
        public bool isVisible { get; set; } = false;
        private readonly IDoctorRepository _repository;
        public DoctorsViewModel DoctorsViewModel { get; set; }
        public DoctorViewUserControl()
        {
            InitializeComponent();
            this._repository = new DoctorRepository();
            DoctorsViewModel  = new DoctorsViewModel();  
        }
        public void setData(DoctorsViewModel doctor)
        {

            string f = doctor.surname;
            string i = doctor.name;
            DoctorFio.Content = f + ' ' + i;
            numberlbl.Content = "Tel : " +doctor.tel_number;
            DoctorPosition.Content = doctor.department;
            ImgBImage.ImageSource = new BitmapImage(new System.Uri(doctor.passport_image_path, UriKind.Relative));
            
            DoctorsViewModel = doctor;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!isVisible)
            {
                EditDelete.Visibility = Visibility.Visible;
                isVisible= true;
                
            }
            else
            {
                EditDelete.Visibility= Visibility.Hidden; 
                isVisible= false;
            }



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DoctorShowRoom doctorShowRoom = new DoctorShowRoom();
            doctorShowRoom.setDataTosShowRoom(DoctorsViewModel);
            doctorShowRoom.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DoctorUpdateWindow doctorUpdateWindow = new DoctorUpdateWindow();
            doctorUpdateWindow.setDate(DoctorsViewModel);
            doctorUpdateWindow.ShowDialog();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete ?",
                   "Delete file",
            MessageBoxButton.YesNo,
                   MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var dll = await _repository.DeleteAsync(DoctorsViewModel.Id);
                if (dll > 0) MessageBox.Show("Deleted!!");
                else MessageBox.Show("Not Deleted !!");
            }
            else MessageBox.Show("Something wrong ");
        }
    }
}
