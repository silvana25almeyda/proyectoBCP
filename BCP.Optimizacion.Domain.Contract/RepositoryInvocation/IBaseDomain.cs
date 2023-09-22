using BCP.Optimizacion.Domain.Entity;
using System.Net.Http;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Domain.Contract
{
    public interface IBaseDomain
    {
        ErrorResponse EvaluarRespuestaError(HttpResponseMessage response, string respuestaError);
        GenericResponse<Entidad> RetornarObjetoError<Entidad>(ErrorResponse errorResponse);
        Task<GenericResponse<Entidad>> EvaluarRespuestaRequest<Entidad>(HttpResponseMessage respuesta);
    }
}
