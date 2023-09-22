using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Entity
{
    public class UserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public ICollection<addressUser> address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public ICollection<companyUser> company { get; set; }

        public class addressUser
        {
            public string street { get; set; }
            public string suite { get; set; }
            public string city { get; set; }
            public string zipcode { get; set; }
            public ICollection<geoUser> geo { get; set; }

        }
        public class geoUser
        {
            public string lat { get; set; }
            public string lng { get; set; }

        }
        public class companyUser
        {
            public string name { get; set; }
            public string catchPhrase { get; set; }
            public string bs { get; set; }

        }
    }
}
