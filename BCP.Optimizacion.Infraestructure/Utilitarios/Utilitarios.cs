using Newtonsoft.Json;

namespace BCP.Optimizacion.Infraestructure
{
    public class Utilitarios : IUtilitarios
    {
        public Utilitarios()
        {

        }
        public string Serializar(object entidad)
        {
            var data = JsonConvert.SerializeObject(entidad);
            return data;
        }
        public Entidad DesSerializar<Entidad>(string data)
        {
            var resultado = JsonConvert.DeserializeObject<Entidad>(data, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
            return resultado;
        }

        public string RetornarUriBaseApiNewLogin()
        {
            var uriBaseApiNewLogin = UrisApiBase.ApiRestNewLogin;

            return uriBaseApiNewLogin;
        }

        public string RetornarUriBaseApiInclusionMasiva()
        {
            var uriBaseApiInclusionMasiva = UrisApiBase.ApiRestInclusionMasiva;

            return uriBaseApiInclusionMasiva;
        }
    }
}
