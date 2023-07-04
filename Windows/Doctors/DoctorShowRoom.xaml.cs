using Hospital_managment_system.Entities.Doctors;
using Hospital_managment_system.ViewModels.Doctors;
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

namespace Hospital_managment_system.Windows.Doctors
{
    /// <summary>
    /// Interaction logic for DoctorShowRoom.xaml
    /// </summary>
    public partial class DoctorShowRoom : Window
    {
        public DoctorShowRoom()
        {
            InitializeComponent();
        }
        public void setDataTosShowRoom(DoctorsViewModel viewModel)
        {
            lbldescription.Text = viewModel.description;
            lblname.Content = viewModel.name;
            lbldepartment.Content = viewModel.department;
            lblGender.Content = viewModel.is_male;
            lbllocation.Content = viewModel.adress;
            lblphone.Content = viewModel.tel_number;
            lbldatebirth.Content = viewModel.date_birth;
            lblroomnumber.Content = viewModel.room;
            ImgBImage.ImageSource = new BitmapImage(new System.Uri(viewModel.passport_image_path, UriKind.Relative));
        }
    }
}
