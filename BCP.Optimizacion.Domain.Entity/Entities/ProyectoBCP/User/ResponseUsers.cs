using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Domain.Entity
{
    public class ResponseUsers
    {
        public Metadata metadata { get; set; }
        public List<User> usuarios { get; set; }
    }
}
