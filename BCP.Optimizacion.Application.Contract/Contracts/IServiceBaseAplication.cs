using BCP.Optimizacion.Application.Entity;
using BCP.Optimizacion.Domain.Entity;
using System.Net.Http;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Contract
{
    public interface IServiceBaseAplication
    {
        Cabecera ObtenerCabecera();
        HttpResponseMessage ObtenerResponseRequest(object[] objEntidadDataStatus);
        object[] EvaluarTipoRetornoStatus<Entidad, Entidad1>(GenericResponse<Entidad1> objEntidadBE);
        Task<GenericResponseDto<ResponseRolAplicacionDTO>> ObtenerRolesAplicaciones(string token);
    }
}
