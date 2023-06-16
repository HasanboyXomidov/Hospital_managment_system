using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities.BedRoomNurse;

public sealed class BedRoomNurses : Auditable
{
    public long bedRoom_id { get; set;  }
    public long nurseI_id { get; set; }


}
