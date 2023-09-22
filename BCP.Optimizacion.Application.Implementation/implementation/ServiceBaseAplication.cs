using BCP.Optimizacion.Application.Contract;
using BCP.Optimizacion.Application.Entity;
using BCP.Optimizacion.Domain.Contract;
using BCP.Optimizacion.Domain.Entity;
using BCP.Optimizacion.Infraestructure;
using BCP.Optimizacion.Infraestructure.WebClient.Rest.NewLogin;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace BCP.Optimizacion.Application.Implementation
{
    public class ServiceBaseAplication : ApiController, IServiceBaseAplication
    {
        private readonly IMapperInstance _mapper;
        private readonly IUtilitarios _utilitarios;
        private readonly IOperacionLogin _operacionLogin;
        private readonly ILogger _log;
        private readonly IBaseDomain _baseDomain;

        public ServiceBaseAplication(IMapperInstance mapper, IUtilitarios utilitarios, ILogger log,
                                     IOperacionLogin operacionLogin, IBaseDomain baseDomain)
        {
            _mapper = mapper;
            _utilitarios = utilitarios;
            _operacionLogin = operacionLogin;
            _log = log;
            _baseDomain = baseDomain;
        }
        public Cabecera ObtenerCabecera()
        {
            var cabecera = new Cabecera();

            cabecera.codigoUsuario = ConstantsOptimizacion.codigoUsuario;
            cabecera.codigoModulo = ConstantsOptimizacion.codigoModulo;
            cabecera.codigoAplicacion = ConstantsOptimizacion.codigoAplicacion;

            return cabecera;
        }

        public HttpResponseMessage ObtenerResponseRequest(object[] objEntidadDataStatus)
        {
            var objEntidadDataJson = RetornarResultadoJson(objEntidadDataStatus[0]);
            var objResponseRequest = new HttpResponseMessage();

            objResponseRequest.Content = new
                StringContent(objEntidadDataJson.ToString(), Encoding.UTF8, ConstantsOptimizacion.ContentTypeJson);
            objResponseRequest.StatusCode = (HttpStatusCode)objEntidadDataStatus[1];

            return objResponseRequest;
        }

        public object[] EvaluarTipoRetornoStatus<Entidad, Entidad1>(GenericResponse<Entidad1> objEntidadBE)
        {
            object objEntidadDTO;
            object[] resultadoResponse = new object[2];

            resultadoResponse[1] = objEntidadBE.codigoResponse;

            if (objEntidadBE.errors == null && string.IsNullOrEmpty(objEntidadBE.message)
                && objEntidadBE.dataResponse != null)
            {
                objEntidadDTO = _mapper.Mapear<Entidad1, Entidad>(objEntidadBE.dataResponse);
                resultadoResponse[0] = objEntidadDTO;
            }
            else
            {
                objEntidadDTO = _mapper.Mapear<GenericResponse<Entidad1>, GenericResponseDto<Entidad>>(objEntidadBE);
                resultadoResponse[0] = objEntidadDTO;
            }

            return resultadoResponse;
        }

        public async Task<GenericResponseDto<ResponseRolAplicacionDTO>> ObtenerRolesAplicaciones(string token)
        {
            var objResponseGenericoDTO = new GenericResponseDto<ResponseRolAplicacionDTO>();

            try
            {
                var respuestaRequest = await _operacionLogin.ObtenerRolesAplicaciones(token);
                var respuestaGenerica = await _baseDomain.
                                               EvaluarRespuestaRequest<ResponseRolAplicacion>(respuestaRequest);
                objResponseGenericoDTO = _mapper.Mapear<GenericResponse<ResponseRolAplicacion>,
                                             GenericResponseDto<ResponseRolAplicacionDTO>>(respuestaGenerica);
            }
            catch (Exception ex)
            {
                objResponseGenericoDTO.message = ex.Message;
                objResponseGenericoDTO.codigoResponse = HttpStatusCode.InternalServerError;
                _log.Error(ex.Message, ex);
            }

            return objResponseGenericoDTO;
        }

        #region Metodos Privados
        private JObject RetornarResultadoJson(object objEntidad)
        {
            var entidadSerializada = _utilitarios.Serializar(objEntidad);
            var objJsonEntidad = JObject.Parse(entidadSerializada);

            return objJsonEntidad;
        }
        #endregion
    }
}
