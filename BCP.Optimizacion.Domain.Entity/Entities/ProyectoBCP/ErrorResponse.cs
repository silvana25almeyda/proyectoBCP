using System.Collections.Generic;
using System.Net;

namespace BCP.Optimizacion.Domain.Entity
{
    public class ErrorResponse
    {
        public string error { get; set; }
        public HttpStatusCode? code { get; set; }
        public object data { get; set; }
        public List<string> errors { get; set; }
        public int? status { get; set; }
        public string message { get; set; }
        public string path { get; set; }
    }
}
