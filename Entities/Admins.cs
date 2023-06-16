using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Models
{
    public class Admins
    {
        public long id {  get; set; }
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;
        public string password_hash { get; set; } = string.Empty;
        public string salt { get; set; } = string.Empty;


    }
}
