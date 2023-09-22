using System.Collections.Generic;

namespace BCP.Optimizacion.Domain.Entity
{
    public class Metadata
    {
        public int? codError { get; set; }
        public string descError { get; set; }
        public List<string> errores { get; set; }
    }
}
