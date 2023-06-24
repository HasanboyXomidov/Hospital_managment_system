using Hospital_managment_system.Windows.OthersPage;
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

namespace Hospital_managment_system.Pages
{
    /// <summary>
    /// Interaction logic for OthersPage.xaml
    /// </summary>
    public partial class OthersPage : Page
    {
        public OthersPage()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            RoomCreateWindow roomCreateWindow = new RoomCreateWindow();
            roomCreateWindow.ShowDialog();

        }

        private void BtnCreate_Click_1(object sender, RoutedEventArgs e)
        {
            RoomTypeCreateWindow roomTypeCreateWindow = new RoomTypeCreateWindow(); 
            roomTypeCreateWindow.ShowDialog();
        }

        private void BtnCreate_2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCreate_3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
