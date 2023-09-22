using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Entity
{
    public class ResponseRolAplicacionDTO
    {
        public string message { get; set; }
        public List<RolAplicacionDTO> data { get; set; }
        public int? operationCode { get; set; }
        public string typeMessage { get; set; }
    }

    public class RolAplicacionDTO
    {
        public string nombreAplicacion { get; set; }
        public string codigoRol { get; set; }
        public string nombreRol { get; set; }
    }
}
