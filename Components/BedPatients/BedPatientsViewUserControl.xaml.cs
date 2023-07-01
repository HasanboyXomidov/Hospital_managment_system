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
        private bool button { get; set; } = false;
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

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!button) { grdEditDelete2.Visibility = Visibility.Visible; button = true; }
            else grdEditDelete2.Visibility=Visibility.Collapsed; button = false;


        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
