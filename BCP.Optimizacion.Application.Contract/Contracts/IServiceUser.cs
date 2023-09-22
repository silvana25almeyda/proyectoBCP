using BCP.Optimizacion.Domain.Entity;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Contract
{
    public interface IServiceUser
    {
        Task<GenericResponse<ResponseUsers>> ObtenerUsuarios();
        Task<GenericResponse<ResponseUserRangeDate>> ObtenerUsuariosRangeDate(string userId);
    }
}
