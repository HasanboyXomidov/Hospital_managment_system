using Hospital_managment_system.Entities;
using Hospital_managment_system.Entities.Rooms;
using Hospital_managment_system.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces.Rooms;

public interface IRoomsRepository:IRepository<OtherRoom,OtherRoom>
{
    public Task<IList<OtherRoom>> GetEmptyRooms(Paginations @params);
}
