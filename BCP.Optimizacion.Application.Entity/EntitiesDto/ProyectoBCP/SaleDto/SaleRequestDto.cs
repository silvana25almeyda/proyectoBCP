using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Entity
{ 
    public class SaleRequestDto
    {
        public int IdPeriodo { get; set; }
        public int IdProductoFinanciero { get; set; }
        public int IdAsesorComercial { get; set; }
        public int IdCliente { get; set; }
        public decimal MontoDesembolsado { get; set; }
    }
}
