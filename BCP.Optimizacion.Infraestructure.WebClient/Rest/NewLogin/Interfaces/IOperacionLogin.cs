using System.Net.Http;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Infraestructure.WebClient.Rest.NewLogin
{
    public interface IOperacionLogin
    {
        Task<HttpResponseMessage> ObtenerRolesAplicaciones(string token);
    }
}
