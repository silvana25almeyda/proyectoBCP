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
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
        private readonly IServiceUser _servicioUser;
        private readonly IServiceBaseAplication _serviceBaseAplication;


        /// <summary>
        /// Constructor de la Api de Renovación Póliza
        /// </summary>
        /// <param name="serviceUser">Permite acceder a las operaciones de los usuarios</param>
        /// <param name="serviceBaseAplication">Permite acceder a los métodos comunes de los Servicios</param>
        public ProductController(IServiceUser serviceUser,
                                          IServiceBaseAplication serviceBaseAplication)
        {
            _servicioUser = serviceUser;
            _serviceBaseAplication = serviceBaseAplication;
        }
        // GET: Sale
        [HttpGet]
        public async Task<HttpResponseMessage> Index()
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