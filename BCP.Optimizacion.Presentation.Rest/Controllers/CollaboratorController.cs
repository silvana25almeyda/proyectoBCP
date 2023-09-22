using BCP.Optimizacion.Application.Contract;
using BCP.Optimizacion.Application.Entity;
using BCP.Optimizacion.Domain.Entity;
using BCP.Optimizacion.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace BCP.Optimizacion.Presentation.Rest.Controllers
{
    [RoutePrefix("collaborator")]
    public class CollaboratorController : ApiController
    {
        private readonly IServiceUser _servicioUser;
        private readonly IServiceBaseAplication _serviceBaseAplication;


        /// <summary> 
        /// Constructor de la Api de Renovación Póliza
        /// </summary>
        /// <param name="serviceUser">Permite acceder a las operaciones de los usuarios</param>
        /// <param name="serviceBaseAplication">Permite acceder a los métodos comunes de los Servicios</param>
        public CollaboratorController(IServiceUser serviceUser,
                                          IServiceBaseAplication serviceBaseAplication)
        {
            _servicioUser = serviceUser;
            _serviceBaseAplication = serviceBaseAplication;
        }
        // GET: Sale
        [HttpGet]
        public async Task<List<ResponseUsers>> Index()
        {
            var objListaUsuarios = await _servicioUser.ObtenerAsesores();
            /*var objEntidadDataStatus = _serviceBaseAplication.EvaluarTipoRetornoStatus<ResponseUsersDto,
                                        ResponseUsers>(objListaUsuarios);
            var responseResultado = _serviceBaseAplication.ObtenerResponseRequest(objEntidadDataStatus);*/

            return objListaUsuarios;
        }

        // GET: Sale
        [HttpGet]
        [Route("goal")]
        public async Task<HttpResponseMessage> ObtenerConsolidadoMetas()
        {
            var objResponseRequest = new HttpResponseMessage();

            objResponseRequest.StatusCode = HttpStatusCode.OK;
            return objResponseRequest;
        }

        // GET: Sale/Create
        [HttpPost]
        public async Task<HttpResponseMessage> Create()
        {
            var objResponseRequest = new HttpResponseMessage();

            objResponseRequest.StatusCode = HttpStatusCode.OK;
            return objResponseRequest;
        }



        // GET: Sale/Edit/5
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(int IdSale)
        {
            var objResponseRequest = new HttpResponseMessage();

            objResponseRequest.StatusCode = HttpStatusCode.OK;
            return objResponseRequest;
        }


        // GET: Sale/Delete/5
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int IdSale)
        {
            var objResponseRequest = new HttpResponseMessage();

            objResponseRequest.StatusCode = HttpStatusCode.OK;
            return objResponseRequest;
        }
    }
}