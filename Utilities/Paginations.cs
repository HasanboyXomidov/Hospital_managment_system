using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Utilities;

public class Paginations
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public Paginations(int page,int pageSize) 
    {
        Page = page;
        PageSize = pageSize;    
    }
    public Paginations()
    {        
    }
}
