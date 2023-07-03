using Hospital_managment_system.Components.Others;
using Hospital_managment_system.Interfaces.Rooms;
using Hospital_managment_system.Interfaces.RoomTypes;
using Hospital_managment_system.Repositories.Rooms;
using Hospital_managment_system.Repositories.RoomTypes;
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
        private readonly IRoomsRepository _roomsRepository;
        private readonly IRoomTypesRepository _roomTypesRepository;
        public OthersPage()
        {
            InitializeComponent();
            this._roomsRepository = new RoomsRepository();
            this._roomTypesRepository = new RoomTypeRepository();
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

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var getRoooms = await _roomsRepository.GetAllAsync(new Utilities.Paginations()
            {
                PageNumber = 1,
                PageSize = 30
            });
            var getRoomTypes=await _roomTypesRepository.GetAllAsync(new Utilities.Paginations()
            {
                PageNumber=1,
                PageSize = 30
            });

            foreach (var rooms in getRoooms)
            {
                RoomCreateUserControl roomCreateUserControl = new RoomCreateUserControl();
                roomCreateUserControl.setData(rooms);
                MainWP.Children.Add(roomCreateUserControl);

            }
            foreach (var roomType in getRoomTypes)
            {
                RoomTypeCreateViewUserControl room = new RoomTypeCreateViewUserControl();
                room.setData(roomType);
                MainWP2.Children.Add(room);

            }


        }
    }
}
