using System.Collections.Generic;
using System.Net;

namespace BCP.Optimizacion.Application.Entity
{
    public class GenericResponseDto<Entidad>
    {
        public Entidad dataResponse { get; set; }
        public List<string> errors { get; set; }
        public int? status { get; set; }
        public string message { get; set; }
        public HttpStatusCode? codigoResponse { get; set; }
        public object data { get; set; }
    }
}
