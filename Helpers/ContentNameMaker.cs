using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Helpers;

public  class ContentNameMaker
{
    public static string GetImageName(string filepath)
    {
        FileInfo file = new FileInfo(filepath);
        return "IMG_" + Guid.NewGuid().ToString() + file.Extension;
    }

}
