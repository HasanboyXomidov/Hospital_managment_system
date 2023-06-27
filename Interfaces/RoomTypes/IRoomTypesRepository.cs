using Hospital_managment_system.Entities.RoomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Interfaces.RoomTypes;

public interface IRoomTypesRepository : IRepository<RoomType,RoomType>
{
    public Task<int> BedroomCount();
    public Task<int> FreeBedroomCount();
    
}
