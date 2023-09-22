using System.Net.Http;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Infraestructure
{
    public interface ICommonInvocations
    {
        Task<HttpResponseMessage> GetRecurso(string url);
        Task<HttpResponseMessage> GetRecurso(string url, string token);
        Task<HttpResponseMessage> PostBodyResultado<Entidad>(string url, Entidad entidad);
        Task<HttpResponseMessage> PutBodyResultado<Entidad>(string url, Entidad entidad);
        Task<HttpResponseMessage> DeleteRecurso<Entidad>(string url, Entidad entidad);
    }
}
