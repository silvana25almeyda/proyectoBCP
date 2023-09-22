using BCP.Optimizacion.Application.Contract;
using BCP.Optimizacion.Domain.Contract;
using BCP.Optimizacion.Domain.Entity;
using BCP.Optimizacion.Infraestructure;
using System;
using System.Net;
using System.Threading.Tasks;
namespace BCP.Optimizacion.Application.Implementation
{
    public class ServiceSale: IServiceSale
    {
        private readonly ISale _sale;
        private readonly IBaseDomain _baseDomain;
        private readonly ILogger _log;

        public ServiceSale(ISale sale, IBaseDomain baseDomain, ILogger log)
        {
            _sale = sale;
            _baseDomain = baseDomain;
            _log = log;
        }

        public async Task<GenericResponse<SaleResponse>> crearVenta(SaleRequest saleRequest)
        {
            var objListaParametros = new GenericResponse<SaleResponse>();

            try
            {
                var respuestaRequest = await _sale.crearVenta(saleRequest);
                objListaParametros = await _baseDomain.
                        EvaluarRespuestaRequest<SaleResponse>(respuestaRequest);
            }
            catch (Exception ex)
            {
                objListaParametros.message = ex.Message;
                objListaParametros.codigoResponse = HttpStatusCode.InternalServerError;
                _log.Error(ex.Message, ex);
            }

            return objListaParametros;
        }

    }
}
