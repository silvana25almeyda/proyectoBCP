using BCP.Optimizacion.Domain.Contract;
using BCP.Optimizacion.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Infraestructure
{
    public class Sale : ISale
    {
        private readonly ICommonInvocations _commonInvocations;
        private readonly IUtilitarios _utilitarios;

        public Sale(ICommonInvocations commonInvocations, IUtilitarios utilitarios)
        {
            _commonInvocations = commonInvocations;
            _utilitarios = utilitarios;
        }

        public async Task<HttpResponseMessage> crearVenta(SaleRequest saleRequest)
        {
            HttpResponseMessage respuestaRequest;

            var uriBase = _utilitarios.RetornarUriBaseApiInclusionMasiva();
            var uri = uriBase + ConstantsOptimizacion.users;
            respuestaRequest = await _commonInvocations.GetRecurso(uri);

            return respuestaRequest;
        }

    }
}
