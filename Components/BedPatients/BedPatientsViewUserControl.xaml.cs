using Hospital_managment_system.ViewModels.BedPatientsV;
using Hospital_managment_system.Windows.BedPatients;
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

namespace Hospital_managment_system.Components.BedPatients
{
    /// <summary>
    /// Interaction logic for BedPatientsViewUserControl.xaml
    /// </summary>
    /// 
    public partial class BedPatientsViewUserControl : UserControl
    {
        public bool isvisible { get; set; } = false;
        public BedPatientsViewModel BedPatientsViewModel { get; set; }
        public BedPatientsViewUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             
        }
       public void setData(BedPatientsViewModel viewModel)
        {
            lblRoomNumber.Content = viewModel.name;
            if (viewModel.is_male == true) { lblIsMale.Content = "Male"; }
            else lblIsMale.Content = "Female";
            lblphone.Content = viewModel.tel_number;
            lblroom.Content = viewModel.room_number;
            lblComeDate.Content = viewModel.comeTime;
            lblLeaveDate.Content = viewModel.leaveTime;

            BedPatientsViewModel=viewModel;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isvisible)
            {
                grdEditDelete2.Visibility = Visibility.Visible;
                isvisible = true;
            }
            else
            {
                grdEditDelete2.Visibility = Visibility.Hidden;
                isvisible = false;
            }


        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewProfile_Click(object sender, RoutedEventArgs e)
        {
            BedPatientsShowRoom bedPatientsShowRoom = new BedPatientsShowRoom();
            bedPatientsShowRoom.setData(BedPatientsViewModel);
            bedPatientsShowRoom.ShowDialog();

        }
    }
}
