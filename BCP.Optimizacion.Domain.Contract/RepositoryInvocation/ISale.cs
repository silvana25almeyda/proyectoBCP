using BCP.Optimizacion.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Domain.Contract
{
    public interface ISale
    {
        Task<HttpResponseMessage> crearVenta(SaleRequest saleRequest);
    }
}
