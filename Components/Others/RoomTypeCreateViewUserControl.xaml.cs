using Hospital_managment_system.Entities.RoomTypes;
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
    /// Interaction logic for RoomTypeCreateViewUserControl.xaml
    /// </summary>
    public partial class RoomTypeCreateViewUserControl : UserControl
    {
        public RoomTypeCreateViewUserControl()
        {
            InitializeComponent();
        }
        public void setData(RoomType room)
        {
            lblName.Content = room.name;
            lblcost.Content = room.cost;
        }
    }
}
