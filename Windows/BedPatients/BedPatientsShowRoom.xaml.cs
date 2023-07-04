using Hospital_managment_system.ViewModels.BedPatientsV;
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
    /// Interaction logic for BedPatientsShowRoom.xaml
    /// </summary>
    public partial class BedPatientsShowRoom : Window
    {
        public BedPatientsShowRoom()
        {
            InitializeComponent();
        }
        public void setData(BedPatientsViewModel viewModel)
        {
            lblname.Content = viewModel.name;
            lblsurname.Content = viewModel.surname;
            lbldatebirth.Content = viewModel.date_birth;
            lbladress.Content = viewModel.adress;
            if(viewModel.is_male==true) { lblismale.Content = "Male"; }
            else { lblismale.Content = "Female"; }
            lbltel_number.Content = viewModel.tel_number;
            lblcometime.Content = viewModel.comeTime;
            lblleave_time.Content = viewModel.leaveTime;
            lblroom_number.Content = viewModel.room_number;
            lbldescription.Content = viewModel.description;
            lblallergies.Content = viewModel.allergies;
            lblwherecomefrom.Content = viewModel.where_come_from;
        }
    }
}
