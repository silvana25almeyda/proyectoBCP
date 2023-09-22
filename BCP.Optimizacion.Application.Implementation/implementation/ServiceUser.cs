using BCP.Optimizacion.Application.Contract;
using BCP.Optimizacion.Domain.Contract;
using BCP.Optimizacion.Domain.Entity;
using BCP.Optimizacion.Infraestructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Implementation
{
    public class ServiceUser : IServiceUser
    {
        private readonly IUser _user;
        private readonly IBaseDomain _baseDomain;
        private readonly ILogger _log;

        public ServiceUser(IUser user, IBaseDomain baseDomain, ILogger log)
        {
            _user = user;
            _baseDomain = baseDomain;
            _log = log;
        }

        public async Task<List<ResponseUsers>> ObtenerAsesores()
        {
            var objListaParametros = new List<ResponseUsers>();

            try
            {
                var respuestaRequest =  await _user.ObtenerAsesores();
                //objListaParametros = await _baseDomain.EvaluarRespuestaRequest<ResponseUsers>(respuestaRequest);
                var contenidoRespuesta =  await respuestaRequest.Content.ReadAsStringAsync();
                var array = JArray.Parse(contenidoRespuesta);
                foreach (var item in array)
                {
                    try
                    {
                        objListaParametros.Add(item.ToObject<ResponseUsers>());
                    }
                    catch (Exception ex)
                    {
                        _log.Error(ex.Message, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message, ex);
            }

            return objListaParametros;
        }


        public async Task<GenericResponse<ResponseUsers>> ObtenerUsuarios()
        {
            var objListaParametros = new GenericResponse<ResponseUsers>();

            try
            {
                var respuestaRequest = await _user.ObtenerUsuarios();
                objListaParametros = await _baseDomain.
                        EvaluarRespuestaRequest<ResponseUsers>(respuestaRequest);
            }
            catch (Exception ex)
            {
                objListaParametros.message = ex.Message;
                objListaParametros.codigoResponse = HttpStatusCode.InternalServerError;
                _log.Error(ex.Message, ex);
            }

            return objListaParametros;
        }

        public async Task<GenericResponse<ResponseUserRangeDate>> ObtenerUsuariosRangeDate(string userId)
        {
            var objParametrosFiltrados = new GenericResponse<ResponseUserRangeDate>();

            try
            {
                var respuestaRequest = await _user.ObtenerUsuariosRangeDate(userId);
                objParametrosFiltrados = await _baseDomain.
                        EvaluarRespuestaRequest<ResponseUserRangeDate>(respuestaRequest);
            }
            catch (Exception ex)
            {
                objParametrosFiltrados.message = ex.Message;
                objParametrosFiltrados.codigoResponse = HttpStatusCode.InternalServerError;
                _log.Error(ex.Message, ex);
            }

            return objParametrosFiltrados;
        }

    }
}
