using BCP.Optimizacion.Domain.Contract;
using BCP.Optimizacion.Domain.Entity;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Domain.Implementation
{
    public class BaseDomain : IBaseDomain
    {
        public ErrorResponse EvaluarRespuestaError(HttpResponseMessage response, string respuestaError)
        {
            ErrorResponse objError = new ErrorResponse();

            if (string.IsNullOrEmpty(respuestaError))
            {
                objError.code = response.StatusCode;
                objError.message = response.StatusCode.ToString();
            }
            else
            {
                objError = DesSerializar<ErrorResponse>(respuestaError);
                objError.code = response.StatusCode;

                if (respuestaError.Contains("timestamp"))
                {
                    objError.code = response.StatusCode;
                    objError.message = objError.message + "/ PathError: " + objError.path;
                }
            }

            return objError;
        }

        public async Task<GenericResponse<Entidad>> EvaluarRespuestaRequest<Entidad>(HttpResponseMessage respuesta)
        {
            GenericResponse<Entidad> objEntidad = new GenericResponse<Entidad>();

            switch (respuesta.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                    var objRespuesta = await RetornarDataRespuesta<Entidad>(respuesta);
                    objEntidad.dataResponse = objRespuesta.dataResponse;
                    objEntidad.codigoResponse = respuesta.StatusCode;
                    break;

                case HttpStatusCode.BadRequest:
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.Conflict:
                default:
                    var respuestaErronea = await respuesta.Content.ReadAsStringAsync();
                    var objError = EvaluarRespuestaError(respuesta, respuestaErronea);
                    objEntidad = RetornarObjetoError<Entidad>(objError);
                    break;
            }
            return objEntidad;
        }

        public GenericResponse<Entidad> RetornarObjetoError<Entidad>(ErrorResponse errorResponse)
        {
            GenericResponse<Entidad> objReponseError = new GenericResponse<Entidad>();

            objReponseError.errors = errorResponse.errors;
            objReponseError.message = errorResponse.message;
            objReponseError.status = errorResponse.status;
            objReponseError.codigoResponse = errorResponse.code;
            objReponseError.data = errorResponse.data;

            return objReponseError;
        }

        private async Task<GenericResponse<Entidad>> RetornarDataRespuesta<Entidad>
            (HttpResponseMessage respuesta)
        {
            GenericResponse<Entidad> objRespuestaProforma = new GenericResponse<Entidad>();

            var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
            objRespuestaProforma.dataResponse = DesSerializar<Entidad>(contenidoRespuesta);

            return objRespuestaProforma;
        }

        private string Serializar(object entidad)
        {
            var data = JsonConvert.SerializeObject(entidad);
            return data;
        }

        private Entidad DesSerializar<Entidad>(string data)
        {
            var resultado = JsonConvert.DeserializeObject<Entidad>(data, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            return resultado;
        }
    }
}
