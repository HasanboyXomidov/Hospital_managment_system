using Hospital_managment_system.Constants;
using Hospital_managment_system.Entities.Doctors;
using Hospital_managment_system.Entities.Nurses;
using Hospital_managment_system.Helpers;
using Hospital_managment_system.Interfaces.Departments;
using Hospital_managment_system.Interfaces.Doctors;
using Hospital_managment_system.Interfaces.Rooms;
using Hospital_managment_system.Repositories.Departments;
using Hospital_managment_system.Repositories.Doctors;
using Hospital_managment_system.Repositories.Rooms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Hospital_managment_system.Windows.Doctors
{
    /// <summary>
    /// Interaction logic for DoctorCreateWindow.xaml
    /// </summary>
    public partial class DoctorCreateWindow : Window
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDoctorRepository _repository;
        private readonly IRoomsRepository _roomsRepository;
        public DoctorCreateWindow()
        {
            InitializeComponent();
            this._repository= new DoctorRepository();
            this._departmentRepository = new DepartmentRepository();
            this._roomsRepository=new RoomsRepository();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            //var doctor = GetDataFromUi();
            Doctor doctor = new Doctor();
            if (!String.IsNullOrEmpty(lblName.Text))
                doctor.name = lblName.Text;
            else doctor.name = "doctor";

            if (!String.IsNullOrEmpty(lblSurName.Text))
                doctor.surname = lblSurName.Text;
            else doctor.surname = "Nobodoy";

            if (MaleRb.IsChecked == true) {doctor.is_male = true;}
            if (FemaleRb.IsChecked == true) { doctor.is_male= false;}

            if (!String.IsNullOrEmpty(Adresslbl.Text))
                doctor.adress = Adresslbl.Text;
            else doctor.adress = "NoWhere";

            if (!String.IsNullOrEmpty(Tel_Numberlbl.Text))
                doctor.tel_number = Tel_Numberlbl.Text;
            else doctor.tel_number = "NoWhere";

            if (DateBirthdp.SelectedDate is not null)
                doctor.date_birth = DateOnly.FromDateTime(DateBirthdp.SelectedDate.Value);
            else doctor.date_birth = DateOnly.FromDateTime(TimeHelper.GetDateTime());

            if (!String.IsNullOrEmpty(Descriptiontb.Text))
                doctor.description = Descriptiontb.Text;
            else doctor.description = "No Description";

            string image_path = ImgBImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(image_path))
            {
                doctor.Passport_Image_Path = await CopyImageAsync(image_path, ContentConstants.IMAGE_CONTENTS_PATH);
            }


            doctor.created_at = doctor.updated_at = TimeHelper.GetDateTime();

            doctor.department_id = (long)departmentcb.SelectedValue;

            doctor.rooms_id = (long)Roomnumbercb.SelectedValue;

            var result = await _repository.CreateAsync(doctor);

            if (result > 0)
            {
                MessageBox.Show("Created Doctor");
                this.Close();
            }
            else MessageBox.Show("Something Wrong");

            

        }
        //public async Doctor GetDataFromUi()
        //{
         

        //}
        private OpenFileDialog GetImageDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            return openFileDialog;
        }
        private async Task<string> CopyImageAsync(string imgPath, string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            var imageName = ContentNameMaker.GetImageName(imgPath);

            string path = System.IO.Path.Combine(destinationDirectory, imageName);

            byte[] image = await File.ReadAllBytesAsync(imgPath);

            await File.WriteAllBytesAsync(path, image);

            return path;
        }

        private void ImageBut_Click(object sender, RoutedEventArgs e)
        {
            var openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == true)
            {
                string imgpath = openfiledialog.FileName;
                ImgBImage.ImageSource = new BitmapImage(new Uri(imgpath, UriKind.Relative));

            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var departments = await _departmentRepository.GetAllAsync(new Utilities.Paginations()
            {
                PageNumber = 1,
                PageSize = 100
            }
                );
            departmentcb.ItemsSource = departments;

            var rooms = await _roomsRepository.GetEmptyRooms(new Utilities.Paginations()
            {
                PageNumber=1,
                PageSize = 100
            }
                );
            Roomnumbercb.ItemsSource = rooms;


        }
    }
}
