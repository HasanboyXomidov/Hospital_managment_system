using Hospital_managment_system.Components.Departments;
using Hospital_managment_system.Entities.Doctors;
using Hospital_managment_system.Entities.Nurses;
using Hospital_managment_system.ViewModels.Doctors;
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
        public DoctorViewUserControl()
        {
            InitializeComponent();
        }
        public void setData(DoctorsViewModel doctor)
        {

            string f = doctor.surname;
            string i = doctor.name;
            DoctorFio.Content = f + ' ' + i;
            numberlbl.Content = "Tel : " +doctor.tel_number;
            DoctorPosition.Content = doctor.department;
            ImgBImage.ImageSource = new BitmapImage(new System.Uri(doctor.passport_image_path, UriKind.Relative));


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
    }
}
