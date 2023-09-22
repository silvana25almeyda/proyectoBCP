using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Entity
{
    public class ErrorDto
    {
        public int? numRiesgo { get; set; }
        public int? numSec { get; set; }
        public string descErrorBatch { get; set; }
    }
}
