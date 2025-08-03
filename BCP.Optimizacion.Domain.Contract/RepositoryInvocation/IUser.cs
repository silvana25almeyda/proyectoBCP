using System.Net.Http;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Domain.Contract
{
    public interface IUser
    {
        Task<HttpResponseMessage> ObtenerAsesores();
        Task<HttpResponseMessage> ObtenerUsuarios();
        Task<HttpResponseMessage> ObtenerUsuariosRangeDate(string userId);

    }
}
