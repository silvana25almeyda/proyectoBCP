using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Entity
{
    public class MetadataDto
    {
        public int? codError { get; set; }
        public string descError { get; set; }
        public List<string> errores { get; set; }
    }
}
