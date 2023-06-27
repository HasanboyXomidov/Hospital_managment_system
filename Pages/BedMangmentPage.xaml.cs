using Hospital_managment_system.Components.BedRooms;
using Hospital_managment_system.Interfaces.BedRooms;
using Hospital_managment_system.Interfaces.RoomTypes;
using Hospital_managment_system.Repositories.BedRooms;
using Hospital_managment_system.Repositories.RoomTypes;
using Hospital_managment_system.Utilities;
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

namespace Hospital_managment_system.Pages
{
    /// <summary>
    /// Interaction logic for BedMangmentPage.xaml
    /// </summary>
    public partial class BedMangmentPage : Page
    {
        private readonly IBedRoomsRepository _repository;
        private readonly IRoomTypesRepository _roomTypesRepository;

        public BedMangmentPage()
        {
            InitializeComponent();
            this._repository = new BedRoomRepository();
            this._roomTypesRepository=new RoomTypeRepository();

        }

        public async Task refreshAsync()
        {
            MainWP.Children.Clear();
            Paginations paginations = new Paginations()
            {
                PageNumber = 1,
                PageSize = 20
            };
            var bedrooms = await _repository.GetAllAsync(paginations);

            foreach (var bedroom in bedrooms)
            {
                BedRoomsViewUserControl bedRoomsViewUserControl = new BedRoomsViewUserControl();
                bedRoomsViewUserControl.setData(bedroom);
                MainWP.Children.Add(bedRoomsViewUserControl);


            }
            var countfreeRooms = await _roomTypesRepository.FreeBedroomCount();
            var bedroomCount = await _roomTypesRepository.BedroomCount();
            lblAllRooms.Content=bedroomCount.ToString();
            FreeBed_lbl.Content=countfreeRooms.ToString();
            Reservedroom_lbl.Content = (bedroomCount - countfreeRooms);


        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            await refreshAsync();
        }



        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            BedRoomCreateWindow bedRoomCreateWindow = new BedRoomCreateWindow();
            bedRoomCreateWindow.ShowDialog();


        }
    }
}
