using Hospital_managment_system.Entities.BedRooms;
using Hospital_managment_system.ViewModels.BedRooms;
using Hospital_managment_system.Windows.BedRooms;
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

namespace Hospital_managment_system.Components.BedRooms
{
    /// <summary>
    /// Interaction logic for BedRoomsViewModel.xaml
    /// </summary>
    public partial class BedRoomsViewUserControl : UserControl
    {        
        private BedRoom BedRoom { get; set; }
        public bool isvisible { get; set; }=false;
        public BedRoomsViewUserControl()
        {
            InitializeComponent();
            BedRoom = new BedRoom();    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        public void setData(BedRoomsViewModel viewModel)
        {            
            lblRoomNumber.Content = viewModel.room_number;

            if(viewModel.is_free==true) { lblIsEmpty.Content = "Empty"; }
            else { lblIsEmpty.Content = "Not Empty"; }
            
            lblCapacity.Content = viewModel.capacity;
            lblRoomitype.Content = viewModel.room_type;
            lblBedRoomID.Content = viewModel.Id;

            BedRoom.Id=viewModel.Id;
            BedRoom.Name = viewModel.name;
            BedRoom.capacity = viewModel.capacity;
            BedRoom.is_empty = viewModel.is_free;
            BedRoom.room_number = viewModel.room_number;
            BedRoom.description = viewModel.description;
            //BedRoom.room_type_id = 

        }
        //public void setData2(BedRoom bedRoom)
        //{
        //    lblCapacity.Content = bedRoom.capacity;
        //    BedRoom = bedRoom;
        //}



        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            BedRoomsUpdateWindow bedRoomsUpdateWindow = new BedRoomsUpdateWindow();
            bedRoomsUpdateWindow.setData(BedRoom);
            bedRoomsUpdateWindow.ShowDialog();

        }
    }
}
