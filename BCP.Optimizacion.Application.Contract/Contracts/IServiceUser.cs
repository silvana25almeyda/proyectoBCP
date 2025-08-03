using BCP.Optimizacion.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Contract
{
    public interface IServiceUser
    {
        Task<List<ResponseUsers>> ObtenerAsesores();
        Task<GenericResponse<ResponseUsers>> ObtenerUsuarios();
        Task<GenericResponse<ResponseUserRangeDate>> ObtenerUsuariosRangeDate(string userId);
    }
}
