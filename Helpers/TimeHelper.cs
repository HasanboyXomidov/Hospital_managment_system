using Hospital_managment_system.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Helpers;

class TimeHelper
{
     public static DateTime GetDateTime()
    {
        var dTime = DateTime.UtcNow;
        dTime.AddHours(TimeConstants.UTC); 
        return dTime;
    }
}
