using Hospital_managment_system.Entities.BedRooms;
using Hospital_managment_system.ViewModels.BedRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces.BedRooms;

public interface IBedRoomsRepository : IRepository<BedRoom,BedRoomsViewModel>
{        

}
