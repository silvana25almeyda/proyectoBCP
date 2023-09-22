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
    /// Controlador de la Api para obtener usuarios
    /// </summary>
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        private readonly IServiceUser _servicioUser;
        private readonly IServiceBaseAplication _serviceBaseAplication;


        /// <summary>
        /// Constructor de la Api de Renovación Póliza
        /// </summary>
        /// <param name="serviceUser">Permite acceder a las operaciones de los usuarios</param>
        /// <param name="serviceBaseAplication">Permite acceder a los métodos comunes de los Servicios</param>
        public CustomerController(IServiceUser serviceUser,
                                          IServiceBaseAplication serviceBaseAplication)
        {
            _servicioUser = serviceUser;
            _serviceBaseAplication = serviceBaseAplication;
        }

        /// <summary>
        /// Operación que permite obtener los clientes
        /// </summary>
        /// <returns>Objeto Lista de Clientes</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> ObtenerUsuarios()
        {
            var objListaUsuarios = await _servicioUser.ObtenerUsuarios();
            var objEntidadDataStatus = _serviceBaseAplication.EvaluarTipoRetornoStatus<ResponseUsersDto,
                                        ResponseUsers>(objListaUsuarios);
            var responseResultado = _serviceBaseAplication.ObtenerResponseRequest(objEntidadDataStatus);

            return responseResultado;
        }

        /// <summary>
        /// Operación que crea clientes
        /// </summary>
        [HttpPost]
        public async Task<HttpResponseMessage> CrearUsuario()
        {
            var objListaUsuarios = await _servicioUser.ObtenerUsuarios();
            var objEntidadDataStatus = _serviceBaseAplication.EvaluarTipoRetornoStatus<ResponseUsersDto,
                                        ResponseUsers>(objListaUsuarios);
            var responseResultado = _serviceBaseAplication.ObtenerResponseRequest(objEntidadDataStatus);

            return responseResultado;
        }
    }
}