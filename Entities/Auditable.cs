using Hospital_managment_system.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_managment_system.Entities
{
     public abstract class Auditable : BaseEntity
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set;}
        public Auditable() 
        {
            created_at = TimeHelper.GetDateTime();
            updated_at = TimeHelper.GetDateTime(); 
        }
    }
}
