using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Domain.Entity
{
    public class ResponseUserRangeDate
    {
        public Metadata metadata { get; set; }
        public List<UserRangeDate> fechas { get; set; }
    }
}
