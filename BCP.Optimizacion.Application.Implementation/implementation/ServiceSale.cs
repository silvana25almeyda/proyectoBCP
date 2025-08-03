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

        public  SaleResponse crearVenta(SaleRequest saleRequest)
        {
            var objListaParametros = new SaleResponse();

            try
            {
                objListaParametros = _sale.crearVenta(saleRequest);
            }
            catch (Exception ex)
            {
                objListaParametros.message = ex.Message;
                objListaParametros.codigoResponse = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _log.Error(ex.Message, ex);
            }

            return objListaParametros;
        }

    }
}
