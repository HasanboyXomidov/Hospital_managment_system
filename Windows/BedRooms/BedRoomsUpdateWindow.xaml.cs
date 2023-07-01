using Hospital_managment_system.Entities.BedRooms;
using Hospital_managment_system.Interfaces.BedRooms;
using Hospital_managment_system.Interfaces.RoomTypes;
using Hospital_managment_system.Repositories.BedRooms;
using Hospital_managment_system.Repositories.RoomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital_managment_system.Windows.BedRooms
{
    /// <summary>
    /// Interaction logic for BedRoomsUpdateWindow.xaml
    /// </summary>
    public partial class BedRoomsUpdateWindow : Window        
    {
        public BedRoom room { get; set; }

        private readonly IRoomTypesRepository _roomTypesRepository;
        private readonly IBedRoomsRepository _bedRoomsRepository;
        public BedRoomsUpdateWindow()
        {
            InitializeComponent();
            this._roomTypesRepository = new RoomTypeRepository();
            this._bedRoomsRepository = new BedRoomRepository();
            room = new BedRoom();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (!String.IsNullOrEmpty(lblName.Text)) { room.Name = lblName.Text; }
            else { room.Name = "NoName"; }

            if (!String.IsNullOrEmpty(Capacitylbl.Text)) { room.capacity = int.Parse(Capacitylbl.Text); }
            else { room.capacity = 0; }

            if (YesRb.IsChecked == true) { room.is_empty = true; }
            else
            {
                room.is_empty = false;
            }

            if (!String.IsNullOrEmpty(Room_Numberlbl.Text)) { room.room_number = int.Parse(Room_Numberlbl.Text); }
            else room.room_number = 0;

            if (RoomTypeCb.SelectedValue == null) room.room_type_id = 1;
            else
            {
                room.room_type_id = (long)RoomTypeCb.SelectedValue;
            }
            

            room.description = Descriptiontb.Text;

            room.Id = long.Parse(lblid.Content.ToString());



            var result = await _bedRoomsRepository.UpdateAsync(room.Id, room);
            if (result > 0) { MessageBox.Show("Successfully updated Bed Room"); this.Close(); }
            else MessageBox.Show("SomethingWrong");


            //if()
        }
        public void setData(BedRoom bedRoom)
        {
            lblName.Text = bedRoom.Name;
            Capacitylbl.Text = (bedRoom.capacity).ToString();
            if(bedRoom.is_empty == true) { YesRb.IsChecked = true; }
            else { YesRb.IsChecked = false;}
            Room_Numberlbl.Text = (bedRoom.room_number).ToString();
            Desciption.Text= bedRoom.description;
            lblid.Content = bedRoom.Id;

        }

        private void Capacitylbl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Room_Numberlbl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var roomtyper = await _roomTypesRepository.GetAllAsync(new Utilities.Paginations()
            {
                PageNumber = 1,
                PageSize = 100
            }
            );
            RoomTypeCb.ItemsSource = roomtyper;
            
        }
    }
}
