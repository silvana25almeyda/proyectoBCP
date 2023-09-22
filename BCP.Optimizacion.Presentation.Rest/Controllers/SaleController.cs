using BCP.Optimizacion.Application.Contract;
using BCP.Optimizacion.Application.Entity;
using BCP.Optimizacion.Domain.Entity;
using BCP.Optimizacion.Infraestructure;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace BCP.Optimizacion.Presentation.Rest.Controllers
{
    /// <summary>
    /// Controlador de la Api para ventas
    /// </summary>
    [RoutePrefix("sale")]
    public class SaleController : ApiController
    { 
        private readonly IServiceUser _servicioUser;
        private readonly IServiceSale _servicioSale;
        private readonly IServiceBaseAplication _serviceBaseAplication;


        /// <summary>
        /// Constructor de la Api de Renovación Póliza
        /// </summary>
        /// <param name="serviceUser">Permite acceder a las operaciones de los usuarios</param>
        /// <param name="serviceSale">Permite acceder a las operaciones de los usuarios</param>
        /// <param name="serviceBaseAplication">Permite acceder a los métodos comunes de los Servicios</param>
        public SaleController(IServiceUser serviceUser, IServiceSale serviceSale,
                                          IServiceBaseAplication serviceBaseAplication)
        {
            _servicioUser = serviceUser;
            _servicioSale = serviceSale;
            _serviceBaseAplication = serviceBaseAplication;
        }
        // GET: Sale
        [HttpGet]
        public async Task<HttpResponseMessage> Index()
        {
            var objListaUsuarios = await _servicioUser.ObtenerUsuarios();
            var objEntidadDataStatus = _serviceBaseAplication.EvaluarTipoRetornoStatus<ResponseUsersDto,
                                        ResponseUsers>(objListaUsuarios);
            var responseResultado = _serviceBaseAplication.ObtenerResponseRequest(objEntidadDataStatus);

            return responseResultado;
        }


        // GET: Sale/Create
        [HttpPost]
        public async Task<HttpResponseMessage> Create([FromBody] SaleRequest saleRequest)
        {
            var objVenta = await _servicioSale.crearVenta(saleRequest);
            var objEntidadDataStatus = _serviceBaseAplication.EvaluarTipoRetornoStatus<SaleRequestDto,
                                        SaleResponse>(objVenta);
            var responseResultado = _serviceBaseAplication.ObtenerResponseRequest(objEntidadDataStatus);

            return responseResultado;
        }

        

        // GET: Sale/Edit/5
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(int IdSale)
        {
            var objListaUsuarios = await _servicioUser.ObtenerUsuarios();
            var objEntidadDataStatus = _serviceBaseAplication.EvaluarTipoRetornoStatus<ResponseUsersDto,
                                        ResponseUsers>(objListaUsuarios);
            var responseResultado = _serviceBaseAplication.ObtenerResponseRequest(objEntidadDataStatus);

            return responseResultado;
        }


        // GET: Sale/Delete/5
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int IdSale)
        {
            var objListaUsuarios = await _servicioUser.ObtenerUsuarios();
            var objEntidadDataStatus = _serviceBaseAplication.EvaluarTipoRetornoStatus<ResponseUsersDto,
                                        ResponseUsers>(objListaUsuarios);
            var responseResultado = _serviceBaseAplication.ObtenerResponseRequest(objEntidadDataStatus);

            return responseResultado;
        }
    }
}
