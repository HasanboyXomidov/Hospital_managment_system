using Hospital_managment_system.Entities.Doctors;
using Hospital_managment_system.Entities.RoomTypes;
using Hospital_managment_system.Helpers;
using Hospital_managment_system.Interfaces.RoomTypes;
using Hospital_managment_system.Repositories.RoomTypes;
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

namespace Hospital_managment_system.Windows.OthersPage
{
    /// <summary>
    /// Interaction logic for RoomTypeCreateWindow.xaml
    /// </summary>
    public partial class RoomTypeCreateWindow : Window
    {
        private readonly IRoomTypes _roomTypes;
        public RoomTypeCreateWindow()
        {
            InitializeComponent();
            this._roomTypes = new RoomTypeRepository();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            RoomType roomType = new RoomType();
            if (!String.IsNullOrEmpty(lblName.Text)) { roomType.name = lblName.Text; }
            else { roomType.name = "NoName"; }

            if (!String.IsNullOrEmpty(lblCost.Text)) { roomType.cost = float.Parse(lblCost.Text); }
            else { roomType.cost = 0; }

            roomType.created_at = roomType.updated_at = TimeHelper.GetDateTime();

            var result = await _roomTypes.CreateAsync(roomType);
            if (result > 0) { MessageBox.Show("Room Type Created "); this.Close(); }
            else MessageBox.Show("Not Created");


        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lblCost_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
