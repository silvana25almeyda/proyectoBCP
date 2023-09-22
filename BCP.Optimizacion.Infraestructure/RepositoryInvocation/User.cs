using BCP.Optimizacion.Domain.Contract;
using BCP.Optimizacion.Domain.Entity;
using System.Net.Http;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Infraestructure
{
    public class User : IUser
    {
        private readonly ICommonInvocations _commonInvocations;
        private readonly IUtilitarios _utilitarios;

        public User(ICommonInvocations commonInvocations, IUtilitarios utilitarios)
        {
            _commonInvocations = commonInvocations;
            _utilitarios = utilitarios;
        }

        public async Task<HttpResponseMessage> ObtenerUsuarios()
        {
            HttpResponseMessage respuestaRequest;

            var uriBase = _utilitarios.RetornarUriBaseApiInclusionMasiva();
            var uri = uriBase + ConstantsOptimizacion.users;
            respuestaRequest = await _commonInvocations.GetRecurso(uri);

            return respuestaRequest;
        }

        public async Task<HttpResponseMessage> ObtenerUsuariosRangeDate(string userId)
        {
            HttpResponseMessage respuestaRequest;

            var uriBase = _utilitarios.RetornarUriBaseApiInclusionMasiva();
            var uri = uriBase + ConstantsOptimizacion.user + userId + ConstantsOptimizacion.userRangeDate;
            respuestaRequest = await _commonInvocations.GetRecurso(uri);

            return respuestaRequest;
        }
    }
}
