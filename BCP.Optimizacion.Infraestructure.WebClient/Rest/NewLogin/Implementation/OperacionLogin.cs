using System.Net.Http;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Infraestructure.WebClient.Rest.NewLogin
{
    public class OperacionLogin : IOperacionLogin
    {
        private readonly ICommonInvocations _commonInvocations;
        private readonly IUtilitarios _utilitarios;

        public OperacionLogin(ICommonInvocations commonInvocations, IUtilitarios utilitarios)
        {
            _commonInvocations = commonInvocations;
            _utilitarios = utilitarios;
        }

        public async Task<HttpResponseMessage> ObtenerRolesAplicaciones(string token)
        {
            HttpResponseMessage respuestaRequest;

            var uriBase = _utilitarios.RetornarUriBaseApiNewLogin();
            var uri = uriBase + ConstantsOptimizacion.rolesUsuarios;
            respuestaRequest = await _commonInvocations.GetRecurso(uri, token);

            return respuestaRequest;
        }

    }
}
