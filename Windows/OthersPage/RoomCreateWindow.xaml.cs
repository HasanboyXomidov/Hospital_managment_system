using Hospital_managment_system.Entities;
using Hospital_managment_system.Entities.Rooms;
using Hospital_managment_system.Interfaces.Rooms;
using Hospital_managment_system.Repositories.Rooms;
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

namespace Hospital_managment_system.Windows.OthersPage
{
    /// <summary>
    /// Interaction logic for RoomCreateWindow.xaml
    /// </summary>
    public partial class RoomCreateWindow : Window
    {
        public IRoomsRepository _roomRepository;
        public RoomCreateWindow()
        {
            InitializeComponent();
            this._roomRepository = new RoomsRepository();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            if (lblName.Text.Length > 0 && lblName.Text.Length < 50 ) { count++; }
            
            if (Roomnumberlbl.Text.Length > 0 && Roomnumberlbl.Text.Length <10 ) { count++; }
            OtherRoom room = new OtherRoom();
            room.Name=lblName.Text;
            room.room_number = Convert.ToInt32(Roomnumberlbl.Text);
            if (cbIs_active.IsChecked == true) { room.is_empty = true; }
            else { room.is_empty = false;}
            room.description= new TextRange(dslbl.Document.ContentStart, dslbl.Document.ContentEnd).Text;
            
            var result = await _roomRepository.CreateAsync(room);
            if(result>0 ) { MessageBox.Show("Room Created"); this.Close(); }
            else MessageBox.Show("Not Created");

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void RoomNumberlbl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
