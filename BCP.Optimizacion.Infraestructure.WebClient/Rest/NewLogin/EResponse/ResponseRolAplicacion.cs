using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Infraestructure.WebClient.Rest.NewLogin
{
    public class ResponseRolAplicacion
    {
        public string message { get; set; }
        public List<RolAplicacion> data { get; set; }
        public int? operationCode { get; set; }
        public string typeMessage { get; set; }
    }

    public class RolAplicacion
    {
        public string nombreAplicacion { get; set; }
        public string codigoRol { get; set; }
        public string nombreRol { get; set; }
    }
}
