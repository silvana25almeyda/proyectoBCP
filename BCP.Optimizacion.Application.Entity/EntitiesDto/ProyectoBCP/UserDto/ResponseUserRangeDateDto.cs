using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Entity
{
    public class ResponseUserRangeDateDto
    {
        public MetadataDto metadata { get; set; }
        public List<UserRangeDateDto> RangoFechasPorUsuario { get; set; }
    }
}
