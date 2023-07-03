using Hospital_managment_system.Entities.Rooms;
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

namespace Hospital_managment_system.Components.Others
{
    /// <summary>
    /// Interaction logic for RoomCreateUserControl.xaml
    /// </summary>
    public partial class RoomCreateUserControl : UserControl
    {
        public RoomCreateUserControl()
        {
            InitializeComponent();
        }
        public void setData(OtherRoom otherRoom)
        {
            Number.Content = otherRoom.room_number;
            lblroomname.Content = otherRoom.name;

            if(otherRoom.is_free==true) { lblisfree.Content = "Empty"; }
            else { lblisfree.Content = "Not Empty"; }
            lblDescription.Content = otherRoom.description;


        }
    }
}
